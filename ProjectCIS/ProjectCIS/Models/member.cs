using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectCIS.Models
{
    public class member
    {
        public int Id { get; set; }
        public string membership { get; set; }
        public int price { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public bool active { get; set; }
        public int fkCustomer { get; set; }



        public static bool addMembership(string membership, int price)
        {
            return memberCommunicate.addMembership(membership, price);
        }

        public static bool membershipPass(string membership, int price, string startTime, string endTime, Boolean active, int customer)
        {
            return memberCommunicate.membershipPass(membership, price, startTime, endTime, active, customer);
        }

        public static List<member> ShowMembership(int user)
        {
            return memberCommunicate.ShowMembership(user);
        }
    }


}