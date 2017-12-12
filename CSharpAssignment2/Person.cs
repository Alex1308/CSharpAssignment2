using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssignment2
{
    
    public class Person
    {
        public string firstName { get; set; }
        public string surName { get; set; }
        public string emailAddress { get; set; }
        public string phoneNumber { get; set; }
        public DateTimeOffset dateOfBirth { get; set; }
        public string serialNumber { get; set; }

        public Person(string firstName, string surName, string emailAddress, string phoneNumber, DateTimeOffset dateOfBirth, string serialNumber)
        {
            this.firstName = firstName;
            this.surName = surName;
            this.emailAddress = emailAddress;
            this.phoneNumber = phoneNumber;
            this.dateOfBirth = dateOfBirth;
            this.serialNumber = serialNumber;
        }

        public Person()
        {

        }

        public override string ToString()
        {
            string stringToReturn =
                "First Name: " + firstName +
                " | Sur Name: " + surName +
                " | Email Address: " + emailAddress +
                " | Phone Number: " + phoneNumber +
                " | Date of Birth: " + dateOfBirth.ToString() +
                " | Serial number: " + serialNumber;
            return stringToReturn;
        }
    }
}
