using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectCIS.Models
{
    public class discount
    {
        public int id { get; set; }
        public int amount { get; set; }
        public string code { get; set; }
        public bool active { get; set; }


        public static bool addDiscount(int amount, string code, bool active)
        {
            return discountCommunicate.addDiscount(amount, code, active);
        }

        public static discount applyDiscount(string code, bool active)
        {
            return discountCommunicate.applyDiscount(code, active);
        }
    }
}