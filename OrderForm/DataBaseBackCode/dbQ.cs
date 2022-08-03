using LiteDB;
using sharedCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OrderForm
{
    public static class dbQ
    {

        public static LiteDatabase Connect()
        {

            var db = new LiteDatabase(Properties.Settings.Default.DBConnection);
            //var db = new LiteDatabase(@"Filename=C:\db\db.db;Connection=shared");

            return db;
        }
        public static void UpdateSectionNotes(POSsections sect)
        {
            using (var db = Connect())
            {
                var Deps = db.GetCollection<POSsections>("Sections");
                Deps.Update(sect);

            }
        }
        public static int SaveContacts(Contacts contact)
        {
            using (var db = Connect())
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

                return Deps.Count();
            }
        }
        public static List<Contacts> LoadContacts(string number)
        {
            using (var db = Connect())
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

        internal static void DeleteItemSections(List<POSItems> list)
        {
            UpdateAllItemsPrinters(list);
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
            Properties.Settings.Default.DefaultPrinter = printer;
            Properties.Settings.Default.Save();
        }
        public static string DefaultPrinters()
        {
            return Properties.Settings.Default.DefaultPrinter;
        }

        public static void UpdateAllItemsPrinters(List<POSItems> list)
        {
            using (var db = Connect())
            {
                var materials = db.GetCollection<POSItems>("Materials");
                list.ForEach(x => materials.Update(x));
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
        static int order = 0;
        public static void UpdateItemSections(List<POSItems> list, string section)
        {
            using (var db = Connect())
            {
                
                var materials = db.GetCollection<POSItems>("Materials");
                //List<POSItems> old = materials.Find(x => x.SectionName == section).ToList();
                materials.Find(x => x.SectionName == section).ToList().ForEach(x=> { x.SectionName = "بدون قسم"; materials.Update(x); });
                list.ForEach(x => { order+=1 ; x.order = order;  x.SectionName = section; materials.Update(x); });
            }
        }

        public static List<POSItems> GetItemsForSection(string section)
        {
            using (var db = Connect())
            {
                var materials = db.GetCollection<POSItems>("Materials");
                List<POSItems> items = materials.Find(x => x.SectionName == section).ToList();
                return items.OrderBy(x => x.order).ToList();
            }

        }



        static List<POSsections> result = new List<POSsections>();
        public static List<POSsections> GetSection(POSItems item)
        {
            using (var db = Connect())
            {
                result.Clear();
                var sectionTable = db.GetCollection<POSsections>("Sections");

                List<POSsections> s = sectionTable.FindAll().ToList();
                foreach (POSsections ss in s)
                {
                    foreach (var a in GetItemsForSection(ss.Name))
                    {
                        if (a.Name == item.Name)
                        {
                            result.Add(ss);
                        }
                    }
                }
                return result;
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

        public static List<POSItems> PopulateItems() //at LOAD
        {
            using (var db = Connect())
            {
                try
                {
                    var s = db.GetCollection<POSsections>("Sections");
                    POSsections S = s.FindOne(Query.All("ID", Query.Ascending));
                    if (S != null)
                    {
                        return dbQ.GetItemsForSection(S.Name);
                    }
                    else
                    {
                        List<POSItems> l = new List<POSItems>();
                        return l;
                    }



                }
                catch (Exception)
                {
                    List<POSItems> l = new List<POSItems>();
                    return l;

                }

            }

        }
        public static List<POSsections> PopulateSections() //at Load
        {
            using (var db = Connect())
            {
                var s = db.GetCollection<POSsections>("Sections");
                var S = s.FindAll();
                return S.ToList();
            }

        }
        public static int GetInvoicesCount()
        {
            using (var db = Connect())
            {
                var s = db.GetCollection<Invoice>("Invoices");
                var S = s.FindAll();
                return S.Count();
            }

        }

        internal static void SaveOrUpdateItems(List<POSItems> MAT)
        {
            using (var db = Connect())
            {
                var mat = db.GetCollection<POSItems>("Materials");
                var deleted = mat.FindAll().Except(MAT);
                deleted.ToList().ForEach(x => mat.Delete(x.ID));
                MAT.ForEach(x => mat.Upsert(x));

            }
        }
        internal static List<POSItems> LoadMaterialItems()
        {
            using (var db = Connect())
            {
                var mat = db.GetCollection<POSItems>("Materials");
                return mat.FindAll().ToList();
            }
        }
    }
}
