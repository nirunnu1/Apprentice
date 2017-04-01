using Jobb.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobb.DAL
{
    public class DALmeeting
    {
        public static IEnumerable getmeeting()
        {
            MyContext context = new MyContext();
            var model = context.meeting.ToList();
            return model;
        }
   
        public static void insertmeeting(meeting item)
        {
            MyContext context = new MyContext();
            if (item != null)
            {
                context.meeting.Add(item);
                context.SaveChanges();
            }
        }

        public static void updatemeeting(meeting item)
        {
            MyContext context = new MyContext();
            var edit = context.meeting.Find(item.ID_Mit);
            if (edit != null)
            {
                edit.Type = item.Type;
                edit.Detail = item.Detail;
                edit.Title = item.Title;
                edit.Datetime_Start = item.Datetime_Start;
                edit.Datetime_End = item.Datetime_End;
                edit.LocationType = item.LocationType;
                edit.meet_show = item.meet_show;
                context.SaveChanges();
            }
        }

        public static void deletemeeting(int item)
        {
            MyContext context = new MyContext();

                var model = context.meeting.Find(item);
                context.meeting.Remove(model);
                context.SaveChanges();
            
        }
    }
}