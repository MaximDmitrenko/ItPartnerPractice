using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ItPartnerPractice.Entities
{
    public partial class Services
    {
        public String NameService
        {
            get
            {
                String nameService = "Название:" + ServiceName;
                return nameService;
            }
        }
        public String DescriptionService
        {
            get
            {
                String descriptionService = "Описание:" + ServiceDescription;
                return descriptionService;
            }
        }
        public String PriceService
        {
            get
            {
                String priceService = "Цена: " + ServicePrice.ToString() + " руб.";
                return priceService;
            }
        }
        public String ImageService
        {
            get
            {
                String log = System.AppDomain.CurrentDomain.BaseDirectory + ServicePhoto;
                if (!File.Exists(log))
                {
                    log = System.AppDomain.CurrentDomain.BaseDirectory + "Images\\NoImage.png"; 
                    return log;
                }
                else
                {
                    log = System.AppDomain.CurrentDomain.BaseDirectory + ServicePhoto;
                    return log;
                }
            }
        }
    }
}
