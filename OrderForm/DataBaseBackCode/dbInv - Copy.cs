using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OrderForm
{
    public static class DbInv
    {
        public static LiteDatabase Connect()
        {
            var db = new LiteDatabase(Properties.Settings.Default.DBConnection);
            return db;
        }

        //log backcode
        public static void LogAction(string action, int id, InvStat status)
        {
            
            using (var db = Connect())
            {
                if (status == InvStat.Draft)
                {
                    var Invoices = db.GetCollection<Invoice>("DraftInvoices");
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
            using (var db = Connect())
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
                    return Res.ID + 1;
                }
            }

        }

        public static List<Invoice> GetDraftInvoices()
        {
            using (var db = Connect())
            {
                var draft = db.GetCollection<Invoice>("DraftInvoices");
                var draftInv = draft.Find(x => x.Status == InvStat.Draft ).ToList();
                return draftInv;
            }
        }
        internal static void DeleteDBInvoices()
        {
            using (var db = Connect())
            {
                db.DropCollection("Invoices");
                db.DropCollection("DraftInvoices");

            }
        }


        internal static List<Invoice> SearchPrintedInvoices(string text)
        {
            using (var db = Connect())
            {
                var draft = db.GetCollection<Invoice>("Invoices");
                var draftInv = draft.Find(x => x.Status == InvStat.Printed && x.SearchResult.Contains(text));
                //var draftInv = draft.Find(x => x.Status != InvStat.Draft);
                var d = draftInv.OrderBy(i => i.TimeOfInv).ToList();
                return d;
            }
        }
        public static List<Invoice> GetPrintedInvoices()
        {
            using (var db = Connect())
            {
                var draft = db.GetCollection<Invoice>("Invoices");
                var draftInv = draft.Find(x => x.Status == InvStat.Printed);
                var d = draftInv.OrderBy(i => i.TimeOfInv).ToList();
                return d;
            }
        }
        internal static void UpdateInvoice(int iD,string posID)
        {
            using (var db = Connect())
            {
                var updatedInvoices = db.GetCollection<Invoice>("Invoices");
                var updated = updatedInvoices.FindById(iD);
                updated.POSInvoiceNumber = posID;
                updated.Status = InvStat.SavedToPOS;
                updatedInvoices.Update(updated);
            }
        }
        internal static void UpdateDraftInvoice(int iD,bool edit)
        {
            using (var db = Connect())
            {
                var updatedInvoices = db.GetCollection<Invoice>("DraftInvoices");
                var updated = updatedInvoices.FindById(iD);
                if (updated != null)
                {
                    updated.InEditMode = edit;
                    updatedInvoices.Update(updated);
                }
                
            }
        }        
        internal static bool IsItOpen(int iD)
        {
            using (var db = Connect())
            {
                var updatedInvoices = db.GetCollection<Invoice>("DraftInvoices");
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


        public static Invoice GetInvoiceByID(int  ID)
        {
            using (var db = Connect())
            {
                var invoices = db.GetCollection<Invoice>("Invoices");
                Invoice invoice = invoices.FindOne(x => x.ID == ID);
                return invoice;
            }
        }
          
        public static Invoice GetDraftInvoiceByID(int  ID)
        {
            using (var db = Connect())
            {
                var invoices = db.GetCollection<Invoice>("DraftInvoices");
                Invoice invoice = invoices.FindOne(x => x.ID == ID);
                return invoice;
            }
        }

        public static List<Invoice> GetSavedInvoices()
        {
            using (var db = Connect())
            {
                var draft = db.GetCollection<Invoice>("Invoices");
                var draftInv = draft.Find(x => x.Status == InvStat.SavedToPOS || x.Status == InvStat.Deleted,0,25);
                var d = draftInv.OrderBy(i => i.TimeOfInv).ToList();
                return d;
            }
        }

        public static void CreateDraftInvoice(Invoice inv)
        {
            using (var db = Connect())
            {
                var invoiceTable = db.GetCollection<Invoice>("DraftInvoices");
                invoiceTable.Upsert(inv);
            }
        }
        public static void DeleteDraftInvoice(Invoice inv)
        {
            using (var db = Connect())
            {
                var invoiceTable = db.GetCollection<Invoice>("DraftInvoices");
                invoiceTable.Delete(inv.ID);
            }
        }

        public static bool DeleteInvoice(int id, int comment)
        {
            using (var db = Connect())
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
            using (var db = Connect())
            {
                var invoiceTable = db.GetCollection<Invoice>("Invoices");
                invoiceTable.Upsert(inv);
                //bool Upserted = invoiceTable.Upsert(inv);
                //if (Upserted) DeleteDraftInvoice(inv);
            }
        }


        public static void SaveContacts(Contacts contact)
        {
            using (var db = Connect())
            {
                var Deps = db.GetCollection<Contacts>("Customers");
                Deps.Upsert(contact);

            }
        }
        public static List<Contacts> LoadContacts(string number)
        {
            using (var db = new LiteDatabase(@"Filename=C:\db\db.db;Connection=shared"))
            {
                var Deps = db.GetCollection<Contacts>("Customers");
                List<Contacts> list = Deps.Find(x => x.Number == number).ToList();
                return list;
            }
        }
        public static void SaveDepartments(List<POSDepartments> list)
        {
            using (var db = Connect())
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
            using (var db = Connect())
            {
                var Deps = db.GetCollection<POSDepartments>("POSDepartment");
                List<POSDepartments> a = Deps.FindAll().ToList();
                return a;
            }
        }

        public static void DefaultPrinters(string printer)
        {
            using (var db = Connect())
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
            using (var db = Connect())
            {
                var DefaultPrinterTable = db.GetCollection<BsonDocument>("DefaultPrinter");
                DefaultPrinterTable.DeleteAll();
                return "";
            }
        }
        public static string DefaultPrinters()
        {
            using (var db = Connect())
            {
                var DefaultPrinterTable = db.GetCollection<BsonDocument>("DefaultPrinter");
                BsonDocument a = DefaultPrinterTable.FindById(1);
                if (a != null)
                {
                    return a["Name"];

                }
                else return "";
            }
        }
        public static void UpdateAllItemsPrinters(POSsections sect)
        {
            using (var db = Connect())
            {
                var sectionTable = db.GetCollection<POSsections>("Sections");
                var materials = db.GetCollection<POSItems>("Materials");
                foreach (POSItems item in sect.Items)
                {

                    materials.Update(item);
                }
            }


        }

        public static POSsections PrinterGetSectionMaterial(string selected)
        {
            using (var db = Connect())
            {
                var sectionTable = db.GetCollection<POSsections>("Sections");
                var materials = db.GetCollection<POSItems>("Materials");
                POSsections SelectedSect = sectionTable.FindOne(x => x.Name == selected);
                return SelectedSect;
            }
        }
        public static void PrinterSetSectionMaterial(POSsections sect, string selected)
        {
            using (var db = Connect())
            {
                var sectionTable = db.GetCollection<POSsections>("Sections");
                var materials = db.GetCollection<POSItems>("Materials");
                sectionTable.Update(sect);
                POSsections SelectedSect = sectionTable.FindOne(x => x.Name == selected);
                UpdateAllItemsPrinters(SelectedSect);
            }
        }


        public static void UpdateItemsInfo()
        {
            using (var db = Connect())
            {

                var sectionTable = db.GetCollection<POSsections>("Sections");
                var materials = db.GetCollection<POSItems>("Materials");
                List<POSsections> sections = sectionTable.FindAll().ToList();
                foreach (POSsections sect in sections)
                {
                    for (int i = 0; i < sect.Items.Count; i++)
                    {
                        try
                        {
                            POSItems X = sect.Items[i];
                            List<POSItems> a = materials.Find(x => x.Name == X.Name).ToList();
                            if (a.Count > 0) sect.Items[i] = a[0];
                            else sect.Items.Remove(X);

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("" + ex.ToString());
                        }
                    }

                    sectionTable.Update(sect);
                }

            }

        }



        public static POSsections GetSection(string name)
        {
            using (var db = Connect())
            {
                var sectionTable = db.GetCollection<POSsections>("Sections");
                POSsections s = sectionTable.FindOne(x => x.Name == name);
                return s;
            }
        }
        public static List<POSsections> GetSections()
        {
            using (var db = Connect())
            {
                var sectionTable = db.GetCollection<POSsections>("Sections");
                List<POSsections> s = sectionTable.FindAll().ToList();
                return s;
            }
        }
        public static void SaveSections(ListBox list)
        {
            using (var db = Connect())
            {
                var sectionTable = db.GetCollection<POSsections>("Sections");
                List<POSsections> sectionbackup = sectionTable.FindAll().ToList();
                sectionTable.DeleteAll();
                sectionTable.DropIndex("Sections");
                db.DropCollection("Sections");
            }
            using (var db = Connect())
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
            using (var db = Connect())
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
            using (var db = Connect())
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
            using (var db = Connect())
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

        public static IEnumerable<POSItems> PopulateItems() //at LOAD
        {
            using (var db = Connect())
            {
                try
                {
                    var s = db.GetCollection<POSsections>("Sections");
                    POSsections S = s.FindOne(Query.All("ID", Query.Ascending));
                    if (S != null) return S.Items;
                    else
                    {
                        IEnumerable<POSItems> l = new List<POSItems>();
                        return l;
                    }



                }
                catch (Exception)
                {
                    IEnumerable<POSItems> l = new List<POSItems>();
                    //   POSItems pOSItems = new POSItems();
                    return l;

                }

            }

        }
        public static IEnumerable<POSsections> PopulateSections() //at Load
        {
            using (var db = Connect())
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


    }
}
