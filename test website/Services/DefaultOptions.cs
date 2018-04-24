using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test_website.Services
{
    public static class DefaultOptions
    {
        public static Dictionary<int, string> EmployerType()
        {
            Dictionary<int, string> type = new Dictionary<int, string>();
            type.Add(1, Fa.Governmental);
            type.Add(2, Fa.Non_Govermental);
            type.Add(3, Fa.HalfPrivate);
            type.Add(4, Fa.Military);
            return type;
        }

        public static Dictionary<int,string> SecurityClass()
        {
            Dictionary<int, string> securityclass = new Dictionary<int, string>();
            securityclass.Add(1, Fa.Secret);
            securityclass.Add(2, Fa.Normal);
            return securityclass;
        }
    }
}