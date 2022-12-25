using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibraryPractice;
namespace UnitTestPractice
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_Check_Empty_Fields()
        {
            string login = "login";
            string password = "";
            string repeatPassword = "password";
            string name = "name";
            string surname = "surname";
            string errorMessage = CheckErrors.InRegister(login, password, repeatPassword, name, surname);
            string res = "Заполните все поля!";
            Assert.AreEqual<string>(errorMessage, res);
        }
    }
}
