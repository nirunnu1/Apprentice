using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobb.Models
{
    public class ProfileModel
    {
        private List<profile> listProfile = new List<profile>();
        public ProfileModel()
        {
            MyContext Context = new MyContext();
            profile[] Profile = Context.profile.ToArray();
            for (int i = 0; i < Profile.Length; i++)
                listProfile.Add(new profile
                {
                    Username = Profile[i].Username,
                    Password = Profile[i].Password,
                    Roles = Profile[i].Roles,
                    ID = Profile[i].ID
                });
           
        }
        public profile Find(string username)
        {
            return listProfile.Where(acc =>
            acc.Username.Equals(username)).FirstOrDefault();
        }
        public profile Login(string username, string password)
        {
            return listProfile.Where(acc =>
            acc.Username.Equals(username) && acc.Password.Equals(password)).FirstOrDefault();
        }
        public profile ChangePassword(string username, string Oldpassword)
        {
            return listProfile.Where(acc =>
            acc.Username.Equals(username) && acc.Password.Equals(Oldpassword)).FirstOrDefault();
        }
    }
}
