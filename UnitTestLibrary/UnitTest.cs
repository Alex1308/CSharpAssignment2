using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using ProjectLibrary;

namespace UnitTestLibrary
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInputVerification()
        {
            //Setup
            IInputVerification ver = new InputVerification();
            Person testPerson = new Person();
            testPerson.firstName = "Alex";
            testPerson.surName = "Gehling";
            testPerson.emailAddress = "alexgehling@gmail.com";
            testPerson.dateOfBirth = new DateTimeOffset(new DateTime(1995, 8, 13));
            testPerson.phoneNumber = "12345678";

            //Test verification of input
            Assert.IsTrue(ver.TestVerifyInput(testPerson));

        }
    }
}
