using System;
using System.Text.RegularExpressions;

namespace GC_Lab7_RegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to regular expressions lab.");

            //TEST METHODS
            string[] testValues = { "Tomás", "tomás", "ToMás", "toMás", "tomas@duolingo.com", "123-456-7890", "1234567890", "123", "31/12/1999", "32/13/2000", "<p></p>", "<h</h>" };
            foreach (string value in testValues)
            {
                ValidateName(value);
                ValidateEmail(value);
                ValidatePhoneNumber(value);
                ValidateDate(value);
                ValidateHTML(value);
            }
        }

        public static bool ValidateWRegEx(string valueType, string regExString, string input)
        {
            Regex regEx = new Regex(regExString);

            if (regEx.IsMatch(input))
            {
                Console.WriteLine($"{input} is a {valueType}.");
                return true;
            }
            else
            {
                Console.WriteLine($"{input} is not a {valueType}.");
                return false;
            }
        }

        public static bool ValidateName(string input)
        {
            bool isValid = ValidateWRegEx("name", @"[A-Z]{1}[a-z]{0,29}", input);
            return isValid;
        }

        public static bool ValidateEmail(string input)
        {
            bool isValid = ValidateWRegEx("email address", @"[a-z]{5,30}@[a-z]{5,10}\.[a-z]{2,3}", input);
            return isValid;
        }

        public static bool ValidatePhoneNumber(string input)
        {
            bool isValid = ValidateWRegEx("phone number", @"\d{3}-\d{3}-\d{4}", input);
            return isValid;
        }

        public static bool ValidateDate(string input)
        {
            bool isValid = ValidateWRegEx("date", @"(([0-2][\d])|(3[01]))\/(([0][\d])|([1][12]))\/(19|20)\d{2}", input);
            return isValid;
        }

        public static bool ValidateHTML(string input)
        {
            bool isValid = ValidateWRegEx("HTML tag", @"<([A-Za-z]{0,10})><\/\1>", input);
            return isValid;
        }
    }
}
