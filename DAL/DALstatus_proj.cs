using Jobb.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobb.DAL
{
    public class DALstatus_proj
    {
        public static IEnumerable getstatus_proj()
        {
            MyContext context = new MyContext();
            var model = context.status_proj.ToList();
            return model;
        }
        public static IEnumerable getstatus_proj_user(string item)
        {

            MyContext context = new MyContext();
            var model = context.status_proj.Where(p => p.regis.profile.Username == item).ToList();
            return model;
        }
        public static void insertstatus_proj(status_proj item)
        {
            MyContext context = new MyContext();
            if (item != null)
            {
                context.status_proj.Add(item);
                context.SaveChanges();
            }
        }
        public static void updatstatus_proj(status_proj item)
        {
            MyContext context = new MyContext();
            var edit = context.status_proj.Find(item.ID_StaProj);
            if (edit != null)
            {
                edit.RPCE_S_01 = item.RPCE_S_01;
                edit.RPCE_S_05 = item.RPCE_S_05;
                edit.RPCE_T_06 = item.RPCE_T_06;
                edit.RPCE_S_08 = item.RPCE_S_08;
                edit.RPCE_D_07 = item.RPCE_D_07;

                edit.date_S_01 = item.date_S_01;
                edit.date_S_05 = item.date_S_05;
                edit.date_T_06 = item.date_T_06;
                edit.date_S_08 = item.date_S_08;
                edit.date_D_07 = item.date_D_07;
                context.SaveChanges();
            }

        }
        public static void deletestatus_proj(int item)
        {
            MyContext context = new MyContext();

                var model = context.status_proj.Find(item);
                context.status_proj.Remove(model);
                context.SaveChanges();
            
        }
    }
}