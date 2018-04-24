using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace test_website
{
    public static class Utility
    {
        public static DateTime? StringToDate(string str)
        {
            if (str != null)
            {
                var pc = new PersianCalendar();
                var parts = str.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                return pc.ToDateTime(parts[2], parts[1], parts[0], 0, 0, 0, 0);
            }
            return null;
        }

        public static string DateToString(DateTime? date)
        {
            if (date != null)
            {
                var pc = new PersianCalendar();
                return string.Format("{0}/{1}/{2}", pc.GetYear(date.Value),pc.GetMonth(date.Value),pc.GetDayOfMonth(date.Value));
            }
            return null;
        }
    }
}