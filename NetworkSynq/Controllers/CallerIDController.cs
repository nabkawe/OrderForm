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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NetworkSynq.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CallerIDController : Controller
    {


        //http://192.168.1.5:5000/CallerID/LogPhone?PhoneNumber=0551987609


        [HttpPost]
        [Route("LogPhone")] // to Saved.
        public ActionResult<bool> LogPhone(string PhoneNumber)
        {
            LoadDBController.LogMyAPI(PhoneNumber);
            try
            {
                LoadDBController.LogMyAPI("Saving Contact");
                var phlog = LoadDBController.Db.GetCollection<PhoneLog>("PhoneLog");
                LoadDBController.LogMyAPI("Collection Init");
                var phonelog = PhoneLog.NewPhoneLog(PhoneNumber);
                LoadDBController.LogMyAPI("PhoneLog Created");
                LoadDBController.LogMyAPI("loading Contact");
                var con = LoadDBController.Db.GetCollection<Contacts>("Customers");
                LoadDBController.LogMyAPI("loaded Contacts");
                LoadDBController.LogMyAPI("finding");
                Contacts Contact = new();
                if (con.Exists(x => x.Number.Replace(" ", "") == PhoneNumber.Replace(" ", "")))
                {
                    Contact = con.Find(x => x.Number.Replace(" ", "") == PhoneNumber.Replace(" ", "")).First();
                    phonelog.CustomerName = Contact.Name;
                }
                else
                {
                    phonelog.CustomerName = "رقم جديد";
                }
                                
                
                LoadDBController.LogMyAPI("Compared");
                if (phonelog != null)
                {
                    LoadDBController.LogMyAPI("phoneLog wasn't null ");
                    phlog.Insert(phonelog);
                    return Ok(true);
                }
                else { LoadDBController.LogMyAPI("phoneLog wasn null "); return Ok(false); }


            }
            catch (Exception ex)
            {
                LoadDBController.LogMyAPI("PhoneLog Exception: " +  ex.ToString() + ex.Message);

                return Ok(false);
            }
        }

        [HttpGet]
        [Route("LoadPhoneLog")]
        public ActionResult<List<PhoneLog>> LoadPhoneLog(int max)
        {
            try
            {
                LoadDBController.LogMyAPI("loading PhoneLog");
                var con = LoadDBController.Db.GetCollection<PhoneLog>("PhoneLog");
                if (max > 0)
                {
                    LoadDBController.LogMyAPI("max > 0 ");
                    return con.FindAll().TakeLast(max).ToList();
                }
                else
                {
                    LoadDBController.LogMyAPI("Max was not");
                    return con.FindAll().TakeLast(20).ToList();
                }
            }
            catch (Exception)
            {
                LoadDBController.LogMyAPI("no data were found ");
                return new List<PhoneLog>();
            }
        }





    }
}
