using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace IikoPaymentPlugin
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        PaymentPlugin paymentPlagin;
        public App()
        {
            paymentPlagin = new PaymentPlugin();
        }
    }
}
