using Jobb.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobb.DAL
{
    public class DALsupervision
    {
        public static IEnumerable getsupervision()
        {
            MyContext context = new MyContext();
            var model = context.supervision.ToList();
            return model;
        }

        public static void insertsupervision(supervision item)
        {
            MyContext context = new MyContext();
            if (item != null)
            {
                context.supervision.Add(item);
                context.SaveChanges();
            }
        }
        public static void updatesupervision(supervision item)
        {
            MyContext context = new MyContext();
            var edit = context.supervision.Find(item.ID_Sup);
            if (edit != null)
            {
                edit.COCE_D_05 = item.COCE_D_05;
                edit.COCE_T_06 = item.COCE_T_06;
                edit.Datetime = item.Datetime;
                edit.ID_Pro = item.ID_Pro;
                edit.ID_Regis = item.ID_Regis;
                edit.Time_D_05 = item.Time_D_05;
                edit.Time_T_06 = item.Time_T_06;
                context.SaveChanges();
            }

        }
        public static void deletesupervision(int item)
        {
            MyContext context = new MyContext();

                var model = context.supervision.Find(item);
                context.supervision.Remove(model);
                context.SaveChanges();
            
        }
    }
}