using Microsoft.AspNetCore.Mvc;
using LiteDB;
using sharedCode;
using System.Configuration;
using System.Collections.Generic;
using System;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;

namespace NetworkSynq.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LoadDBController : ControllerBase
    {
        private static readonly IConfiguration conf = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        public static readonly string DBConnection =  conf["ConnectionString"].ToString();
        private static LiteDatabase db = new(DBConnection);
        public static LiteDatabase Db { get => db; set => db = value; }
        private static readonly string LogFile = @"C:\db";
        static int order = 0;



        [HttpGet]
        [Route("KillServer")]
        public ActionResult KillServer()
        {
            try
            {
                LogMyAPI("Killing Server");
                Environment.Exit(0);
                return Ok();
            }
            catch (Exception ex)
            {
                LogMyAPI(ex.Message.ToString());
                return NoContent();
            }
        }

        [HttpGet]
        [Route("AreYouAlive")]
        public ActionResult<bool> Alive()
        {
            try
            {
                Console.Write("Yes,I'm Alive");

                return Ok(true);
            }
            catch (Exception ex)
            {
                LogMyAPI(ex.Message.ToString());
                return Ok(false);

            }

        }

        [HttpGet]
        [Route("InvoiceCount")]
        public ActionResult<int> InvoiceCount()
        {
            try
            {
                LogMyAPI("Getting Invoice Count");

                var s = Db.GetCollection<Invoice>("Invoices");
                int S = s.Max(x => x.ID);
                if (S == 0)
                {
                    return Ok(1);
                }
                else return Ok(S);

            }
            catch (Exception ex)
            {
                LogMyAPI(ex.Message);

                var s = Db.GetCollection<Invoice>("Invoices");
                if (s.Count() != 0)
                {
                    int S = s.Max(x => x.ID);
                    return Ok(S);
                }
                else return Ok(1);

            }


        }
        [HttpGet]
        [Route("DeleteDB")]
        public ActionResult<bool> DeleteDB()
        {
            try
            {
                LogMyAPI("Backing Up");
                //create a backup for the db
                string backupPath = @"C:\db";
                string backupFile = backupPath + @$"\db{DateTime.Now.Month}_{DateTime.Now.Year}.db";
                if (!Directory.Exists(backupPath))
                {
                    Directory.CreateDirectory(backupPath);
                }


                Db.Dispose();
                LogMyAPI("db disposed");
                // create a back up file
                System.IO.File.Copy(DBConnection.ToLower().Replace("filename=", ""), backupFile, true);
                LogMyAPI("File Copied");
                Db = new LiteDatabase(DBConnection);
                Db.DropCollection("Invoices");
                LogMyAPI("Invoices Dropped");
                Db.Rebuild();
                LogMyAPI("Rebuilt DB");

                var newindexes = Db.GetCollection<Invoice>("Invoices");
                newindexes.DropIndex("Status");
                newindexes.DropIndex("SearchResult");
                newindexes.DropIndex("CustomerNumber");
                newindexes.DropIndex("ID");
                //newindexes.EnsureIndex(x => x.Status);
                //newindexes.EnsureIndex(x => x.SearchResult);
                //newindexes.EnsureIndex(x => x.CustomerNumber);

                //newindexes.EnsureIndex(x => x.ID);
                var Materials = Db.GetCollection<POSItems>("Materials");
                Materials.DropIndex("Materials");
                //Materials.EnsureIndex(x => x.Barcode);
                var sectionTable = Db.GetCollection<POSsections>("Sections");
                //sectionTable.EnsureIndex(x => x.Name);
                var Deps = Db.GetCollection<Contacts>("Customers");
                Deps.DeleteMany(x => x.Number == null);
                Deps.DropIndex("Number");
                //Deps.EnsureIndex(x => x.Number);

                return true;


            }
            catch (Exception ex)
            {
                LogMyAPI(ex.Message);
                return false;
            }


        }

        public static void LogMyAPI(string text)
        {
            try
            {
                using StreamWriter w = new(LogFile + @"\log.text", true);
                w.WriteLine(text);
            }
            catch (Exception ex)
            {
                LogMyAPI(ex.Message.ToString());
            }

        }

        [HttpGet]
        [Route("GetList")]
        public ActionResult<IEnumerable<Invoice>> GetDraftInvoices(string inv)
        {
            try
            {
                var draft = Db.GetCollection<Invoice>("Invoices");
                LogMyAPI("Got List of " + inv + " Invoices");
                if (inv == "draft")
                {
                    var draftInv = draft.Find(x => x.Status == InvStat.Draft && x.InvoiceItems.Count > 0).ToList();
                    LogMyAPI(draftInv.Count.ToString());
                    if (draftInv.Count > 0)
                    {

                        return Ok(draftInv);

                    }
                    else return Ok(new List<Invoice>());
                }
                else if (inv == "saved")
                {
                    var draftinv = draft.Find(x => x.Status == InvStat.SavedToPOS || x.Status == InvStat.Deleted).Where(x => x.TimeOfSaving > DateTime.Now.AddDays(-14)).OrderByDescending(x => x.ID).ToList();
                    if (draftinv.Count > 0)
                    {
                        return Ok(draftinv.ToList());
                    }
                    else return Ok(new List<Invoice>());
                }
                else if (inv == "printed")
                {

                    var draftinv = draft.Find(x => x.Status == InvStat.Printed).Take(100).ToList().OrderByDescending(x => x.TimeinArabic == "الآن").ThenBy(x => x.TimeOfInv);
                    if (draftinv.Any()) return Ok(draftinv);
                    else return Ok(new List<Invoice>());

                }
                else if (inv == "allsaved")
                {
                    var draftInv = draft.Find(x => x.Status == InvStat.SavedToPOS || x.Status == InvStat.Deleted);
                    var d = draftInv.OrderByDescending(i => i.ID).ToList();
                    return Ok(d);
                }
                else if (inv == "draft")
                {
                    var d = draft.Query().Where(x => x.Status == InvStat.Draft && x.InvoiceItems.Count > 0).Limit(100).ToList();
                    return Ok(d);
                }
                else if (inv == "lastapps")
                {
                    var d = draft.Find(x => x.OrderType == "تطبيقات" && x.Status == InvStat.SavedToPOS).OrderByDescending(x => x.ID).Take(100).ToList();
                    return Ok(d);
                }
                else if (inv == "readyOrdersOnly")
                {
                        var d = draft.Find(x => x.InEditMode  && x.Status != InvStat.Deleted).OrderByDescending(x => x.ID).Take(42).ToList();
                    return Ok(d);
                }
                else if (inv == "last42invoices")
                {

                    var idFirst = draft.Find(x=> x.TimeOfSaving > DateTime.Now.AddDays(-6)).First().ID;
                    var d = draft.Find(x => !x.InEditMode  && (int)x.InvoiceDay == (int)DateTime.Now.DayOfWeek && x.Status != InvStat.Deleted && x.Status != InvStat.Draft && x.ID > idFirst).OrderByDescending(x => x.TimeinArabic == "الآن").ThenBy(x => x.TimeOfInv).ToList();
                    return Ok(d);
                }
                else
                {
                    var draftInv = draft.Find(x => x.Status == InvStat.SavedToPOS || x.Status == InvStat.Deleted).Where(x => x.SearchResult.Contains(inv));
                    var d = draftInv.OrderByDescending(i => Convert.ToInt32(i.IDstring)).ToList();
                    return Ok(d);

                }
            }
            catch (Exception ex)
            {
                LogMyAPI("Error in GetList");
                LogMyAPI(ex.Message);
                return new List<Invoice>();
            }

        }
        [HttpPost]
        [Route("UpdateReady")] // to Saved.
        public ActionResult<string> UpdateReady(int ID, bool Ready)
        {


            try
            {
                var invoiceTable = Db.GetCollection<Invoice>("Invoices");
                var readyinv = invoiceTable.Find(x => x.ID == ID).First();
                if (readyinv != null)
                {
                    readyinv.InEditMode = Ready;
                    if (Ready)
                    {
                        readyinv.InvoiceTimeloglist.Clear();
                        readyinv.InvoiceTimeloglist.Add(string.Format("OrderReady:{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                        invoiceTable.Update(readyinv);
                        return Ok("Success");
                    }
                    else
                    {
                        readyinv.InvoiceTimeloglist.Clear();
                        invoiceTable.Update(readyinv);
                        return Ok("Success");
                    }

                }
                else
                {
                    return Ok("Failure");
                }


            }
            catch (Exception ex)
            {
                LogMyAPI("Failed to Update");
                LogMyAPI(ex.Message.ToString());
                return Ok("Failed to Update");
            }
        }


        [HttpPost]
        [Route("InvoiceReady")]
        public void InvoiceReady(string id)
        {
            try
            {
                LogMyAPI("Invoice Ready");
                var invoiceTable = Db.GetCollection<Invoice>("Invoices");
                var a = invoiceTable.FindOne(x => x.IDstring == id);
                a.InEditMode = !a.InEditMode;
                invoiceTable.Update(a);

            }
            catch (Exception ex)
            {
                LogMyAPI(ex.Message);
            }
        }



        [HttpGet]
        [Route("SearchALLDB")]
        public ActionResult<IEnumerable<Invoice>> SearchALLDB(string search,bool DeepSearch)
        {
            LogMyAPI("Search Started ");
            try
            {
                var combined = new List<Invoice>();
                LogMyAPI("Combined List");

                if (DeepSearch)
                {
                // find all databases with .db extension in the folder DBConnection
                string[] files = Directory.GetFiles(DBConnection.ToLower().Replace("filename=", "").Replace("db.db", ""), "*.db");
                var dbs = files.Where(x => !x.Contains("db.db") && !x.Contains("log"));
                LogMyAPI("Found " + files.Length + " DBs");
                foreach (var item in dbs)
                {
                    var newdb = new LiteDatabase("filename=" + item);
                    if (newdb.GetCollectionNames().Contains("Invoices"))
                    {
                        var searched = newdb.GetCollection<Invoice>("Invoices");
                        combined.AddRange(searched.FindAll().Where(x => ToUnifiedArabic(x.SearchResult).Contains(search)));
                        LogMyAPI(item + " " + "searched.");
                        newdb.Dispose();
                    }
                    else
                    {
                        newdb.Dispose();
                        }
                    }
                    LogMyAPI("Searched All old DBS");
                }
                var currentdb = Db.GetCollection<Invoice>("Invoices");
                LogMyAPI(combined.Count.ToString());
                combined.AddRange(currentdb.FindAll().Where(x => ToUnifiedArabic(x.SearchResult).Contains(search)));
                LogMyAPI(combined.Distinct().Count().ToString());
                return Ok(combined.OrderByDescending(x => x.ID).DistinctBy(x => x.TimeOfSaving));

            }

            catch (Exception ex)
            {
                LogMyAPI(ex.Message);
                return new List<Invoice>();
            }

        }
        [HttpGet]
        [Route("SearchALLDBLoyal")]
        public ActionResult<List<string>> SearchALLDBLoyal()
        {
            LogMyAPI("Search loyalty Started ");
            try
            {
                var combined = new List<Invoice>();
                LogMyAPI("Combined List");

                // find all databases with .db extension in the folder DBConnection

                string[] files = Directory.GetFiles(DBConnection.ToLower().Replace("filename=", "").Replace("db.db", ""), "*.db");
                var dbs = files.Where(x => x != @"c:\db\db.db" && x != @"c:\db\db-log.db");
                LogMyAPI("Found " + files.Length + " DBs");
                try
                {

                    foreach (var item in dbs)
                    {
                        LogMyAPI(item + " " + "Foreach started.");

                        if (item != @"c:\db\db.db")
                        {
                            LogMyAPI(item + " " + "item doesn't equal db.db.");

                            var newdb = new LiteDatabase("filename=" + item);
                            LogMyAPI(item + " " + "created new newdb instance");

                            if (newdb.GetCollectionNames().Contains("Invoices"))
                            {
                                LogMyAPI(item + " " + "Database contains Invoices");
                                var invoices = newdb.GetCollection<Invoice>("Invoices");
                                LogMyAPI(item + " " + "GotInvoiceCollection Invoices");
                                combined.AddRange(invoices.FindAll().Where(x => x.OrderType != "تطبيقات" && x.Status == InvStat.SavedToPOS).ToList());
                                LogMyAPI(item + " " + "AddedRange");
                                combined = combined.DistinctBy(x => x.TimeOfSaving).ToList();
                                LogMyAPI(item + " " + "distinct combined.");
                                newdb.Dispose();
                                LogMyAPI(item + " " + "DisposedDB.");
                            }
                            else
                            {
                                newdb.Dispose();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogMyAPI(ex.Message);

                    throw;
                }

                LogMyAPI("db reached.");
                var invoicesdbdb = Db.GetCollection<Invoice>("Invoices");
                LogMyAPI("GotInvoiceCollection Invoices");
                combined.AddRange(invoicesdbdb.Find(z => z.Status == InvStat.SavedToPOS && z.OrderType != "تطبيقات"));
                LogMyAPI("AddedRange");
                combined = combined.DistinctBy(x => x.TimeOfSaving).ToList();
                LogMyAPI("distinct combined.");


                var loyalCustomers = combined.DistinctBy(x => x.TimeOfSaving)
                    .GroupBy(i => i.CustomerNumber)
                    .Select(g => new { CustomerNumber = g.Key, TotalSales = g.Sum(i => i.InvoicePrice), OrderCount = g.Count() })
                    .OrderByDescending(x => x.TotalSales)
                    .ThenByDescending(x => x.OrderCount)
                    .Select(g => $"TotalSales: {g.TotalSales} | OrderCount: {g.OrderCount} | Customer: {string.Join(",", combined.Where(x => x.CustomerNumber == g.CustomerNumber).Select(x => x.CustomerName).Distinct())} | Number: {g.CustomerNumber} ")
                    .ToList();
                return Ok(loyalCustomers.Take(200));




            }

            catch (Exception ex)
            {
                LogMyAPI(ex.Message);
                return new List<string>();
            }

        }






        [HttpGet]
        [Route("GetByID")]
        public ActionResult<Invoice> GetDraftInvoices(int id)
        {
            try
            {
                var draft = Db.GetCollection<Invoice>("Invoices");
                LogMyAPI("got the invoice # " + " " + id);

                Invoice invoice = draft.FindOne(x => x.ID == id);
                if (invoice == null)
                {
                    LogMyAPI("No Invoice By That ID was found");
                    return NoContent();
                }
                else
                {
                    LogMyAPI("Found Invoice ID:" + invoice.IDstring);
                    return Ok(invoice);
                }
            }
            catch (Exception ex) { LogMyAPI(ex.Message.ToString()); return NoContent(); }

        }
        [HttpGet]
        [Route("GetSections")]
        public ActionResult<List<POSsections>> GetSections()
        {
            try
            {
                LogMyAPI("Loading Sections");
                var s = Db.GetCollection<POSsections>("Sections");
                var S = s.FindAll();
                return Ok(S.ToList());

            }
            catch (Exception ex)
            {
                LogMyAPI(ex.Message.ToString());
                return Ok(new List<POSsections>());
            }
        }

        [HttpGet]
        [Route("GetWhatsappShortcut")]
        public ActionResult<List<WhatsAppShortCut>> WhatsappShortcut()
        {
            try
            {
                LogMyAPI("Getting Whatsapp Shortcuts");
                var cuts = Db.GetCollection<WhatsAppShortCut>("WhatsApp");
                if (cuts.Count() > 0) return Ok(cuts.FindAll().ToList());
                else { return NoContent(); }
            }
            catch (Exception ex) { LogMyAPI(ex.Message.ToString()); return NoContent(); }

        }


        [HttpGet]
        [Route("GetDepartments")]
        public ActionResult<List<POSDepartments>> GetDepartments()
        {
            try
            {
                LogMyAPI("Getting Departments.");
                var s = Db.GetCollection<POSDepartments>("POSDepartment");
                var S = s.FindAll().ToList();
                return Ok(S);
            }
            catch (Exception ex)
            {
                LogMyAPI(ex.Message.ToString());
                return Ok(new List<POSDepartments>());
            }

        }


        [HttpGet]
        [Route("GetMaterialsForSection")]
        public ActionResult<List<POSItems>> GetMaterialsForSection(string section)
        {
            try
            {
                LogMyAPI("Getting materials for section.");
                var materials = Db.GetCollection<POSItems>("Materials");
                List<POSItems> items = materials.Find(x => x.SectionName == section).ToList();
                return items.OrderBy(x => x.order).ToList();
            }
            catch (Exception ex) { LogMyAPI(ex.Message.ToString()); return new List<POSItems>(); }

        }

        [HttpGet]
        [Route("GetAllMaterials")]
        public ActionResult<List<POSItems>> GetAllMaterials()
        {
            try
            {
                LogMyAPI("Loading Materials for settings.");
                var materials = Db.GetCollection<POSItems>("Materials");
                List<POSItems> items = materials.FindAll().ToList();
                return items;
            }
            catch (Exception ex)
            {
                LogMyAPI(ex.Message.ToString());
                return new List<POSItems>();
            }

        }

        [HttpGet]
        [Route("LoadContacts")]
        public ActionResult<Contacts> LoadContacts(string number)
        {
            try
            {
                LogMyAPI("loading Contact");
                var con = Db.GetCollection<Contacts>("Customers");
                var Contact = con.Find(x => x.Number.Replace(" ", "") == number.Replace(" ", "")).Where(z => z.Name.Replace(" ", "") != "");
                if (Contact.Any())
                {
                    return Contact.First();
                }
                else
                {
                    return new Contacts();
                }


            }
            catch (Exception ex)
            {
                LogMyAPI(ex.Message.ToString());
                return new Contacts();
            }
        }

        [HttpGet]
        [Route("SearchContacts")]
        public ActionResult<List<string>> SearchContacts(string name)
        {
            try
            {
                LogMyAPI("loading Contact");
                var con = Db.GetCollection<Contacts>("Customers");
                var Contact = con.Find(x => x.Name.Contains(name)).Select(x => x.Name + ":" + x.Number).ToList();
                return Contact;

            }
            catch (Exception ex)
            {
                LogMyAPI(ex.Message.ToString());
                return new List<string>();
            }
        }
        public string ToUnifiedArabic(string original)
        {
            var Uniefied = new StringBuilder(original);

            string[] alefVariations = new string[] { "آ", "أ", "إ", "ٵ" };
            foreach (string variation in alefVariations)
            {
                Uniefied.Replace(variation, "ا");
            }

            string[] tashkeel = new string[] { "َ", "ً", "ُ", "ٌ", "ِ", "ٍ", "ْ", "ّ" };
            foreach (string mark in tashkeel)
            {
                Uniefied.Replace(mark, "");
            }

            Uniefied.Replace("ة", "ه");
            Uniefied.Replace("ى", "ي");
            Uniefied.Replace("ؤ", "و");

            return Uniefied.ToString();
        }


        [HttpPost]
        [Route("SaveWhatsappShortcut")]
        public ActionResult SaveWhatsappShortcut([FromBody] List<WhatsAppShortCut> list)
        {
            try
            {
                LogMyAPI("Saving Whatsapp Shortcuts");
                var cuts = Db.GetCollection<WhatsAppShortCut>("WhatsApp");
                cuts.DeleteAll();

                list.ForEach(x => cuts.Upsert(x));

                return Ok();

            }
            catch (Exception ex)
            {
                LogMyAPI(ex.Message.ToString());
                return Ok();
            }
        }



        [HttpPost]
        [Route("UpdateInvoice")] // to printed.
        public ActionResult<string> CreatePrintInvoice([FromBody] Invoice inv)
        {


            try
            {
                LogMyAPI(inv.ID.ToString());

                var invoiceTable = Db.GetCollection<Invoice>("Invoices");
                bool Up = invoiceTable.Upsert(inv);
                if (Up)
                {
                    LogMyAPI("Updated Invoice: " + inv.IDstring);
                    return Ok("Updated");

                }
                else
                {
                    LogMyAPI("New Invoice Was Created with ID:" + inv.IDstring);
                    return StatusCode(200);
                }
            }
            catch (Exception ex)
            {
                LogMyAPI(ex.Message.ToString());
                return StatusCode(200);
            }
        }

        [HttpPost]
        [Route("UpdateInvoiceSaved")] // to Saved.
        public ActionResult<string> CreateSavedInvoice([FromBody] Invoice inv)
        {


            try
            {
                LogMyAPI(inv.ID.ToString());

                var invoiceTable = Db.GetCollection<Invoice>("Invoices");
                bool Up = invoiceTable.Update(inv);
                if (Up)
                {
                    LogMyAPI("Updated Invoice to Saved");
                    return Ok("Updated Invoice to Saved");

                }
                else
                {
                    LogMyAPI("Failed to Update");
                    return Ok("Failed to Update");

                }

            }
            catch (Exception ex) { LogMyAPI(ex.Message.ToString()); return Ok("Failed to Update"); }
        }
        [HttpPost]
        [Route("UpdateInvoiceDraft")] // to Saved.
        public ActionResult<string> CreateDraftInvoice([FromBody] Invoice inv, string status)
        {


            try
            {
                LogMyAPI(inv.ID.ToString());

                var invoiceTable = Db.GetCollection<Invoice>("Invoices");
                bool Up = invoiceTable.Update(inv);
                if (Up)
                {
                    LogMyAPI("Updated Invoice to " + status);
                    return Ok("Updated Invoice to " + status);

                }
                else
                {
                    LogMyAPI("Failed to Update");
                    return Ok("Failed to Update");
                }
            }
            catch (Exception ex)
            {
                LogMyAPI("Failed to Update");
                LogMyAPI(ex.Message.ToString());

                return Ok("Failed to Update");
            }
        }

     

        [HttpPost]
        [Route("DeleteInvoice")] // to Saved.
        public ActionResult<bool> DeleteInvoice([FromBody] Invoice inv)
        {


            try
            {
                LogMyAPI(inv.ID.ToString() + " Deleted");
                var invoiceTable = Db.GetCollection<Invoice>("Invoices");
                bool Up = invoiceTable.Update(inv);
                if (Up)
                {
                    LogMyAPI("Deleted Invoice");
                    return Ok(true);
                }
                else
                {
                    LogMyAPI("Failed to Delete");
                    return Ok(false);
                }

            }
            catch (Exception ex)
            {

                LogMyAPI(ex.Message.ToString());
                return Ok(false);

            }
        }

        [HttpPost]
        [Route("SaveContacts")] // to Saved.
        public ActionResult<bool> SaveContacts([FromBody] Contacts contact)
        {

            try
            {
                LogMyAPI("Saving Contact");
                var con = Db.GetCollection<Contacts>("Customers");
                if (contact != null)
                {
                    var oldContact = con.FindOne(x => x.Number == contact.Number);
                    if (oldContact != null)
                    {
                        oldContact.Name = contact.Name;
                        con.Update(oldContact);
                        return Ok(true);

                    }
                    else
                    {
                        con.Upsert(contact);
                        return Ok(true);

                    }



                }
                else { return Ok(false); }


            }
            catch (Exception ex)
            {
                LogMyAPI(ex.Message.ToString());
                return Ok(false);
            }
        }

        [HttpPost]
        [Route("CreateNewInvoice")]
        public ActionResult<string> CreateNewInvoice([FromBody] Invoice inv)
        {
            {
                LogMyAPI("Creating New Invoice");
                var invoiceTable = Db.GetCollection<Invoice>("Invoices");
                try
                {
                    LogMyAPI(" " + " Created and returned");

                    return invoiceTable.Insert(inv).ToString();
                }
                catch (Exception ex)
                {
                    LogMyAPI(ex.Message + ex.Source + "error at Create New Invoice");
                    return invoiceTable.Insert(inv).ToString();


                }

            }

        }


        [HttpPost]
        [Route("UpdateSectionNotes")]
        public ActionResult UpdateSectionNotes([FromBody] POSsections POSsection)
        {
            try
            {
                LogMyAPI("Updating Section notes");
                var Sections = Db.GetCollection<POSsections>("Sections");
                Sections.Update(POSsection);
                return Ok();
            }
            catch (Exception ex) { LogMyAPI(ex.Message.ToString()); return Ok(); }


        }

        [HttpPost]
        [Route("SaveDepartments")]
        public ActionResult SaveDepartments([FromBody] List<POSDepartments> list)
        {
            try
            {
                LogMyAPI("Saving Departments");
                var Deps = Db.GetCollection<POSDepartments>("POSDepartment");
                if (Deps.Count() > 0)
                {
                    Deps.DeleteAll();
                    int c = 0;
                    foreach (POSDepartments deps in list)
                    {
                        var a = new POSDepartments(deps.Name, deps.DefaultPrinter);
                        c = c++;
                        a.ID = c;
                        Deps.Insert(a);

                    }
                    return Ok();
                }
                else
                {
                    int c = 0;

                    foreach (POSDepartments deps in list)

                    {
                        var a = new POSDepartments(deps.Name, deps.DefaultPrinter);
                        c = c++;
                        a.ID = c;
                        Deps.Insert(a);

                    }
                    return Ok();
                }

            }
            catch (Exception ex) { LogMyAPI(ex.Message.ToString()); return Ok(); }


        }


        [HttpPost]
        [Route("UpdateSectionMaterials")]
        public ActionResult UpdateSectionMaterials([FromBody] List<POSItems> list, [FromQuery] string section)
        {
            try
            {
                LogMyAPI("Updating materials in section " + section);
                var materials = Db.GetCollection<POSItems>("Materials");
                materials.Find(x => x.SectionName == section).ToList().ForEach(x => { x.SectionName = "بدون قسم"; materials.Update(x); });
                list.ForEach(x => { order += 1; x.order = order; x.SectionName = section; materials.Update(x); });
                return Ok();
            }
            catch (Exception ex) { LogMyAPI(ex.Message.ToString()); return Ok(); }

        }

        [HttpPost]
        [Route("UpdateSections")]
        public ActionResult UpdateSections([FromBody] List<POSsections> list)
        {
            try
            {

                LogMyAPI("Updating Sections");

                var mat = Db.GetCollection<POSItems>("Materials");
                var sectionTable = Db.GetCollection<POSsections>("Sections");
                sectionTable.DeleteAll();
                list.ForEach(x => { x.ID = sectionTable.Count() + 1; sectionTable.Insert(x); });
                //delete all groups
                if (list.Count == 0)
                {
                    sectionTable.DeleteAll();
                }
                return Ok();
            }
            catch (Exception ex) { LogMyAPI(ex.Message.ToString()); return Ok(); }
        }

        [HttpPost]
        [Route("UpdateMatSections")]
        public ActionResult UpdateMatSections([FromBody] List<POSItems> list)
        {
            try
            {
                LogMyAPI("Updating Material Sections");
                var materials = Db.GetCollection<POSItems>("Materials");
                list.ForEach(x => materials.Update(x));

                return Ok();
            }
            catch (Exception ex) { LogMyAPI(ex.Message.ToString()); return Ok(); }
        }

        [HttpPost]
        [Route("SaveOrUpdateItems")]
        public ActionResult SaveOrUpdateItems([FromBody] List<POSItems> list)
        {
            try
            {
                LogMyAPI("Saving list of materials");
                var mat = Db.GetCollection<POSItems>("Materials");
                var deleted = mat.FindAll().Except(list);
                deleted.ToList().ForEach(x => mat.Delete(x.ID));
                list.ForEach(x => mat.Upsert(x));
                return Ok();
            }
            catch (Exception ex)
            {


                LogMyAPI(ex.Message.ToString());
                return Ok();
            }

        }
        // HungerStation, TryOrder.
        [HttpPost]
        [Route("SaveApps")]
        public ActionResult SaveOrUpsertApps(AppSets Name)
        {
            try
            {
                LogMyAPI("Saving Apps Materials");
                var mat = Db.GetCollection<AppSets>("Apps");

                mat.Upsert(Name);

                return Ok();
            }
            catch (Exception ex)
            {
                LogMyAPI(ex.Message.ToString());
                return Ok();
            }
        }
        [HttpGet]
        [Route("LoadAllApps")]
        public ActionResult<List<AppSets>> LoadAllApps()
        {
            try
            {
                LogMyAPI("Saving Apps Materials");
                var mat = Db.GetCollection<AppSets>("Apps");
                return Ok(mat.FindAll().Where(x => x.Name != ""));
            }
            catch (Exception ex)
            {
                LogMyAPI(ex.Message.ToString());
                return Ok();
            }
        }
        [HttpGet]
        [Route("LoadApp")]
        public ActionResult<AppSets> LoadOneApps(string name)
        {
            try
            {
                LogMyAPI("Saving Apps Materials");
                var mat = Db.GetCollection<AppSets>("Apps");
                return Ok(mat.FindOne(x => x.Name == name));
            }
            catch (Exception ex)
            {
                LogMyAPI(ex.Message.ToString());
                return Ok();
            }
        }

        [HttpPost]
        [Route("DeleteApps")]
        public ActionResult DeleteAllApps()
        {
            try
            {
                LogMyAPI("Delete all Apps Materials");
                var mat = Db.GetCollection<AppSets>("Apps");
                mat.DeleteAll();
                return Ok();
            }
            catch (Exception ex)
            {
                LogMyAPI(ex.Message.ToString());
                return Ok();
            }
        }

    }


}

