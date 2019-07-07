using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.Models
{
    public class gymMembership
    {
        public int Id;
        public string membership;
        public int? price;

        private List<membershipTable> list;

        public gymMembership() { }

        public gymMembership (membershipTable mt)

        {
            Id = mt.Id;
            membership = mt.name;
            price = mt.Price;
        }

        public gymMembership(List<membershipTable> list)
        {
            this.list = list;
        }

        public membershipTable toMtTable()

        {
            membershipTable ct = new membershipTable()
            {
                Id = this.Id,
                name = this.membership,
                Price = this.price
               

            };
            return ct;
        }

    }
}