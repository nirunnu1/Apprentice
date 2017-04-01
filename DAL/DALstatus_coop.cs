using Jobb.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Jobb.DAL
{
    public class DALstatus_coop
    {

      public  static  SortedDictionary<string, int> status_coop = new SortedDictionary<string, int>
{
  {"Yes", 0},
  {"No", 1}
  
};
        public static IEnumerable getstatus_coop()
        {
            MyContext context = new MyContext();
            var model = context.status_coop.ToList();
            return model;
        }
        public static IEnumerable getstatus_coop_user(string item)
        {

            MyContext context = new MyContext();
            var model = context.status_coop.Where(p => p.regis.profile.Username == item).ToList();
            return model;
        }
        public static void insertstatus_coop(status_coop item)
        {
            MyContext context = new MyContext();
            if (item != null)
            {
                context.status_coop.Add(item);
                context.SaveChanges();
            }
        }
        public static void updatstatus_coop(status_coop item)
        {
            MyContext context = new MyContext();
            var edit = context.status_coop.Find(item.ID_StaCoop);
            if (edit != null)
            {
                edit.COCE_C_01 = item.COCE_C_01;
                edit.COCE_S_02 = item.COCE_S_02;
                edit.COCE_SC_03 = item.COCE_SC_03;
                edit.COCE_C_07 = item.COCE_C_07;
                edit.COCE_C_08 = item.COCE_C_08;
                edit.ID_Regis = item.ID_Regis;
                edit.date_C_01 = item.date_C_01;
                edit.date_S_02 = item.date_S_02;
                edit.date_SC_03 = item.date_SC_03;
                edit.date_C_07 = item.date_C_07;
                edit.date_C_08 = item.date_C_08;
                context.SaveChanges();
            }

        }
        public static void deletestatus_coop(int item)
        {
            MyContext context = new MyContext();

                var model = context.status_coop.Find(item);
                context.status_coop.Remove(model);
                context.SaveChanges();
            
        }
    }
}