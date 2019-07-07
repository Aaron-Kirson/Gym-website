using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectCIS.Models
{
    public class customer
    {
        public int Id { get; set; }
        public string address { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string card { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public string experience { get; set; }
        public string goal { get; set; }
        public string postal { get; set; }
        public string gender { get; set; }


        public static bool forgot( string username, string password)
        {
            return customerCommunicate.forgot(username, password);
        }


       

        public static customer login(string un, string pass)
        {
            return customerCommunicate.login(un, pass).Result;
        }

 

        public static bool register(string ad, string fn, string sn, string em, string un, string pw, string name, string card, int month, int year, string level, string goal, string training, string postal, string gender)
        {

            return customerCommunicate.register(ad, fn, sn, em, un, pw, name, card, month, year, level, goal, training, postal, gender);
        }

     

        public static customer GetId(string name)
        {
            return customerCommunicate.getID(name);
        }

       
    }
}