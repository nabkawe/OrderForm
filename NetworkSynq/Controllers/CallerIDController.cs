using LiteDB;
using Microsoft.AspNetCore.Mvc;
using sharedCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace NetworkSynq.Controllers
{
    public class CallerIDController : Controller
    {

        public static readonly LiteDatabase db = new(Helpers.ConnectionStringHelper.GetConnectionString());



        [HttpPost]
        [Route("LogPhone")] // to Saved.
        public ActionResult<bool> LogPhone([FromBody] PhoneLog phoneLog)
        {

            try
            {
                LoadDBController.LogMyAPI("Saving Contact");
                var phlog = db.GetCollection<PhoneLog>("PhoneLog");
                if (phoneLog != null)
                {
                        phlog.Insert(phoneLog);
                        return Ok(true);
                }
                else { return Ok(false); }


            }
            catch (Exception ex)
            {
                LoadDBController.LogMyAPI("Exception: " + ex.Message);

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
                    return con.FindAll().TakeLast(max).ToList();
                }
                else
                {
                    return con.FindAll().TakeLast(20).ToList();
                }
            }
            catch (Exception)
            {

                return new List<PhoneLog>();
            }
        }





    }
}
