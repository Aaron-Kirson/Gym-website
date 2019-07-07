using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectCIS.Models
{
    public class comment
    {
        public int id { get; set; }
        public string CText { get; set; }
        public int rating { get; set; }
        public int fkCustomer { get; set; }
        public string CName { get; set; }
        public int fkProduct { get; set; }
        public string feedback { get; set; }

        public static bool insertReview(string comment, int review, string username, int fkProduct)
        {
            return commentCommunicate.insertReview(comment, review, username, fkProduct);
        }

        public static bool InsertGymReview(int rating, string feedback, int user)
        {
            return commentCommunicate.InsertGymReview(rating, feedback, user);
        }

        public static double? GetAverageComment(int product)
        {
            return commentCommunicate.GetAverageComment(product);
        }
    }
}