﻿using LiteDB;
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

        public static List<MenuItemZ> GetMenuItems(string MenuName)
        {
            using (var db = Connect())
            {
                var sect = db.GetCollection<MenuSection>("Menus");
                var s = sect.FindOne(x => x.Name == MenuName);
                return s.list;
            }
        }
        public static List<headerObject> GetMenuHeaders(string MenuName)
        {
            using (var db = Connect())
            {
                var sect = db.GetCollection<MenuSection>("Menus");
                var s = sect.FindOne(x => x.Name == MenuName);
                // do a null check and return an empty list if null ;
                if (s.headerList == null) { return new List<headerObject>(); } else return s.headerList;
            }
        }

        public static void UpdateSectionItems(List<MenuItemZ> SavedItems, string MenuName)
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
        public static void UpdateSectionHeaders(List<headerObject> SavedHeaders, string MenuName)

        {
            using (var db = Connect())
            {
                var sect = db.GetCollection<MenuSection>("Menus");
                var s = sect.FindOne(x => x.Name == MenuName);
                if (s != null)
                {

                        s.headerList = SavedHeaders;
                        sect.Upsert(s);

                }

                
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
        public static void UpdateMenuSection(string MenuName, int order)
        {
            using (var db = Connect())
            {
                var sect = db.GetCollection<MenuSection>("Menus");
                var s = sect.FindOne(x => x.Name == MenuName);
                s.order = order;
                sect.Update(s);
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
                var s = sect.FindAll().OrderBy(x => x.order);
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
