using ProjectCIS.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace ProjectCIS
{
    public class DBconnectivity
    {
        private static OleDbConnection GetConnection()
        {
            string connString;
            //  change to your connection string in the following line
            connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Aaron - Dream Team\Documents\Visual Studio 2015\Projects\ProjectCIS\ProjectCIS\App_Data\Database.mdf";
            return new OleDbConnection(connString);
        }

        public static bool insertIntoDB(customer customer)
        {

            string fn = customer.firstName;
            string sn = customer.surname;
            string email = customer.email;
            string un = customer.username;
            string pw = customer.password;

            OleDbConnection myConnection = DBconnectivity.GetConnection();
            //registers customer details into database
            string myQuery = "INSERT INTO Customers( [FirstName], [Surname], [Email], [username], [Password]) VALUES ( '" + fn + "' , '" + sn + "' , '" + email + "' , '" + un + "' , '" + pw + "')";
            System.Diagnostics.Debug.Write("ERRORERRORERRORERRORERROR " + myQuery);
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();

                myCommand.ExecuteNonQuery();
                return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                myConnection.Close();
            }
        }
    }
}