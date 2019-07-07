using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.Models
{
    public class Cart
    {
        public int Id;
        public int amount;
        public int? customerId;
        public string purchased;
        public int? productId;
        public bool incart;
        public int? discount;

        private List<cartTable> list;
        public Cart() { }

        public Cart (cartTable c)
        {
            Id = c.Id;
            amount = c.amount;
            customerId = c.customerId;
            purchased = c.purchased;
            productId = c.productId;
            incart = c.incart;
            discount = c.discount;
        }



        public Cart(List<cartTable> list)

        {
            this.list = list;
        }

        public cartTable tocartTable()
        {
            cartTable ct = new cartTable()
            {
                Id = this.Id,
                amount = this.amount,
                customerId = this.customerId,
                purchased = this.purchased,
                productId = this.productId,
                incart = this.incart,
                discount = this.discount


            };
            return ct;
        }
    }
}