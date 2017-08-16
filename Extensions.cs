using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BillingApplication
{
    public static class Extensions
    {
        public static string Get(this DataRow dr, string field, bool isDecimal = false)
        {
            var output = "0";
            if (dr != null && dr[field] != null)
            {
                output = Convert.ToString(dr[field]);
                if (isDecimal)
                {
                    Decimal d;
                    if (!decimal.TryParse(output, out d))
                    {
                        return "0";
                    }
                }
            }
            return output;
        }
    }
}
