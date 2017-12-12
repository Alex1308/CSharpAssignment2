using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssignment2
{
    public class InputVerification
    {


        public InputVerification()
        {
        }

        public async Task<bool> VerifyInput(Person person)
        {

            //Potentially implement better error messages using enumerator
            return CheckNames(person.firstName, person.surName) & CheckEmail(person.emailAddress) & CheckPhoneNumber(person.phoneNumber) & CheckSerial(person.serialNumber);

        }

        private bool CheckSerial(string serial)
        {
            return PersistenceManager.Instance.PCheckSerial(serial);
        }

        private bool CheckPhoneNumber(string number)
        {
            //Check that length is less than or equal to 15, which is the accepted standard
            if (!number.All(char.IsDigit) & number.Length <= 15)
            {
                return false;
            }
            return true;
        }

        private bool CheckEmail(string email)
        {
            var mailValidater = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();
            return mailValidater.IsValid(email);
        }

        private bool CheckNames(string fName, string sName)
        {
            if (fName.Any(char.IsDigit) || sName.Any(char.IsDigit))
            {
                return false;
            }

            return true;
        }

        private bool CheckEmpty(List<string> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Equals(""))
                {
                    return false;
                }
            }
            return true;
        }


    }
}
