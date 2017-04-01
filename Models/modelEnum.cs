using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobb.Models
{
    public class modelEnum
    {
        public enum sex { male = 0, female = 1 }

        public enum Roles { Admin = 0, Instructor = 1, Student = 2 }
        public enum meetingcase { Announce = 0, meetingIns = 1, meetingStu = 2 }
        public enum status { Yes = 1, No = 0 }
        public enum Nationality { Thai = 1, England = 0 }
        public enum Region { Buddhism = 1, Islam = 0 }
        public enum statusprofie { single = 0,Engaged = 1, Married = 2, Divorced = 3 }
        public static SortedDictionary<string, int> status_meetingcase = new SortedDictionary<string, int>
{

  { "Announce", 0},
  { "meetingIns", 1},
            { "meetingStu", 2 }

        };
    }
    public static class Enumeration
    {
        public static IDictionary<int, string> GetAll<TEnum>() where TEnum : struct
        {
            var enumerationType = typeof(TEnum);

            if (!enumerationType.IsEnum)
                throw new ArgumentException("Enumeration type is expected.");

            var dictionary = new Dictionary<int, string>();

            foreach (int value in Enum.GetValues(enumerationType))
            {
                var name = Enum.GetName(enumerationType, value);
                dictionary.Add(value, name);
            }

            return dictionary;
        }
    }
}