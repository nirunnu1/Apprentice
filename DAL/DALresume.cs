using Jobb.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobb.DAL
{
    public class DALresume
    {
        public static IEnumerable getresumeStudent()
        {
            MyContext context = new MyContext();
            var model = context.resume.ToList();
            return model;
        }

        public static IEnumerable getresume(string item)
        {
            MyContext context = new MyContext();
            var model = context.resume.Where(p => p.profile.Username == item).ToList();
            return model;
        }

        public static void insertresume(resume item)
        {
            MyContext context = new MyContext();
            if (item != null)
            {
                context.resume.Add(item);
                context.SaveChanges();
            }
        }

        public static void updateresume(resume item)
        {
            MyContext context = new MyContext();
            var edit = context.resume.Find(item.ID_Resume);
            if (edit != null)
            {
                edit.Grade = item.Grade;
                edit.Height = item.Height;
                edit.Weight = item.Weight;
                edit.Status = item.Status;
                edit.Nationality = item.Nationality;
                edit.Region = item.Region;
                edit.Career_Objective = item.Career_Objective;
                edit.Skills = item.Skills;
                edit.Education = item.Education;
                edit.Project = item.Project;
                context.SaveChanges();
            }
        }

        public static void deleteresume(int item)
        {
            MyContext context = new MyContext();

                var model = context.resume.Find(item);
                context.resume.Remove(model);
                context.SaveChanges();
            
        }
    }
}