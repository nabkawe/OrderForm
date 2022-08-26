using LiteDB;
using sharedCode;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace OrderForm
{
    public static class DbInv
    {
        static LiteDatabase db = new LiteDatabase(Properties.Settings.Default.DBConnection);

        public static LiteDatabase Connect()
        {
            //var db = new LiteDatabase(@"Filename=C:\db\db.db;Connection=shared");
            return db;
        }

        //log backcode
        public static void LogAction(string action, int id, InvStat status)
        {

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



        public static int GetInvoicesCount()
        {
            {
                try
                {
                    var s = db.GetCollection<Invoice>("Invoices");
                    var S = s.FindAll();
                    if (S.Count() == 0)
                    {
                        return 1;
                    }
                    else
                    {
                        Invoice Res = S.OrderByDescending(x => x.ID).First();
                        if (Res.InEditMode)
                        {
                            return Res.ID + 2;
                        }
                        else
                            return Res.ID + 1;
                    }
                }
                catch (Exception)
                {
                    return 0;


                }

            }

        }

        public static List<Invoice> GetDraftInvoices()
        {
            {
                var draft = db.GetCollection<Invoice>("Invoices");
                var draftInv = draft.Find(x => x.Status == InvStat.Draft && x.InvoiceItems.Count > 0).ToList();
                return draftInv;
            }
        }
        public static void DeleteInvoicesByID(int id)
        {
            {
                var draft = db.GetCollection<Invoice>("Invoices");
                draft.DeleteMany(x => x.Status == InvStat.Draft && x.ID == id);


            }
        }

        internal static void DeleteDBInvoices()
        {
            {
                db.DropCollection("Invoices");

            }
        }

        internal static void unlockall()
        {

            {
                var draft = db.GetCollection<Invoice>("Invoices");
                draft.Find(x => x.Status == InvStat.Draft).ToList().ForEach(i => { i.InEditMode = false; draft.Update(i); });
            }


        }
        internal static List<Invoice> SearchPrintedInvoices(string text)
        {
            {
                var draft = db.GetCollection<Invoice>("Invoices");

                var draftInv = draft.Find(x => x.Status == InvStat.Printed && x.SearchResult.Contains(text));
                //var draftInv = draft.Find(x => x.Status != InvStat.Draft);
                var d = draftInv.OrderBy(i => i.TimeOfInv).Take(100).ToList();
                return d;


            }
        }
        public static List<Invoice> GetPrintedInvoices()
        {
            {
                var draft = db.GetCollection<Invoice>("Invoices");
                var draftInv = draft.Find(x => x.Status == InvStat.Printed);
                var d = draftInv.OrderBy(x => x.TimeOfInv).ToList();


                return d;
            }
        }
        internal static void UpdateInvoice(int iD, string posID)
        {
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
        internal static void UpdateDraftInvoice(int iD, bool edit)
        {
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
        internal static bool IsItOpen(int iD)
        {
            {
                var updatedInvoices = db.GetCollection<Invoice>("Invoices");
                var updated = updatedInvoices.FindById(iD);
                if (updated != null)
                {
                    if (updated.InEditMode)
                        return true;
                    else return false;
                }
                else return false;


            }
        }


        public static Invoice GetInvoiceByID(int ID)
        {
            {
                var invoices = db.GetCollection<Invoice>("Invoices");
                Invoice invoice = invoices.FindOne(x => x.ID == ID);
                return invoice;
            }
        }

        public static Invoice GetDraftInvoiceByID(int ID)
        {
            {
                var invoices = db.GetCollection<Invoice>("Invoices");
                Invoice invoice = invoices.FindOne(x => x.ID == ID && x.Status == InvStat.Draft);
                return invoice;
            }
        }

        public static List<Invoice> GetSavedInvoices()
        {
            {
                var draft = db.GetCollection<Invoice>("Invoices");
                var draftInv = draft.Find(x => x.Status == InvStat.Deleted || x.Status == InvStat.SavedToPOS, draft.Find(y => y.Status == InvStat.SavedToPOS || y.Status == InvStat.Deleted).Count() - 200, 200);
                return draftInv.OrderByDescending(x => Convert.ToInt32(x.POSInvoiceNumber)).ToList();
            }//(x => x.TimeOfSaving)

        }

        public static void UpdateInvoiceTime()
        {
            {
                var draft = db.GetCollection<Invoice>("Invoices");
                var draftInv = draft.Find(x => x.Status == InvStat.SavedToPOS || x.Status == InvStat.Deleted);
                draftInv.OrderByDescending(x => x.ID).ToList();


            }
        }
        public static List<Invoice> GetAllSavedInvoices()
        {

            {
                var draft = db.GetCollection<Invoice>("Invoices");
                var draftInv = draft.Find(x => x.Status == InvStat.SavedToPOS || x.Status == InvStat.Deleted);
                var d = draftInv.OrderByDescending(i => Convert.ToInt32(i.POSInvoiceNumber)).ThenBy(o => o.InvoiceDay).ToList();
                return d;
            }
        }
        public static void CreateDraftInvoice(Invoice inv)
        {

            {
                var invoiceTable = db.GetCollection<Invoice>("Invoices");
                invoiceTable.Upsert(inv);

            }
        }
        public static void DeleteDraftInvoice(Invoice inv)
        {
            //using (var db = Connect())
            //{
            //    var invoiceTable = db.GetCollection<Invoice>("DraftInvoices");
            //    invoiceTable.Delete(inv.ID);
            //}
        }

        public static bool DeleteInvoice(int id, int comment)
        {

            {
                var Invoices = db.GetCollection<Invoice>("Invoices");
                var Deleted = Invoices.FindById(id);
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

        public static void CreatePreparingInvoice(Invoice inv)
        {

            {
                var invoiceTable = db.GetCollection<Invoice>("Invoices");
                invoiceTable.Upsert(inv);
                //bool Upserted = invoiceTable.Upsert(inv);
                //if (Upserted) DeleteDraftInvoice(inv);
            }
        }


        public static void SaveContacts(Contacts contact)
        {

            {
                var Deps = db.GetCollection<Contacts>("Customers");
                Deps.Upsert(contact);

            }
        }
        public static List<Contacts> LoadContacts(string number)
        {

            {
                var Deps = db.GetCollection<Contacts>("Customers");
                List<Contacts> list = Deps.Find(x => x.Number == number).ToList();
                return list;
            }
        }
        public static void SaveDepartments(List<POSDepartments> list)
        {

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

            {
                var Deps = db.GetCollection<POSDepartments>("POSDepartment");
                List<POSDepartments> a = Deps.FindAll().ToList();
                return a;
            }
        }

        public static void DefaultPrinters(string printer)
        {

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

            {
                var sectionTable = db.GetCollection<POSsections>("Sections");
                POSsections s = sectionTable.FindOne(x => x.Name == name);
                return s;
            }
        }
        public static List<POSsections> GetSections()
        {

            {
                var sectionTable = db.GetCollection<POSsections>("Sections");
                List<POSsections> s = sectionTable.FindAll().ToList();
                return s;
            }
        }
        public static void SaveSections(ListBox list)
        {

            {
                var sectionTable = db.GetCollection<POSsections>("Sections");
                List<POSsections> sectionbackup = sectionTable.FindAll().ToList();
                sectionTable.DeleteAll();
                sectionTable.DropIndex("Sections");
                db.DropCollection("Sections");
            }

            {
                var section = db.GetCollection<POSsections>("Sections");
                foreach (POSsections s in list.Items)
                {
                    section.Upsert(s.ID, s);
                }
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

            {
                var s = db.GetCollection<POSsections>("Sections");
                var S = s.FindAll();
                return S;
            }

        }

        public static void CreateDraft(Invoice inv)
        {

        }
        public static void CreateOrder(Invoice inv)
        {

        }

        internal static Invoice GetInvoiceByPhoneNumber(string number)
        {
            var Invoices = db.GetCollection<Invoice>("Invoices");

            var c = Invoices.Find(x => x.CustomerNumber.Contains(number));
            var b = c.ToList();
            if (b[0] == null) return null;else return b[0];
        }
    }
}