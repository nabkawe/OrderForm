using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharedCode
{
    public static class MenuDB

    {

        public static LiteDatabase Connect()
        {
            var db = new LiteDatabase(@"Filename=C:\\db\\MenuDB.db;Connection=shared"); return db;
        }

        public static List<object> GetMenuItems(string MenuName)
        {
            using( var db = Connect())
            {
                var sect = db.GetCollection<MenuSection>("Menus");
                var s = sect.FindOne(x=> x.Name == MenuName);
                return s.list;
            }
        }

        public static void  UpdateSectionItems(List<object> SavedItems,string MenuName)
        {
            using (var db = Connect())
            {
                var sect = db.GetCollection<MenuSection>("Menus");
                var s = sect.FindOne(x => x.Name == MenuName);
                s.list.Clear(); 
                s.list = SavedItems;
                sect.Update(s);
            }

        }
        public static void SaveMenuSection(MenuSection s)
        {
            using (var db = Connect())
            {
                var sect = db.GetCollection<MenuSection>("Menus");
                sect.Upsert(s);
            }
        }
        public static void DeleteMenuSection(string MenuName)
        {
            using (var db = Connect())
            {
                var sect = db.GetCollection<MenuSection>("Menus");
                var s = sect.FindOne(x => x.Name == MenuName);
                sect.Delete(s.ID);

            }
        }

        public static List<string> GetMenus()
        {
            using (var db = Connect())
            {
                var sect = db.GetCollection<MenuSection>("Menus");
                var s = sect.FindAll();
                List<string> list = new List<string>();
                s.ToList().ForEach(x => list.Add(x.Name));
                return list;
            }
        }


        public static infoObject LoadInfo()
        {
            using (var db = Connect())
            {
                var sect = db.GetCollection<infoObject>("Info");
                infoObject list = sect.FindById(1);
                return list;



            }
        }
        public static void SaveInfo(infoObject list)
        {
            using (var db = Connect())
            {
                var sect = db.GetCollection<infoObject>("Info");
                sect.DeleteAll();
                list.ID = 1;
                sect.Upsert(list);
            }
        }
    }
}
