using IikoPaymentPlugin.APIModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IikoPaymentPlugin.View
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClientWindow()
        {
            InitializeComponent();
        }

        public void SetClient(ClientModel client)
        {
            fullNameCell.InfoText = string.Format("{0} {1}", client.LastName, client.FirstName);
            balanceCell.InfoText = client.BalanceCashback.ToString();
            percentCell.InfoText = client.PercentageCashback + "%";
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Использовать баллы?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //do no stuff
            }
            else
            {
                //do yes stuff
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
