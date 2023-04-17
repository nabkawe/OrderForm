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

namespace NetworkSynq.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LoadDBController : ControllerBase
    {



        static readonly IConfiguration conf = (new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build());
        private readonly static string DBConnection = conf["ConnectionString"].ToString();
        public static readonly LiteDatabase db = new(DBConnection);
        static readonly string LogFile = @"C:\db";




        //private static  LiteDatabase db = new LiteDatabase(DBConfig.GetDBstring());

        [HttpGet]
            [Route("AreYouAlive")]
            public ActionResult<bool> Alive()
            {
            try
            {
                Console.Write("Yes,I'm Alive");

                return Ok(true);
                }
                catch (System.Exception)
                {

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

                    var s = db.GetCollection<Invoice>("Invoices");
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

                    var s = db.GetCollection<Invoice>("Invoices");
                    if (s.Count() != 0)
                    {
                        int S = s.Max(x => x.ID);
                        return Ok(S);
                    }
                    else return Ok(1);

                }


            }

            public static void LogMyAPI(string text)
            {
                try
                {
                    using (System.IO.StreamWriter w = new System.IO.StreamWriter(LogFile + @"\log.text", true))
                    {
                        w.WriteLine(text);
                    }
                }
                catch (Exception)
                {

                }

            }

            [HttpGet]
            [Route("GetList")]
            public ActionResult<IEnumerable<Invoice>> GetDraftInvoices(string inv)
            {
                try
                {
                    var draft = db.GetCollection<Invoice>("Invoices");
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
                        var draftinv = draft.Query().Where(x => x.Status == InvStat.Deleted || x.Status == InvStat.SavedToPOS).OrderByDescending(x => x.ID).Limit(200);

                        if (draftinv.Count() > 0)
                        {
                            return Ok(draftinv.ToList());
                        }
                        else return Ok(new List<Invoice>());
                    }
                    else if (inv == "printed")
                    {

                        var draftinv = draft.Find(x => x.Status == InvStat.Printed).Take(100).ToList().OrderByDescending(x => x.TimeinArabic == "����").ThenBy(x => x.TimeOfInv);
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
                    else
                    {

                        {
                            var draftInv = draft.Find(x => x.Status == InvStat.SavedToPOS || x.Status == InvStat.Deleted).Where(x => x.SearchResult.Contains(inv));
                            var d = draftInv.OrderByDescending(i => Convert.ToInt32(i.IDstring)).ToList();
                            return Ok(d);
                        }
                    }
                }
                catch (Exception)
                {
                    return new List<Invoice>();
                }

            }

            [HttpGet]
            [Route("GetByID")]
            public ActionResult<Invoice> GetDraftInvoices(int id)
            {
                try
                {
                    var draft = db.GetCollection<Invoice>("Invoices");
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
                catch (Exception)
                {

                    return NoContent();
                }

            }
            [HttpGet]
            [Route("GetSections")]
            public ActionResult<List<POSsections>> GetSections()
            {
                try
                {
                    LogMyAPI("Loading Sections");
                    var s = db.GetCollection<POSsections>("Sections");
                    var S = s.FindAll();
                    return Ok(S.ToList());

                }
                catch (Exception)
                {

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
                    var cuts = db.GetCollection<WhatsAppShortCut>("WhatsApp");
                    if (cuts.Count() > 0) return Ok(cuts.FindAll().ToList());
                    else { return NoContent(); }
                }
                catch (Exception)
                {

                    return NoContent();
                }

            }


            [HttpGet]
            [Route("GetDepartments")]
            public ActionResult<List<POSDepartments>> GetDepartments()
            {
                try
                {
                    LogMyAPI("Getting Departments.");
                    var s = db.GetCollection<POSDepartments>("POSDepartment");
                    var S = s.FindAll().ToList();
                    return Ok(S);
                }
                catch (Exception)
                {

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
                    var materials = db.GetCollection<POSItems>("Materials");
                    List<POSItems> items = materials.Find(x => x.SectionName == section).ToList();
                    return items.OrderBy(x => x.order).ToList();
                }
                catch (Exception)
                {

                    return new List<POSItems>();
                }

            }

            [HttpGet]
            [Route("GetAllMaterials")]
            public ActionResult<List<POSItems>> GetAllMaterials()
            {
                try
                {
                    LogMyAPI("Loading Materials for settings.");
                    var materials = db.GetCollection<POSItems>("Materials");
                    List<POSItems> items = materials.FindAll().ToList();
                    return items;
                }
                catch (Exception)
                {

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
                    var con = db.GetCollection<Contacts>("Customers");
                    Contacts Contact = con.FindOne(x => x.Number.Replace(" ","") == number.Replace(" ", ""));
                    return Contact;

                }
                catch (Exception)
                {

                    return new Contacts();
                }
            }



            [HttpPost]
            [Route("SaveWhatsappShortcut")]
            public ActionResult SaveWhatsappShortcut([FromBody] List<WhatsAppShortCut> list)
            {
                try
                {
                    LogMyAPI("Saving Whatsapp Shortcuts");
                    var cuts = db.GetCollection<WhatsAppShortCut>("WhatsApp");
                    cuts.DeleteAll();

                    list.ForEach(x => cuts.Upsert(x));

                    return Ok();

                }
                catch (Exception)
                {

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

                    var invoiceTable = db.GetCollection<Invoice>("Invoices");
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
                catch (Exception)
                {

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

                    var invoiceTable = db.GetCollection<Invoice>("Invoices");
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
                catch (Exception)
                {
                    return Ok("Failed to Update");

                }
            }
            [HttpPost]
            [Route("UpdateInvoiceDraft")] // to Saved.
            public ActionResult<string> CreateDraftInvoice([FromBody] Invoice inv, string status)
            {


                try
                {
                    LogMyAPI(inv.ID.ToString());

                    var invoiceTable = db.GetCollection<Invoice>("Invoices");
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
                catch (Exception)
                {
                    LogMyAPI("Failed to Update");

                    return Ok("Failed to Update");
                }
            }

            [HttpPost]
            [Route("UpdateReady")] // to Saved.
            public ActionResult<string> UpdateReady(int ID, bool Ready)
            {


                try
                {
                    var invoiceTable = db.GetCollection<Invoice>("Invoices");
                    var readyinv = invoiceTable.Find(x => x.ID == ID).First();
                    if (readyinv != null)
                    {
                        readyinv.InEditMode = Ready;
                        invoiceTable.Update(readyinv);
                        return Ok("Success");
                    }
                    else
                    {
                        return Ok("Failure");
                    }


                }
                catch (Exception)
                {
                    LogMyAPI("Failed to Update");

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
                    var invoiceTable = db.GetCollection<Invoice>("Invoices");
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
                catch (Exception)
                {
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
                    var con = db.GetCollection<Contacts>("Customers");
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
                catch (Exception)
                {

                    return Ok(false);
                }
            }

            [HttpPost]
            [Route("CreateNewInvoice")]
            public ActionResult<string> CreateNewInvoice([FromBody] Invoice inv)
            {
                {
                    LogMyAPI("Creating New Invoice");
                    var invoiceTable = db.GetCollection<Invoice>("Invoices");
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
                    var Sections = db.GetCollection<POSsections>("Sections");
                    Sections.Update(POSsection);
                    return Ok();
                }
                catch (Exception)
                {
                    return Ok();

                }


            }

            [HttpPost]
            [Route("SaveDepartments")]
            public ActionResult SaveDepartments([FromBody] List<POSDepartments> list)
            {
                try
                {
                    LogMyAPI("Saving Departments");
                    var Deps = db.GetCollection<POSDepartments>("POSDepartment");
                    if (Deps.Count() > 0)
                    {
                        Deps.DeleteAll();
                        int c = 0;
                        foreach (POSDepartments deps in list)
                        {
                            POSDepartments a = new POSDepartments(deps.Name, deps.DefaultPrinter);
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
                            POSDepartments a = new POSDepartments(deps.Name, deps.DefaultPrinter);
                            c = c++;
                            a.ID = c;
                            Deps.Insert(a);

                        }
                        return Ok();
                    }

                }
                catch (Exception)
                {
                    return Ok();
                }


            }

            static int order = 0;
            [HttpPost]
            [Route("UpdateSectionMaterials")]
            public ActionResult UpdateSectionMaterials([FromBody] List<POSItems> list, [FromQuery] string section)
            {
                try
                {
                    LogMyAPI("Updating materials in section " + section);
                    var materials = db.GetCollection<POSItems>("Materials");
                    materials.Find(x => x.SectionName == section).ToList().ForEach(x => { x.SectionName = "���� ���"; materials.Update(x); });
                    list.ForEach(x => { order += 1; x.order = order; x.SectionName = section; materials.Update(x); });
                    return Ok();
                }
                catch (Exception)
                {

                    return Ok();
                }

            }

            [HttpPost]
            [Route("UpdateSections")]
            public ActionResult UpdateSections([FromBody] List<POSsections> list)
            {
                try
                {

                    LogMyAPI("Updating Sections");

                    var mat = db.GetCollection<POSItems>("Materials");
                    var sectionTable = db.GetCollection<POSsections>("Sections");
                    sectionTable.DeleteAll();
                    list.ForEach(x => { x.ID = sectionTable.Count() + 1; sectionTable.Insert(x); });
                    //delete all groups
                    if (list.Count == 0)
                    {
                        sectionTable.DeleteAll();
                    }
                    return Ok();
                }
                catch (Exception)
                {

                    return Ok();
                }
            }

            [HttpPost]
            [Route("UpdateMatSections")]
            public ActionResult UpdateMatSections([FromBody] List<POSItems> list)
            {
                try
                {
                    LogMyAPI("Updating Material Sections");
                    var materials = db.GetCollection<POSItems>("Materials");
                    list.ForEach(x => materials.Update(x));

                    return Ok();
                }
                catch (Exception)
                {
                    return Ok();

                }
            }

            [HttpPost]
            [Route("SaveOrUpdateItems")]
            public ActionResult SaveOrUpdateItems([FromBody] List<POSItems> list)
            {
                try
                {
                    LogMyAPI("Saving list of materials");
                    var mat = db.GetCollection<POSItems>("Materials");
                    var deleted = mat.FindAll().Except(list);
                    deleted.ToList().ForEach(x => mat.Delete(x.ID));
                    list.ForEach(x => mat.Upsert(x));
                    return Ok();
                }
                catch (Exception)
                {
                    return Ok();
                }

            }



        }


    }

