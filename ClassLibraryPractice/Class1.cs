using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPractice
{
    public class CheckErrors
    {
        public static string InRegister(string login, string password, string repeatPassword, string name , string surname)
        {
            string errorMessage = "";
            if (string.IsNullOrWhiteSpace(login)|| string.IsNullOrWhiteSpace(password)||string.IsNullOrWhiteSpace(repeatPassword)||
                string.IsNullOrWhiteSpace(name)||string.IsNullOrWhiteSpace(surname))
            {
                errorMessage = "Заполните все поля!";
            }
            return errorMessage;
        }
    }
}
