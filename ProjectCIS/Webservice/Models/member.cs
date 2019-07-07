using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.Models
{
    public class member
    {
        public int Id;
        public string membership;
        public int? price;
        public string startTime;
        public string endTime;
        public bool? active;
        public int? fkCustomer;


        private List<customerMembership> list;
    

        public member() { }

        public member (customerMembership cm)
        {
            Id = cm.Id;
            membership = cm.membership;
            price = cm.price;
            startTime = cm.startTime;
            endTime = cm.endTime;
            active = cm.active;
            fkCustomer = cm.fkCustomer;





        }


        

        public member(List<customerMembership> list)
        {
            this.list = list;
        }

        public customerMembership toCMTable()

        {
            customerMembership ct = new customerMembership()
            {
                Id = this.Id,
                membership = this.membership,
                price = this.price,
                startTime = this.startTime,
                endTime = this.endTime,
                active = this.active,
                fkCustomer = this.fkCustomer



            };
            return ct;
        }


    }
}