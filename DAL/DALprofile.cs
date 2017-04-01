using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jobb.Models;
using static Jobb.Models.modelEnum;

namespace Jobb.DAL
{
    public class DALprofile
    {
        public static IEnumerable getprofileInstuctor()
        {
            MyContext context = new MyContext();
            var model = context.profile.Where(p=>p.Roles== Roles.Instructor).ToList();
            return model;
        }
        public static IEnumerable getprofileStudent()
        {
            MyContext context = new MyContext();
            var model = context.profile.Where(p => p.Roles == Roles.Student).ToList();
            return model;
        }

        public static IEnumerable getprofile( string item)
        {
            MyContext context = new MyContext();
            var model = context.profile.Where(p => p.Username == item).ToList();
            return model;
        }
        public static void insertprofile(profile item)
        {
            MyContext context = new MyContext();
            if (item != null)
            {
                context.profile.Add(item);
                context.SaveChanges();
            }
        }

        public static void updateprofile(profile item)
        {
            MyContext context = new MyContext();
            var edit = context.profile.Find(item.ID);
            if (edit != null)
            {
                
                edit.ID_Stu = item.ID_Stu;
                edit.Fname = item.Fname;
                edit.Lname = item.Lname;
                edit.Birthday = item.Birthday;
                edit.Tel = item.Tel;
                edit.Email = item.Email;
                edit.Sex = item.Sex;
                edit.Address = item.Address;
                edit.Username = item.Username;
                edit.Password = item.Password;
                edit.Roles = item.Roles;
                context.SaveChanges();
            }
        }

        public static void deleteprofile(int item)
        {
            MyContext context = new MyContext();

                var model = context.profile.Find(item);
                context.profile.Remove(model);
                context.SaveChanges();
            
        }
    }
}