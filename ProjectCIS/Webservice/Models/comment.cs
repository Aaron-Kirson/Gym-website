using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.Models
{
    public class comment
    {

        public int id;
        public string CText;
        public int? rating;
        public string CName;
        public int? fkProduct;
        public int name;
        private List<comment> list;
    

    

        public comment () { }

        public comment(commentTable p)
        {
            id = p.Id;
            CText = p.CText;
            rating = p.rating;
            CName = p.CName;
            fkProduct = p.fkProduct;

        }

      
           


        public comment(List<comment> list)
        {
            this.list = list;
        }

        public static List<comment> ReviewShake(int name)
        {

            using (DBDataContext cdb = new DBDataContext())
            {

                List<commentTable> aqa = cdb.commentTables.Where(x => x.fkProduct == name).ToList();
                return comment.ReturnGrid(aqa);



            }
        }

        public static List<comment> ReturnGrid(List<commentTable> qs)
        {
            List<comment> qms = new List<comment>();
            foreach (commentTable p in qs)
            {
                qms.Add(new comment(p));
            }
            return qms;
        }
    }
}