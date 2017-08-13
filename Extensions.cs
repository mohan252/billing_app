using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BillingApplication
{
    public static class Extensions
    {
        public static string Get(this DataRow dr, string field)
        {
            if (dr != null && dr[field] != null)
                return Convert.ToString(dr[field]);
            return "";
        }
    }
}
