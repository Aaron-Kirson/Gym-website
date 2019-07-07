using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice.Models
{
    public class customer
    {
        public int Id;
        public string firstName;
        public string surname;
        public string email;
        public string username;
        public string password;
        public string name;
        public string card;
        public int? month;
        public int? year;
        public string experience;
        public string goal;
        public string training;
        public string address;
        public string postal;
        public string gender;

        private List<customerTable> list;

        public customer() { }

        public customer(customerTable p)
        {
            Id = p.Id;
            firstName = p.firstName;
            surname = p.surname;
            email = p.email;
            username = p.username;
            password = p.password;
            name = p.name;
            card = p.card;
            month = p.month;
            year = p.year;
            training = p.training;
            goal = p.goals;
            experience = p.exp;
            address = p.address;
            postal = p.postal;
            gender = p.gender;
        }

        public customer(List<customerTable> list)
        {
            this.list = list;
        }

        public customerTable ToCusomterTable()
        {
            customerTable ct = new customerTable()
            {
                Id = this.Id,
                firstName = this.firstName,
                surname = this.surname,
                username = this.username,
                password = this.password,
                email = this.email,
                name = this.name,
                card = this.card,
                month = this.month,
                year = this.year,
                training = this.training,
                goals = this.goal,
                exp = this.experience,
                address = this.address,
                postal = this.postal,
                gender = this.gender



        };

            return ct;
        }
    }
}