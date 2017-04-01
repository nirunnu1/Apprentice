using Jobb.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobb.DAL
{
    public class DALins
    {
        public static IEnumerable getins()
        {
            MyContext context = new MyContext();
            var model = context.ins.ToList();
            return model;
        }
        public static IEnumerable getins_stu(string item)
        {
            MyContext context = new MyContext();
            var model = context.ins.Where(p => p.profile1.Username == item).ToList();
            return model;
        }
        public static void insertins(ins item)
        {
            MyContext context = new MyContext();
            if (item != null)
            {
                context.ins.Add(item);
                context.SaveChanges();
            }
        }
        public static void updateins(ins item)
        {
            MyContext context = new MyContext();
            var edit = context.ins.Find(item.ID_ins);
            if (edit != null)
            {
                edit.Stu_ID = item.Stu_ID;
                edit.Ins_ID = item.Ins_ID;
                edit.Type = item.Type;

                context.SaveChanges();
            }
        }

        public static void deletins(int item)
        {
            MyContext context = new MyContext();

                var model = context.ins.Find(item);
                context.ins.Remove(model);
                context.SaveChanges();
        }

    }
}