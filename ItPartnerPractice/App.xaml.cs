using System.Windows;

namespace ItPartnerPractice
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Entities.ItPartner10Entities Context = new Entities.ItPartner10Entities();
        public static Entities.Users UserName = new Entities.Users();
    }
}
