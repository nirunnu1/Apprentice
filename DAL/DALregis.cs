using Jobb.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Jobb.Models.modelEnum;

namespace Jobb.DAL
{
    public class DALregis
    {
        public static IEnumerable getregis(string item)
        {
            MyContext context = new MyContext();
            var model = context.regis.Where(p => p.profile.Username == item).ToList();
            return model;
        }
        public static IEnumerable getregis_stu()
        {
            MyContext context = new MyContext();
            var model = context.regis.Where(p => p.profile.Roles == Roles.Student).ToList();
            return model;
        }
        public static IEnumerable getregis_all()
        {
            MyContext context = new MyContext();
            var model = context.regis.ToList();
            return model;
        }
        

        public static void insertregis(regis item)
        {
            MyContext context = new MyContext();
            if (item != null)
            {
                context.regis.Add(item);
                context.SaveChanges();
            }
        }

        public static void updateregis(regis item)
        {
            MyContext context = new MyContext();
            var edit = context.regis.Find(item.ID_Regis);
            if (edit != null)
            {
                edit.ID_Compa = item.ID_Compa;
                edit.ID_Resume = item.ID_Resume;
                edit.ID_Pro = item.ID_Pro;
                edit.type = item.type;
                context.SaveChanges();
            }
        }

        public static void deleteregis(int item)
        {
            MyContext context = new MyContext();

                var model = context.regis.Find(item);
                context.regis.Remove(model);
                context.SaveChanges();
            
        }
    }
}