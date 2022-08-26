using Microsoft.AspNetCore.Mvc;
using LiteDB;
using sharedCode;
namespace NetworkSynq.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class LoadDBController : ControllerBase
    {
        static readonly LiteDatabase db = new("filename=c:/db/db.db;connection=shared");


        [HttpGet("{Draft}")]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetDraftInvoices(string Draft)
        {
            var draft = db.GetCollection<Invoice>("Invoices");
            Console.WriteLine(Draft);
            if (Draft == "Draft")
            {
                var draftInv = draft.Find(x => x.Status == InvStat.Draft && x.InvoiceItems.Count > 0).ToList();
                if (draftInv.Count > 0)
                {
                    return await Task.FromResult(Ok(draftInv));

                }
                else return NoContent();
            }
            else if (Draft == "Saved")
            {
                var draftInv = draft.Find(x => x.Status == InvStat.Deleted || x.Status == InvStat.SavedToPOS, draft.Find(y => y.Status == InvStat.SavedToPOS || y.Status == InvStat.Deleted).Count() - 200, 200);



                if (draftInv.Count() > 0)
                {
                    return await Task.FromResult(Ok(draftInv.OrderByDescending(x => Convert.ToInt32(x.POSInvoiceNumber)).ToList()));
                }
                else return NoContent();
            }
            else
            {

                var draftInv = draft.Find(x => x.Status == InvStat.Printed);
                var d = draftInv.OrderBy(x => x.TimeOfInv).ToList();
                return await Task.FromResult(Ok(d));

            }


        }

        [HttpGet]
        [Route("GetByID/{ID}")]
        public async Task<ActionResult<Invoice>> GetDraftInvoices(int ID)
        {
            var draft = db.GetCollection<Invoice>("Invoices");

            Invoice invoice = draft.FindOne(x => x.ID == ID);
            if (invoice == null)
            {
                return NoContent();
            }
            else return await Task.FromResult(Ok(invoice));

        }


        [HttpPut]
        [Route("GetByID/{ID}")]
        public async Task<ActionResult> CreateDraftInvoice(Invoice inv)
        {
            var invoiceTable = db.GetCollection<Invoice>("Invoices");
            if (invoiceTable.Upsert(inv))
            {
                return await Task.FromResult(Ok(inv));
            }
            else
            {
                return await Task.FromResult(NoContent());
            }

        }




    }



}
