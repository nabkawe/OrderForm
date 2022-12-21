using LiteDB;
using RestSharp;
using sharedCode;
using System;
using System.Net;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using System.Net.Http;

namespace OrderForm
{
    public static class DbInv
    {
        //static LiteDatabase db = new LiteDatabase(Properties.Settings.Default.DBConnection);

        //public static LiteDatabase Connect()
        //{
        //    //var db = new LiteDatabase(@"Filename=C:\db\db.db;Connection=shared");
        //    return db;
        //}

        //log backcode
        public static void LogAction(string action, int id, InvStat status)
        {
            if (Properties.Settings.Default.API_ACCESS)
            {
                    var Logged = GetInvoiceByID(id);
                    Logged.LogThis(action);
                    CreateDraftInvoice(Logged);

                

            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))
                {
                    if (status == InvStat.Draft)
                    {
                        var Invoices = db.GetCollection<Invoice>("Invoices");
                        var Logged = Invoices.FindById(id);
                        Logged.LogThis(action);
                        Invoices.Update(Logged);

                    }
                    else
                    {
                        var Invoices = db.GetCollection<Invoice>("Invoices");
                        var Logged = Invoices.FindById(id);
                        Logged.LogThis(action);
                        Invoices.Update(Logged);
                    }
                }
            }
        }



        public static int GetInvoicesCount()
        {
            {
                if (Properties.Settings.Default.API_ACCESS)
                {
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    var client = new RestClient(Orders.APIConnection + "/LoadDB/InvoiceCount");
                    var request = new RestRequest();
                    RestResponse response = client.Get(request);
                    if (response != null)
                    {
                        if (response.StatusCode.ToString() == "OK")
                        {
                            var i = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(response.Content.ToString());
                            return i;
                        }
                        else return 0;

                    }
                    else return 0;

                }
                else { 
                try
                {
                    using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

                    {
                        var s = db.GetCollection<Invoice>("Invoices");
                        int S = s.Max(x => x.ID);
                        if (S == 0)
                        {
                            return 1;
                        }
                        else return S;
                    }
                }
                catch (Exception)
                {

                    using (var db = new LiteDatabase(@"Filename=C:\db\db.db;Connection=Shared"))

                    {
                        var s = db.GetCollection<Invoice>("Invoices");
                        if (s.Count() != 0)
                        {
                            int S = s.Max(x => x.ID);
                            return S;

                        }
                        else return 1;

                    }

                }
                }
            }

        }

        public static List<Invoice> GetDraftInvoices()
        {
            if (Properties.Settings.Default.API_ACCESS)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Orders.APIConnection + "/LoadDB/GetList");
                var request = new RestRequest();
                request.AddParameter("inv", "draft");
                RestResponse response = client.Get(request);
                if (response != null)
                {
                    if (response.StatusCode.ToString() == "OK")
                    {
                        {
                            var i = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Invoice>>(response.Content.ToString());// <Invoice>(item);
                            return i;
                        }
                    }
                    else return null;
                }
                else return null;
            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

                {
                    var draft = db.GetCollection<Invoice>("Invoices");
                    var draftInv = draft.Query().Where(x => x.Status == InvStat.Draft && x.InvoiceItems.Count > 0).Limit(100).ToList();
                    return draftInv;
                }

            }
        }
        public static void DeleteInvoicesByID(int id)
        {
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

            {
                var draft = db.GetCollection<Invoice>("Invoices");
                draft.DeleteMany(x => x.Status == InvStat.Draft && x.ID == id);


            }
        }

        internal static void DeleteDBInvoices()
        {
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

            {
                db.DropCollection("Invoices");

            }
        }


        internal static List<Invoice> SearchPrintedInvoices(string text)
        {
            if (Properties.Settings.Default.API_ACCESS)
            {

                {
                    var draft = GetPrintedInvoices();
                    var d = draft.Where(x => x.Status == InvStat.Printed && x.SearchResult.Contains(text)).OrderBy(i => i.TimeOfInv).Take(100).ToList();
                    return d;
                }
            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

                {
                    var draft = db.GetCollection<Invoice>("Invoices");
                    var draftInv = draft.Find(x => x.Status == InvStat.Printed && x.SearchResult.Contains(text));
                    //var draftInv = draft.Find(x => x.Status != InvStat.Draft);
                    var d = draftInv.OrderBy(i => i.TimeOfInv).Take(100).ToList();
                    return d;
                }
            }
        }
        public static List<Invoice> GetPrintedInvoices()
        {

            if (Properties.Settings.Default.API_ACCESS)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Orders.APIConnection + "/LoadDB/GetList");
                var request = new RestRequest();
                request.AddParameter("inv", "printed");
                RestResponse response = client.Get(request);
                if (response != null)
                {
                    if (response.StatusCode.ToString() == "OK")
                    {
                        var i = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Invoice>>(response.Content.ToString());// <Invoice>(item);
                        return i;
                    }
                    else return null;

                }
                else return null;
            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))
                {
                    var draft = db.GetCollection<Invoice>("Invoices");
                    var draftinv = draft.Find(x => x.Status == InvStat.Printed).Take(100).ToList().OrderByDescending(x => x.TimeinArabic == "الآن").ThenBy(x => x.TimeOfInv);
                    return draftinv.ToList();
                }
            }
        }

        internal static void UpdateInvoice(int iD, string posID)
        {
            if (Properties.Settings.Default.API_ACCESS)
            {
                var updated = GetInvoiceByID(iD);
                updated.POSInvoiceNumber = posID;
                CultureInfo[] cultures = { new CultureInfo("ar-SA") };
                DateTime DT = DateTime.Now;
                updated.TimeOfSaving = DT;
                updated.Status = InvStat.SavedToPOS;

                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Orders.APIConnection + "/LoadDB/UpdateInvoiceSaved");
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.RequestFormat = DataFormat.Json;
                string i = Newtonsoft.Json.JsonConvert.SerializeObject(updated, Newtonsoft.Json.Formatting.Indented);// <Invoice>(item);
                request.AddParameter("application/json", i, ParameterType.RequestBody);
                var response = client.Post(request);

            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

                {
                    var updatedInvoices = db.GetCollection<Invoice>("Invoices");
                    var updated = updatedInvoices.FindById(iD);
                    updated.POSInvoiceNumber = posID;
                    CultureInfo[] cultures = { new CultureInfo("ar-SA") };
                    DateTime DT = DateTime.Now;
                    updated.TimeOfSaving = DT;
                    updated.Status = InvStat.SavedToPOS;
                    updatedInvoices.Update(updated);
                }
            }
        }

        internal static void UpdateDraftInvoice(int iD, bool edit)

        {
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

            {
                var updatedInvoices = db.GetCollection<Invoice>("Invoices");
                var updated = updatedInvoices.FindById(iD);
                if (updated != null)
                {
                    updated.Comment = updated.Comment + " ";
                    updated.InEditMode = edit;
                    updatedInvoices.Update(updated);
                }

            }
        }


        public static Invoice GetInvoiceByID(int ID)
        {
            if (Properties.Settings.Default.API_ACCESS)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                var client = new RestClient(Orders.APIConnection + "/LoadDB/GetByID");

                var request = new RestRequest();
                request.AddParameter("id", ID);
                RestResponse response = client.Get(request);

                if (response != null)
                {
                    if (response.StatusCode.ToString() == "OK")
                    {
                        var invoice = Newtonsoft.Json.JsonConvert.DeserializeObject<Invoice>(response.Content.ToString());// <Invoice>(item);
                        return invoice;
                    }
                    else return new Invoice();

                }
                else { return new Invoice(); }

            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

                {
                    var invoices = db.GetCollection<Invoice>("Invoices");
                    Invoice invoice = invoices.FindOne(x => x.ID == ID);
                    return invoice;
                }
            }
        }


        public static List<Invoice> GetSavedInvoices()
        {
            if (Properties.Settings.Default.API_ACCESS)
            {

                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Orders.APIConnection + "/LoadDB/GetList");
                var request = new RestRequest();
                request.AddParameter("inv", "saved");
                RestResponse response = client.Get(request);
                if (response != null)
                {
                    if (response.StatusCode.ToString() == "OK")
                    {
                        {
                            var i = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Invoice>>(response.Content.ToString());// <Invoice>(item);
                            return i;

                        }
                    }
                    return null;
                }
                else { return null; }
            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

                {
                    var draft = db.GetCollection<Invoice>("Invoices");
                    var draftinv = draft.Query().Where(x => x.Status == InvStat.Deleted || x.Status == InvStat.SavedToPOS).OrderByDescending(x => x.ID).Limit(200);
                    return draftinv.ToList();
                }

            }


        }


        public static List<Invoice> GetAllSavedInvoices()
        {
            if (Properties.Settings.Default.API_ACCESS)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Orders.APIConnection + "/LoadDB/GetList");
                var request = new RestRequest();
                request.AddParameter("inv", "allsaved");
                RestResponse response = client.Get(request);
                if (response != null)
                {
                    if (response.StatusCode.ToString() == "OK")
                    {
                        {
                            var i = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Invoice>>(response.Content.ToString());// <Invoice>(item);
                            return i;
                        }
                    }
                }
                return null;
            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))
                {
                    var draft = db.GetCollection<Invoice>("Invoices");
                    var draftInv = draft.Find(x => x.Status == InvStat.SavedToPOS || x.Status == InvStat.Deleted);
                    var d = draftInv.OrderByDescending(i => Convert.ToInt32(i.IDstring)).ToList(); //.ThenBy(o => o.InvoiceDay)
                    return d;
                }
            }
        }
        public static void CreateDraftInvoice(Invoice inv)
        {
            if (Properties.Settings.Default.API_ACCESS)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Orders.APIConnection + "/LoadDB/UpdateInvoiceDraft");
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.RequestFormat = DataFormat.Json;
                string i = Newtonsoft.Json.JsonConvert.SerializeObject(inv, Newtonsoft.Json.Formatting.Indented);// <Invoice>(item);
                request.AddParameter("application/json", i, ParameterType.RequestBody);
                var response = client.Post(request);
            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

                {
                    var invoiceTable = db.GetCollection<Invoice>("Invoices");
                    invoiceTable.Update(inv);

                }
            }
        }

        public static bool DeleteInvoice(int id, int comment)
        {

            var Deleted = GetInvoiceByID(id);

            if (Properties.Settings.Default.API_ACCESS)
            {
                if (comment == 1)
                {
                    
                    DbInv.LogAction("Printed Invoice Deleted Canceled", id, InvStat.Deleted);
                    Deleted = GetInvoiceByID(id);
                    Deleted.Comment = "تم الإلغاء من العميل";
                    Deleted.Status = InvStat.Deleted;
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    var client = new RestClient(Orders.APIConnection + "/LoadDB/UpdateInvoiceDraft");
                    var request = new RestRequest();
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("Accept", "application/json");
                    request.RequestFormat = DataFormat.Json;
                    string i = Newtonsoft.Json.JsonConvert.SerializeObject(Deleted, Newtonsoft.Json.Formatting.Indented);// <Invoice>(item);
                    request.AddParameter("application/json", i, ParameterType.RequestBody);
                    var response = client.Post(request);

                    return response.IsSuccessStatusCode;

                }
                else
                {
                    DbInv.LogAction($"Printed Invoice Deleted wasn't picked up", id, InvStat.Deleted);
                    Deleted = GetInvoiceByID(id);
                    Deleted.Comment = "لم يتم الإستلام من العميل";
                    Deleted.Status = InvStat.Deleted;
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    var client = new RestClient(Orders.APIConnection + "/LoadDB/UpdateInvoiceDraft");
                    var request = new RestRequest();
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("Accept", "application/json");
                    request.RequestFormat = DataFormat.Json;
                    string i = Newtonsoft.Json.JsonConvert.SerializeObject(Deleted, Newtonsoft.Json.Formatting.Indented);// <Invoice>(item);
                    request.AddParameter("application/json", i, ParameterType.RequestBody);
                    var response = client.Post(request);

                    return response.IsSuccessStatusCode;
                }


            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

                {
                    var Invoices = db.GetCollection<Invoice>("Invoices");
                    Deleted = Invoices.FindById(id);
                    Deleted.Status = InvStat.Deleted;
                    if (comment != 0)
                    {
                        Deleted.Comment = "تم الإلغاء من العميل";
                        DbInv.LogAction("Printed Invoice Deleted Canceled", Deleted.ID, Deleted.Status);

                        return Invoices.Update(Deleted);

                    }
                    else
                    {
                        Deleted.Comment = "لم يتم الإستلام من العميل";
                        DbInv.LogAction($"Printed Invoice Deleted wasn't picked up", Deleted.ID, Deleted.Status);
                        return Invoices.Update(Deleted);
                    }
                }
            }
        }

        public static bool CreatePreparingInvoice(Invoice inv)
        {
            if (Properties.Settings.Default.API_ACCESS)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Orders.APIConnection + "/LoadDB/CreateNewInvoice");
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.RequestFormat = DataFormat.Json;
                string i = Newtonsoft.Json.JsonConvert.SerializeObject(inv, Newtonsoft.Json.Formatting.Indented);// <Invoice>(item);
                request.AddParameter("application/json", i, ParameterType.RequestBody);
                var response = client.Post(request);


                if (response != null)
                {
                    if (response.Content.ToString() == "true")
                    {
                        Console.WriteLine(response.Content.ToString());
                        {
                            return true;
                        }
                    }
                    else return false;
                }
                else throw new HttpRequestException() ;
                
            }
            else { 
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))
            {
                var invoiceTable = db.GetCollection<Invoice>("Invoices");
                try
                {
                    invoiceTable.Insert(inv);
                    return true;
                }
                catch (Exception)
                {
                    // invoiceTable.Update(inv);
                    return false;
                }
            }
            }
        }

        

        public static bool UpdatePreparingInvoice(Invoice inv)
        {
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))
            {
                var invoiceTable = db.GetCollection<Invoice>("Invoices");
                try
                {
                    invoiceTable.Update(inv);
                    return true;
                }
                catch (Exception)
                {
                    // invoiceTable.Update(inv);
                    return false;
                }
            }
        }


        public static void SaveContacts(Contacts contact)
        {
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

            {
                var Deps = db.GetCollection<Contacts>("Customers");
                Deps.Upsert(contact);

            }
        }
        public static List<Contacts> LoadContacts(string number)
        {
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

            {
                var Deps = db.GetCollection<Contacts>("Customers");
                List<Contacts> list = Deps.Query().Where(x => x.Number == number).Limit(5).ToList();
                return list;
            }
        }
        public static void SaveDepartments(List<POSDepartments> list)
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

        public static List<POSDepartments> LoadDepartments()
        {
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

            {
                var Deps = db.GetCollection<POSDepartments>("POSDepartment");
                List<POSDepartments> a = Deps.FindAll().ToList();
                return a;
            }
        }

        public static void DefaultPrinters(string printer)
        {
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

            {
                var DefaultPrinterTable = db.GetCollection<BsonDocument>("DefaultPrinter");
                DefaultPrinterTable.DeleteAll();
                BsonDocument BD = new BsonDocument() { ["Name"] = printer };

                DefaultPrinterTable.Upsert(1, BD);

                //return DefaultPrinterTable.FindById(1);
            }
        }
        public static string DelDefaultPrinters()
        {
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

            {
                var DefaultPrinterTable = db.GetCollection<BsonDocument>("DefaultPrinter");
                DefaultPrinterTable.DeleteAll();
                return "";
            }
        }
        public static string DefaultPrinters()
        {
            return Properties.Settings.Default.DefaultPrinter;
        }


        public static POSsections GetSection(string name)
        {
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

            {
                var sectionTable = db.GetCollection<POSsections>("Sections");
                POSsections s = sectionTable.FindOne(x => x.Name == name);
                return s;
            }
        }
        public static List<POSsections> GetSections()
        {
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

            {
                var sectionTable = db.GetCollection<POSsections>("Sections");
                List<POSsections> s = sectionTable.FindAll().ToList();
                return s;
            }
        }
        public static void SaveSections(ListBox list)
        {
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

            {
                var sectionTable = db.GetCollection<POSsections>("Sections");
                List<POSsections> sectionbackup = sectionTable.FindAll().ToList();
                sectionTable.DeleteAll();
                db.DropCollection("Sections");



                var section = db.GetCollection<POSsections>("Sections");
                foreach (POSsections s in list.Items)
                {
                    section.Upsert(s.ID, s);
                }
                sectionTable.EnsureIndex(x => x.Name);
            }

        }
        public static bool IsRowEmpty(DataGridViewRow dgv)
        {
            foreach (DataGridViewCell dc in dgv.Cells)
            {
                if (Convert.ToString(dc.Value) == "")
                {
                    return true;
                }
                else return false;
            }

            return false;
        }

        public static List<POSItems> CreateNewMaterials(DataGridView dgv)
        {
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

            {
                var Materials = db.GetCollection<POSItems>("Materials");
                var Cancel = Materials;
                Materials.DeleteAll();
                int newID = 1;
                List<POSItems> list = new List<POSItems>();
                foreach (DataGridViewRow row in dgv.Rows)
                {


                    if (IsRowEmpty(row) == false)
                    {
                        try
                        {
                            var a = newID++;
                            Console.WriteLine(a);
                            var b = Convert.ToString(row.Cells[1].Value);
                            var c = Convert.ToString(row.Cells[2].Value);
                            var d = Convert.ToDecimal(row.Cells[3].Value);
                            var e = Convert.ToInt32(row.Cells[4].Value);
                            var f = Convert.ToInt32(row.Cells[5].Value);
                            var g = Convert.ToDecimal(row.Cells[6].Value);
                            var h = Convert.ToString(row.Cells[7].Value);
                            var i = Convert.ToString(row.Cells[8].Value);
                            if (i == null) i = "Default";
                            POSItems item = new POSItems(a, b, c, d, e, f, g, h, i);
                            Materials.Upsert(item);
                            list.Add(item);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());

                        }

                    }
                }
                return list;

            }

        }


        public static void CancelLastSave(List<POSItems> mat)
        {
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

            {
                var Materials = db.GetCollection<POSItems>("Materials");
                Materials.DeleteAll();

                foreach (POSItems item in mat)
                {
                    Materials.Upsert(item);
                }

            }
        }


        public static List<POSItems> GetAllMaterials()
        {
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

            {
                var Materials = db.GetCollection<POSItems>("Materials");
                var col = Materials.FindAll().ToList();

                //List<POSItems> mat = new List<POSItems>();
                //foreach (var item in col)
                //{
                //    mat.Add(item);
                //}

                return col;
            }

        }


        public static IEnumerable<POSsections> PopulateSections() //at Load
        {
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

            {
                var s = db.GetCollection<POSsections>("Sections");
                var S = s.FindAll();
                return S;
            }

        }

        public static void CreateDraft(Invoice inv)
        {

        }
        public static void CreateAppOrder(Invoice inv)
        {

            if (Properties.Settings.Default.API_ACCESS)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var client = new RestClient(Orders.APIConnection + "/LoadDB/UpdateInvoiceSaved");
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.RequestFormat = DataFormat.Json;
                string i = Newtonsoft.Json.JsonConvert.SerializeObject(inv, Newtonsoft.Json.Formatting.Indented);// <Invoice>(item);
                request.AddParameter("application/json", i, ParameterType.RequestBody);
                var response = client.Post(request);
            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))

                {

                    var Invoices = db.GetCollection<Invoice>("Invoices");
                    Invoices.Upsert(inv);
                }
            }
        }

        internal static Invoice GetInvoiceByPhoneNumber(string number)
        {
            if (Properties.Settings.Default.API_ACCESS)
            {
                var c = GetSavedInvoices();
                var result = c.FindLast(x => x.CustomerNumber == number);
                if (result == null) return null; else return result;
            }
            else
            {
                using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))
                {
                    var Invoices = db.GetCollection<Invoice>("Invoices");
                    var c = Invoices.Find(x => x.CustomerNumber.Contains(number));
                    var b = c.ToList();
                    if (b[0] == null) return null; else return b[0];
                }

            }
        }

        internal static void DeleteAllEmptyDrafts()
        {

            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))
            {
                var draft = db.GetCollection<Invoice>("Invoices");
                draft.DeleteMany(x => x.Status == InvStat.Draft && x.InvoiceItems.Count == 0);
            }

        }

        internal static void InsureIndexes()
        {
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))
            {
                var draft = db.GetCollection<Invoice>("Invoices");
                draft.DropIndex("Status");
                draft.EnsureIndex(x => x.Status);
                draft.EnsureIndex(x => x.SearchResult);
                draft.EnsureIndex(x => x.CustomerNumber);
                draft.EnsureIndex(x => x.ID);
                var Materials = db.GetCollection<POSItems>("Materials");
                Materials.EnsureIndex(x => x.Barcode);
                var sectionTable = db.GetCollection<POSsections>("Sections");
                sectionTable.EnsureIndex(x => x.Name);
                var Deps = db.GetCollection<Contacts>("Customers");
                Deps.EnsureIndex(x => x.Number);
            }
        }

        internal static void Rebuild()
        {
            using (var db = new LiteDatabase(Properties.Settings.Default.DBConnection))
            {
                db.Rebuild();
            }
        }
    }
}