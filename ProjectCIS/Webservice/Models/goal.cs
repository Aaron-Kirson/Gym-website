using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.Models
{
    public class goal
    {
        public int id;
        public string goal1;
        public string ImageAD1;
        public string ImageAD2;
        public string ImageAD3;
        public string ImageAD4;
        private List<goal> list;

        public goal () { }

        public goal(GymGoal p)
        {
            id = p.Id;
            goal1 = p.goal;
            ImageAD1 = p.ImageAD1;
            ImageAD2 = p.ImageAD2;
            ImageAD3 = p.ImageAD3;
            ImageAD4 = p.ImageAD4;


        }
    }
}