using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public interface IInputVerification
    {

        Task<bool> VerifyInput(Person person);

        bool TestVerifyInput(Person person);

    }
}
