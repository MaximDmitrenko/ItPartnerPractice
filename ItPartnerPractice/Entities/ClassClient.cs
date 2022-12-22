using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItPartnerPractice.Entities
{
    public partial class Clients
    {
        public String NameOfClient
        {
            get
            {
                var nameOfClient = "ФИО: "+ClientName;
                return nameOfClient;
            }
        }
        public String PhoneOfClient
        {
            get
            {
                var phoneOfClient = "Телефон: "+ClientPhone;
                return phoneOfClient;
            }
        }
        public String MailOfClient
        {
            get
            {
                var mailOfClient = "Почта:" + ClientMail;
                return mailOfClient;
            }
        }
    }
}
