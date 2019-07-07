using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.Models
{
    public class discount
    {
        public int id;
        public int? amount;
        public string code;
        public bool? active;
        private List<discountTable> list;


        public discount() { }

        public discount(discountTable p)
        {
            id = p.Id;
            amount = p.amount;
            code = p.code;
            active = p.active; 
           
        }


        public discountTable todiscount()
        {
            discountTable ct = new discountTable()
            {
                Id = this.id,
               amount = this.amount,
               code = this.code,
               active = this.active



            };

            return ct;
        }


        public discount(List<discountTable> list)
        {
            this.list = list;
        }

        public static discount getDiscount(string code)
        {
            using (DBDataContext cdb = new DBDataContext())
            {
                return new discount(cdb.discountTables.Single(x => x.code == code));
            }
        }

    }
}