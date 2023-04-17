using LiteDB;
using RestSharp;
using sharedCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Windows.ApplicationModel.Contacts;
using Windows.UI.WebUI;
using MessageBox = System.Windows.Forms.MessageBox;

namespace OrderForm
{
    public static class dbQ
    {

        //static LiteDatabase db = new LiteDatabase(Properties.Settings.Default.DBConnection);

        public static LiteDatabase Connect()
        {

            var db = new LiteDatabase(Properties.Settings.Default.DBConnection);
            //var db = new LiteDatabase(@"Filename=C:\db\db.db;Connection=shared");

            return db;
        }
        public static Contacts LoadContacts(string number)
        {
            if (Properties.Settings.Default.Api_On)
            {

                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Properties.Settings.Default.API_Connection + "/LoadDB/LoadContacts");
                var request = new RestRequest();
                request.AddParameter("number", number);
                RestResponse response = client.Get(request);
                if (response != null)
                {
                    if (response.StatusCode.ToString() == "OK")
                    {
                        {
                            var i = Newtonsoft.Json.JsonConvert.DeserializeObject<Contacts>(response.Content.ToString());
                            return i;
                        }
                    }
                    else return new Contacts() { Name = " ", Number = "" };
                }
                else return new Contacts() { Name = " ", Number = "" };


            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

                {
                    var con = db.GetCollection<Contacts>("Customers");
                    Contacts Con = con.FindOne(x => x.Number == number);
                    return Con;
                }
            }
        }
        public static void SaveContacts(Contacts contact)
        {
            if (Properties.Settings.Default.Api_On)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Properties.Settings.Default.API_Connection + "/LoadDB/SaveContacts");
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.RequestFormat = RestSharp.DataFormat.Json;
                string i = Newtonsoft.Json.JsonConvert.SerializeObject(contact, Newtonsoft.Json.Formatting.Indented);// <Invoice>(item);
                request.AddParameter("application/json", i, ParameterType.RequestBody);
                var response = client.Post(request);
            }
            else
            {

                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

                {
                    var Deps = db.GetCollection<Contacts>("Customers");
                    if (contact != null)
                    {
                        var oldContact = Deps.FindOne(x => x.Number == contact.Number);
                        if (oldContact != null)
                        {
                            oldContact.Name = contact.Name;
                            Deps.Update(oldContact);
                        }
                        else Deps.Upsert(contact);
                    }
                }
            }
        }

        public static List<PhoneLog> loadPhoneBook(int max = 20)
        {
            if (Properties.Settings.Default.Api_On)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Properties.Settings.Default.API_Connection + "/CallerID/LoadPhoneLog");
                var request = new RestRequest();
                request.AddParameter("max", max);
                var response = client.Get(request);

                if (response != null)
                {
                    if (response.StatusCode.ToString() == "OK")
                    {
                        {
                            var phoneLog = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PhoneLog>>(response.Content.ToString());
                            return phoneLog;
                        }
                    }
                    else return new List<PhoneLog>();
                }
                else return new List<PhoneLog>();

            }
            else
            {
                return new List<PhoneLog>();
            }
        }



        public static void UpdateSectionNotes(POSsections sect)
        {
            if (Properties.Settings.Default.Api_On)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Properties.Settings.Default.API_Connection + "/LoadDB/UpdateSectionNotes");
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.RequestFormat = RestSharp.DataFormat.Json;
                string i = Newtonsoft.Json.JsonConvert.SerializeObject(sect, Newtonsoft.Json.Formatting.Indented);// 
                request.AddParameter("application/json", i, ParameterType.RequestBody);
                var response = client.Post(request);

            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

                {
                    var Deps = db.GetCollection<POSsections>("Sections");
                    Deps.Update(sect);

                }
            }
        }

        public static void SaveDepartments(List<POSDepartments> list)
        {


            if (Properties.Settings.Default.Api_On)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Properties.Settings.Default.API_Connection + "/LoadDB/SaveDepartments");
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.RequestFormat = RestSharp.DataFormat.Json;
                string i = Newtonsoft.Json.JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);// 
                request.AddParameter("application/json", i, ParameterType.RequestBody);
                var response = client.Post(request);

            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

                {
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
                    }

                }
            }
        }



        public static List<POSDepartments> LoadDepartments()
        {
            if (Properties.Settings.Default.Api_On)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Properties.Settings.Default.API_Connection + "/LoadDB/GetDepartments");
                var request = new RestRequest();
                RestResponse response = client.Get(request);
                if (response != null)
                {
                    if (response.StatusCode.ToString() == "OK")
                    {
                        var i = Newtonsoft.Json.JsonConvert.DeserializeObject<List<POSDepartments>>(response.Content.ToString());
                        return i;
                    }
                    else return new List<POSDepartments>();


                }
                else return new List<POSDepartments>();


            }
            else
            {
                try
                {
                    using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

                    {
                        var Deps = db.GetCollection<POSDepartments>("POSDepartment");
                        List<POSDepartments> a = Deps.FindAll().ToList();
                        return a;
                    }
                }
                catch (Exception)
                {

                    return new List<POSDepartments>();
                }
            }
        }

        public static void DefaultPrinters(string printer)
        {

            Properties.Settings.Default.DefaultPrinter = printer;
            Properties.Settings.Default.Save();
        }
        public static void CashierPrinter(string printer)
        {
            Properties.Settings.Default.CashierPrinter = printer;
            Properties.Settings.Default.Save();

        }
        public static string DefaultPrinters()
        {
            return Properties.Settings.Default.DefaultPrinter;
        }
        public static string CashierPrinter()
        {
            return Properties.Settings.Default.CashierPrinter;
        }
        internal static void DeleteItemSections(List<POSItems> list)
        {
            UpdateAllItemsPrinters(list);
        }
        public static void UpdateAllItemsPrinters(List<POSItems> list)
        {
            if (Properties.Settings.Default.Api_On)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Properties.Settings.Default.API_Connection + "/LoadDB/UpdateMatSections");
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.RequestFormat = RestSharp.DataFormat.Json;
                string i = Newtonsoft.Json.JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);// 
                request.AddParameter("application/json", i, ParameterType.RequestBody);
                var response = client.Post(request);


            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

                {
                    var materials = db.GetCollection<POSItems>("Materials");
                    list.ForEach(x => materials.Update(x));
                }
            }

        }

        public static POSsections PrinterGetSectionMaterial(string selected)
        {
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

            {
                var sectionTable = db.GetCollection<POSsections>("Sections");
                var materials = db.GetCollection<POSItems>("Materials");
                POSsections SelectedSect = sectionTable.FindOne(x => x.Name == selected);
                return SelectedSect;
            }
        }
        static int order = 0;
        public static void UpdateItemSections(List<POSItems> list, string section)
        {
            if (Properties.Settings.Default.Api_On)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Properties.Settings.Default.API_Connection + "/LoadDB/UpdateSectionMaterials");
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.RequestFormat = RestSharp.DataFormat.Json;
                string i = Newtonsoft.Json.JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);// 
                request.AddParameter("application/json", i, ParameterType.RequestBody);
                request.AddQueryParameter("section", section);
                var response = client.Post(request);
            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

                {

                    var materials = db.GetCollection<POSItems>("Materials");
                    materials.Find(x => x.SectionName == section).ToList().ForEach(x => { x.SectionName = "بدون قسم"; materials.Update(x); });
                    list.ForEach(x => { order += 1; x.order = order; x.SectionName = section; materials.Update(x); });
                }
            }
        }

        public static List<POSItems> GetItemsForSection(string section)
        {

            if (Properties.Settings.Default.Api_On)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Properties.Settings.Default.API_Connection + "/LoadDB/GetMaterialsForSection");
                var request = new RestRequest();
                request.AddParameter("section", section);
                RestResponse response = client.Get(request);
                if (response != null)
                {
                    if (response.StatusCode.ToString() == "OK")
                    {
                        var i = Newtonsoft.Json.JsonConvert.DeserializeObject<List<POSItems>>(response.Content.ToString());
                        return i;
                    }
                    else return new List<POSItems>();

                }
                else return new List<POSItems>();

            }
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))
            {
                var materials = db.GetCollection<POSItems>("Materials");
                List<POSItems> items = materials.Find(x => x.SectionName == section).ToList();
                return items.OrderBy(x => x.order).ToList();
            }

        }



        public static POSsections GetSection(POSItems item)
        {
            foreach (POSsections Section in PopulateSections())
            {
                foreach (var SectionMaterials in GetItemsForSection(Section.Name))
                {
                    if (SectionMaterials.Name == item.Name)
                    {
                        return Section;
                    }
                }
            }
            return new POSsections();

        }
        public static List<POSsections> GetSections()
        {
            return dbQ.PopulateSections();
        }
        public static void SaveSections(ListBox list)
        {
            if (Properties.Settings.Default.Api_On)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Properties.Settings.Default.API_Connection + "/LoadDB/UpdateSections");
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.RequestFormat = RestSharp.DataFormat.Json;
                string i = Newtonsoft.Json.JsonConvert.SerializeObject(list.Items.Cast<POSsections>().ToList(), Newtonsoft.Json.Formatting.Indented);// 
                request.AddParameter("application/json", i, ParameterType.RequestBody);
                var response = client.Post(request);
            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

                {
                    var mat = db.GetCollection<POSItems>("Materials");
                    var sectionTable = db.GetCollection<POSsections>("Sections");
                    var lll = list.Items.Cast<POSsections>().ToList();
                    sectionTable.DeleteAll();
                    lll.ForEach(x => { x.ID = sectionTable.Count() + 1; sectionTable.Insert(x); });

                    //delete all groups
                    if (lll.Count == 0)
                    {
                        sectionTable.DeleteAll();
                    }

                }
            }
        }
        public static bool IsRowEmpty(DataGridViewRow dgv)
        {
            foreach (DataGridViewCell dc in dgv.Cells)
            {
                if (string.IsNullOrWhiteSpace(Convert.ToString(dc.Value)))
                {
                    return true;
                }
                else return false;
            }

            return false;
        }

        public static void MatAvailableSet(string barcode, bool state)
        {
            {
                try
                {
                    var Mdb = new LiteDatabase(@"Filename=C:\\db\\MenuDB.db;Connection=shared");
                    var Menus = Mdb.GetCollection<MenuSection>("Menus");
                    foreach (MenuSection item in Menus.FindAll().ToList())
                    {
                        foreach (MenuItemZ items in item.list)
                        {

                            var a = items.FindBarcode(barcode);
                            if (a != null)
                            {
                                MenuSection m = Menus.Find(x=> x.Name == item.Name).First();
                                if (m != null)
                                {
                                    
                                    foreach (var itemz in m.list)
                                    {
                                        itemz.items.ForEach(z => { if (z.Barcode.Contains(a.Barcode)) { z.Available = state; Menus.Update(m); }  });
                                    }
                                }
                            }
                        }
                    }
                    return;
                }
                catch (Exception )
                {

                }

            }
        }



        public static List<POSsections> PopulateSections() //at Load
        {
            if (Properties.Settings.Default.Api_On)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Properties.Settings.Default.API_Connection + "/LoadDB/GetSections");
                var request = new RestRequest();
                RestResponse response = client.Get(request);
                if (response != null)
                {
                    if (response.StatusCode.ToString() == "OK")
                    {
                        var i = Newtonsoft.Json.JsonConvert.DeserializeObject<List<POSsections>>(response.Content.ToString());
                        return i;
                    }
                    else return new List<POSsections>();

                }
                else return new List<POSsections>(); ;

            }
            else
            {
                try
                {
                    using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

                    {
                        var s = db.GetCollection<POSsections>("Sections");
                        var S = s.FindAll();
                        return S.ToList();
                    }
                }
                catch (Exception)
                {

                    return new List<POSsections>();
                }
            }

        }

        internal static void SaveOrUpdateItems(List<POSItems> MAT)
        {

            if (Properties.Settings.Default.Api_On)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Properties.Settings.Default.API_Connection + "/LoadDB/SaveOrUpdateItems");
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.RequestFormat = RestSharp.DataFormat.Json;
                string i = Newtonsoft.Json.JsonConvert.SerializeObject(MAT, Newtonsoft.Json.Formatting.Indented);// 
                request.AddParameter("application/json", i, ParameterType.RequestBody);
                var response = client.Post(request);

            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))
                {
                    var mat = db.GetCollection<POSItems>("Materials");
                    var deleted = mat.FindAll().Except(MAT);
                    deleted.ToList().ForEach(x => mat.Delete(x.ID));
                    MAT.ForEach(x => mat.Upsert(x));

                }
            }
        }
        internal static List<POSItems> LoadMaterialItems()
        {


            if (Properties.Settings.Default.Api_On)
            {
                try
                {
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    var client = new RestClient(Properties.Settings.Default.API_Connection + "/LoadDB/GetAllMaterials");
                    var request = new RestRequest();
                    RestResponse response = client.Get(request);
                    if (response != null)
                    {
                        if (response.StatusCode.ToString() == "OK")
                        {
                            var i = Newtonsoft.Json.JsonConvert.DeserializeObject<List<POSItems>>(response.Content.ToString());
                            return i;
                        }
                        else return new List<POSItems>();

                    }
                    else return new List<POSItems>();

                }
                catch (Exception)
                {
                    return new List<POSItems>();
                }
            }
            else
            {
                try
                {
                    using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

                    {
                        var mat = db.GetCollection<POSItems>("Materials");
                        return mat.FindAll().ToList();
                    }
                }
                catch (Exception)
                {
                    return new List<POSItems>();
                    ////
                }

            }
        }

        internal static List<WhatsAppShortCut> GetAllShortcuts()
        {
            if (Properties.Settings.Default.Api_On)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Properties.Settings.Default.API_Connection + "/LoadDB/GetWhatsappShortcut");
                var request = new RestRequest();
                RestResponse response = client.Get(request);
                if (response != null)
                {
                    if (response.StatusCode.ToString() == "OK")
                    {
                        var i = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WhatsAppShortCut>>(response.Content.ToString());
                        return i;
                    }
                    else return new List<WhatsAppShortCut>();

                }
                else return new List<WhatsAppShortCut>();


            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))
                {
                    var cuts = db.GetCollection<WhatsAppShortCut>("WhatsApp");
                    return cuts.FindAll().ToList();
                }
            }

        }

        internal static void SaveAllShortcuts(List<WhatsAppShortCut> Shortcuts)
        {
            if (Properties.Settings.Default.Api_On)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Properties.Settings.Default.API_Connection + "/LoadDB/SaveWhatsappShortcut");
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.RequestFormat = RestSharp.DataFormat.Json;
                string i = Newtonsoft.Json.JsonConvert.SerializeObject(Shortcuts, Newtonsoft.Json.Formatting.Indented);// 
                request.AddParameter("application/json", i, ParameterType.RequestBody);
                var response = client.Post(request);

            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))
                {
                    var cuts = db.GetCollection<WhatsAppShortCut>("WhatsApp");
                    cuts.DeleteAll();

                    Shortcuts.ForEach(x => cuts.Upsert(x));
                }
            }

        }

        internal static void CreatePayment()
        {
            using (var db = new LiteDatabase("Filename=\\\\DESKTOP-RRGCFGK\\db\\db.db;Connection=Shared"))
            {
                var a = db.GetCollection<Payment>("PaymentTest");
                Invoice inv = new Invoice();
                a.Upsert(new Payment { Name = "Casho", Amount = (decimal)5.05 });
            }
        }
    }
}
