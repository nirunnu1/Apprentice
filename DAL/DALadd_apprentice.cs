using Jobb.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobb.DAL
{
    public class DALadd_apprentice
    {
        public static IEnumerable getadd_apprentice_all()
        {
            MyContext context = new MyContext();
            var model = context.add_apprentice.ToList();
            
            return model;
        }
        public static IEnumerable getadd_apprentice(string item)
        {
            MyContext context = new MyContext();
            var model = context.add_apprentice.Where(p => p.regis.profile.Username == item).ToList();
            if (item == null)
            {
                 model = context.add_apprentice.ToList();
            }
            
            return model;
        }
        public static void insertadd_apprentice(add_apprentice item)
        {
            MyContext context = new MyContext();
            if (item != null)
            {
                context.add_apprentice.Add(item);
                context.SaveChanges();
            }
        }
        public static void updatadd_apprentice(add_apprentice item, string name)
        {
            MyContext context = new MyContext();
            var edit = context.add_apprentice.Find(item.ID_add);
            profile[] profile = context.profile.Where(x => x.Username == name).ToArray();

            if (edit != null)
            {
                edit.Week = item.Week;
                edit.Datetime = item.Datetime;
                edit.Work = item.Work;
                if (profile[0].Roles == modelEnum.Roles.Instructor)
                {
                    edit.Type = item.Type;
                }
                context.SaveChanges();
            }

        }
        public static void deleteadd_apprentice(int item)
        {
            MyContext context = new MyContext();

                var model = context.add_apprentice.Find(item);
                context.add_apprentice.Remove(model);
                context.SaveChanges();
            
        }

    }
}