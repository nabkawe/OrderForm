using Microsoft.AspNetCore.Mvc;
using LiteDB;
using sharedCode;
using static System.Collections.Specialized.BitVector32;
using System.Configuration;

namespace NetworkSynq.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class LoadDBController : ControllerBase
    {
        static IConfiguration conf = (new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build());
        public static string DBConnection = conf["ConnectionString"].ToString();

        static readonly LiteDatabase db = new(DBConnection);




        
        [HttpGet]
        [Route("GetList")]
        public ActionResult<IEnumerable<Invoice>> GetDraftInvoices(string inv)
        {
            var draft = db.GetCollection<Invoice>("Invoices");
            Console.WriteLine("Got List of " + inv + " Invoices");
            if (inv == "draft")
            {
                var draftInv = draft.Find(x => x.Status == InvStat.Draft && x.InvoiceItems.Count > 0).ToList();
                Console.WriteLine(draftInv.Count.ToString());
                if (draftInv.Count > 0)
                {

                    return Ok(draftInv);

                }
                else return NoContent();
            }
            else if (inv == "saved")
            {
                var draftinv = draft.Query().Where(x => x.Status == InvStat.Deleted || x.Status == InvStat.SavedToPOS).OrderByDescending(x => x.ID).Limit(200);

                if (draftinv.Count() > 0)
                {
                    return Ok(draftinv.ToList());
                }
                else return NoContent();
            }
            else if (inv == "printed")
            {

                var draftinv = draft.Find(x => x.Status == InvStat.Printed).Take(100).ToList().OrderByDescending(x => x.TimeinArabic == "ÇáÂä").ThenBy(x => x.TimeOfInv);
                if (draftinv.Count() > 0) return Ok(draftinv);
                else return NoContent();

            }
            else if (inv == "allsaved")
            {
                var draftInv = draft.Find(x => x.Status == InvStat.SavedToPOS || x.Status == InvStat.Deleted);
                var d = draftInv.OrderByDescending(i => Convert.ToInt32(i.IDstring)).ToList();
                return Ok(d);

            }
            else if (inv == "draft")
            {
                var d = draft.Query().Where(x => x.Status == InvStat.Draft && x.InvoiceItems.Count > 0).Limit(100).ToList();
                return Ok(d);
            }
            else return NoContent();


        }

        [HttpGet]
        [Route("GetByID")]
        public ActionResult<Invoice> GetDraftInvoices(int id)
        {
            var draft = db.GetCollection<Invoice>("Invoices");

            Invoice invoice = draft.FindOne(x => x.ID == id);
            if (invoice == null)
            {
                Console.WriteLine("No Invoice By That ID was found");
                return NoContent();
            }
            else
            {
                Console.WriteLine("Found Invoice ID:" + invoice.IDstring);
                return Ok(invoice);
            }

        }
        [HttpGet]
        [Route("GetSections")]
        public ActionResult<List<POSsections>> GetSections()
        {
            Console.WriteLine("Loading Sections and Items.");
            var s = db.GetCollection<POSsections>("Sections");
            var S = s.FindAll();
            return Ok(S.ToList());
                       
        }
       
        [HttpGet]
        [Route("GetMaterialsForSection")]
        public ActionResult<List<POSItems>> GetMaterialsForSection(string section)
        {
            Console.WriteLine("Loading Sections and Items.");
            var materials = db.GetCollection<POSItems>("Materials");
            List<POSItems> items = materials.Find(x => x.SectionName == section).ToList();
            return items.OrderBy(x => x.order).ToList();

        }


        [HttpPost]
        [Route("UpdateInvoice")] // to printed.
        public ActionResult<string> CreatePrintInvoice([FromBody] Invoice inv)
        {


            Console.WriteLine(inv.ID.ToString());

            var invoiceTable = db.GetCollection<Invoice>("Invoices");
            bool Up = invoiceTable.Upsert(inv);
            if (Up)
            {
                Console.WriteLine("Updated Invoice: " + inv.IDstring);
                return Ok("Updated");

            }
            else
            {
                Console.WriteLine("New Invoice Was Created with ID:" + inv.IDstring);
                return StatusCode(200);
            }
        }

        [HttpPost]
        [Route("UpdateInvoiceSaved")] // to Saved.
        public ActionResult<string> CreateSavedInvoice([FromBody] Invoice inv)
        {


            Console.WriteLine(inv.ID.ToString());

            var invoiceTable = db.GetCollection<Invoice>("Invoices");
            bool Up = invoiceTable.Update(inv);
            if (Up)
            {
                Console.WriteLine("Updated Invoice to Saved");
                return Ok("Updated Invoice to Saved");

            }
            else
            {
                Console.WriteLine("Failed to Update");
                return Ok("Failed to Update");

            }
        }

        [HttpPost]
        [Route("UpdateInvoiceDraft")] // to Saved.
        public ActionResult<string> CreateDraftInvoice([FromBody] Invoice inv)
        {


            Console.WriteLine(inv.ID.ToString());

            var invoiceTable = db.GetCollection<Invoice>("Invoices");
            bool Up = invoiceTable.Update(inv);
            if (Up)
            {
                Console.WriteLine("Updated Invoice to Draft");
                return Ok("Updated Invoice to Draft");

            }
            else
            {
                Console.WriteLine("Failed to Update");
                return Ok("Failed to Update");

            }
        }

        [HttpPost]
        [Route("DeleteInvoice")] // to Saved.
        public ActionResult<bool> DeleteInvoice([FromBody] Invoice inv)
        {


            Console.WriteLine(inv.ID.ToString());
            var invoiceTable = db.GetCollection<Invoice>("Invoices");
            bool Up = invoiceTable.Update(inv);
            if (Up)
            {
                Console.WriteLine("Deleted Invoice");
                return Ok(true);
            }
            else
            {
                Console.WriteLine("Failed to Delete");
                return Ok(false);
            }
        }

        [HttpPost]
        [Route("SaveContacts")] // to Saved.
        public ActionResult<bool> SaveContacts([FromBody] Contacts contact)
        {

            var con = db.GetCollection<Contacts>("Customers");
            if (contact != null)
            {
                var oldContact = con.FindOne(x => x.Number == contact.Number);
                if (oldContact != null)
                {
                    oldContact.Name = contact.Name;
                    con.Update(oldContact);
                }
                else con.Upsert(contact);
            }

            return Ok(true);
        }

        [HttpGet]
        [Route("LoadContacts")]
        public ActionResult<Contacts> LoadContacts(string number)
        {
            var con = db.GetCollection<Contacts>("Customers");
            Contacts Contact = con.FindOne(x => x.Number == number);
            return Contact;
        } 

        [HttpPost]
        [Route("CreateNewInvoice")]
        public ActionResult<bool> CreateNewInvoice([FromBody]Invoice inv)
        {
            {
                var invoiceTable = db.GetCollection<Invoice>("Invoices");
                try
                {
                    invoiceTable.Insert(inv);
                    return  Ok(true);
                }
                catch (Exception)
                {
                    // invoiceTable.Update(inv);
                    return Ok(false);
                }
            }

        }

        [HttpGet]
        [Route("AreYouAlive")]
        public ActionResult Alive()
        {
            Console.WriteLine("Yes,I'm Alive");
            return Ok();
        }
        
        [HttpGet]
        [Route("InvoiceCount")]
        public ActionResult<int> InvoiceCount()
        {
            Console.WriteLine("Getting Invoice Count");
            try
            {
                
                    var s = db.GetCollection<Invoice>("Invoices");
                    int S = s.Max(x => x.ID);
                    if (S == 0)
                    {
                        return Ok(1);
                    }
                    else return Ok(S);
                
            }
            catch (Exception)
            {
                    var s = db.GetCollection<Invoice>("Invoices");
                    if (s.Count() != 0)
                    {
                        int S = s.Max(x => x.ID);
                        return Ok(S);
                    }
                    else return Ok(1);

                }

            }
        

        }

        //[HttpGet]
        //[Route("GetSectionCommentsList")]
        //public ActionResult<List<POSsections>> GetSections(POSItems PosItem) //for Fast Comments
        //{
        //    var sectionTable = db.GetCollection<POSsections>("Sections");
        //    List<POSsections> s = sectionTable.FindAll().ToList();
        //    List<POSsections> result = new List<POSsections>();
        //    foreach (POSsections ss in s)
        //    {
        //        var materials = db.GetCollection<POSItems>("Materials");
        //        List<POSItems> items = materials.Find(x => x.SectionName == PosItem.SectionName).ToList();
        //        return items.OrderBy(x => x.order).ToList();

        //        foreach (var a in GetItemsForSection(ss.Name))
        //        {
        //            if (a.Name == item.Name)
        //            {
        //                result.Add(ss);
        //            }
        //        }
        //    }
        //    return result;
        //}


}

