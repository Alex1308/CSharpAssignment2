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

        private PersistenceManager pManager;

        public InputVerification()
        {
            pManager = new PersistenceManager();
        }

        public async Task<bool> VerifyInput(List<string> data)
        {

            //Potentially implement better error messages using enumerator
            return CheckEmpty(data) & CheckNames(data[0], data[1]) & CheckEmail(data[2]) & CheckPhoneNumber(data[3]) & CheckSerial(data[5]);
        }

        private bool CheckSerial(string serial)
        {
            Debug.WriteLine("Serial check verifier side");
            return pManager.PCheckSerial(serial);
        }

        private bool CheckPhoneNumber(string number)
        {
            //Could check length, but would invalidate some foreign numbers. Assignment doesn't specify danes only.
            if (!number.All(char.IsDigit))
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
