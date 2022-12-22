using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItPartnerPractice.Entities
{
    public partial class Orders
    {
        public String NumberOfOrder
        {
            get
            {
                var numberOfOrder ="Номер заказа: "+ OrderId;
                return numberOfOrder;
            }
        }
        public String OrderClient
        {
            get
            {
                var orderClient = "Заказчик: " + Clients.NameOfClient;
                return orderClient;
            }
        }
        public String StatusOfTheOrder
        {
            get
            {
                var orderStatus = "Статус: " + OrderStatus.OrderStatusName;
                return orderStatus;
            }
        }
    }
}
