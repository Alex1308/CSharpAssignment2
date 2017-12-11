using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssignment2
{
    class SerialGenerator
    {

        private List<Guid> serialNumbers;


        public SerialGenerator(int repeatNumber)
        {
            serialNumbers = new List<Guid>();

            for (int i = 0; i < repeatNumber; i++)
            {
                serialNumbers.Add(Guid.NewGuid());
            }
        }

        public List<Guid> SerialNumbers
        {
            get
            {
                return serialNumbers;
            }

            set
            {
                serialNumbers = value;
            }
        }
    }
}
