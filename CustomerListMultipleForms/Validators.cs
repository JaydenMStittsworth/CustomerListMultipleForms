using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerListMultipleForms
{
    class Validators
    {
        public static bool IsValidCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.FirstName))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(customer.LastName))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(customer.Email) &&
                string.IsNullOrWhiteSpace(customer.Phone))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidPhone(string phone)
        {
            // is it null, contain only whitespace, or is empty? FAILURE
            if (string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrEmpty(phone))
            {
                return false;
            };

            // text has contents. VALID
            return true;
        }

        public static bool ContainsValue(string text)
        {
            // is it null, contain only whitespace, or is empty? FAILURE
            if (string.IsNullOrWhiteSpace(text) ||
                string.IsNullOrEmpty(text))
            {
                return false;
            };

            // phone has text. VALID
            return true;
        }

        public static bool IsValidEmail(string email)
        {
            // check for the pattern of an email address using regex
            string emailPattern = @"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})*$";

            return Regex.IsMatch(email, emailPattern);
        }

        public static bool IsValidPhoneNumber(string phone)
        {
            // check for the pattern of a phone number using regex
            string phonePattern = @"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$";

            return Regex.IsMatch(phone, phonePattern);
        }
    }
}
