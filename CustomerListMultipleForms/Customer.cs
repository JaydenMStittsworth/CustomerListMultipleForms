using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerListMultipleForms
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Customer(
            string first, 
            string last,
            string email, 
            string phone
        ){
            FirstName = first;
            LastName = last;
            Email = email;
            Phone = phone;
        }

        public Customer()
        {
            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} - {Email} - {Phone}";
        }
    }
}
