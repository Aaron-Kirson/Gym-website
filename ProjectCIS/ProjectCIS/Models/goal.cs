using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectCIS.Models
{
    public class goal
    {
        public int id;
        public string goal1 { get; set; }
        public string ImageAD1 { get; set; }
        public string ImageAD2 { get; set; }
        public string ImageAD3 { get; set; }
        public string ImageAD4 { get; set; }

        public static goal getAd(string ad)
        {
            return goalController.getAD(ad);
        }
    }
}