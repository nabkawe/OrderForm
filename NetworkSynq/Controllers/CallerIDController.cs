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
    public class CallerIDController : Controller
    {

        static readonly IConfiguration conf = (new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build());
        private readonly static string DBConnection = conf["ConnectionString"].ToString();
        public static readonly LiteDatabase db = new(DBConnection);
        static readonly string LogFile = @"C:\db";




        [HttpPost]
        [Route("LogPhone")] // to Saved.
        public ActionResult<bool> LogPhone([FromBody] PhoneLog phoneLog)
        {
            LoadDBController.LogMyAPI(phoneLog.PhoneNumber);
            try
            {
                LoadDBController.LogMyAPI("Saving Contact");
                var phlog = db.GetCollection<PhoneLog>("PhoneLog");
                if (phoneLog != null)
                {
                    LoadDBController.LogMyAPI("phoneLog wasn't null ");
                    phlog.Insert(phoneLog);
                    return Ok(true);
                }
                else { LoadDBController.LogMyAPI("phoneLog wasn null "); return Ok(false); }


            }
            catch (Exception ex)
            {
                LoadDBController.LogMyAPI("PhoneLog Exception: " + ex.Message);

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
                var con = db.GetCollection<PhoneLog>("PhoneLog");
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
