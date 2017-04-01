using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jobb.Models;

namespace Jobb.DAL
{
    public class DALcompany
    {
        public static IEnumerable getcompany()
        {
            MyContext context = new MyContext();
            var model = context.company.ToList();
            return model;
        }
        public static void insertcompany(company item)
        {
            MyContext context = new MyContext();
            if (item != null)
            {
                context.company.Add(item);
                context.SaveChanges();
            }
        }

        public static void updatecompany(company item)
        {
            MyContext context = new MyContext();
            var edit = context.company.Find(item.ID_Compa);
            if (edit != null)
            {
                edit.Name_Compa = item.Name_Compa;
                edit.Address = item.Address;
                edit.Tel = item.Tel;
               
                context.SaveChanges();
            }
        }

        public static void deletcompany(int item)
        {
            MyContext context = new MyContext();
                var model = context.company.Find(item);
                context.company.Remove(model);
                context.SaveChanges();
        }
    }
}