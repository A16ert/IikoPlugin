using IikoPaymentPlugin.APIModels.Response;
using IikoPaymentPlugin.Services;
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
    /// Логика взаимодействия для BarCodeScanWindow.xaml
    /// </summary>
    public partial class BarCodeScanWindow : Window
    {
        private APIService apiService;
        private string barCode = string.Empty; //TO DO use a StringBuilder instead

        public Action<ClientModel> ClientWasReceived;

        public BarCodeScanWindow()
        {
            InitializeComponent();
            apiService = APIService.GetInstance();
        }

        private void Window_Loaded(System.Object sender, System.Windows.RoutedEventArgs e)
        {
            this.PreviewKeyDown += LabelBarCode_PreviewKeyDown;
        }

        private void LabelBarCode_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var keyBoard = e.KeyboardDevice;

            if ((44 == (int)e.Key)) e.Handled = true;
            barCode += e.Key;
            //look for a terminator char (different barcode scanners output different 
            //control characters like tab and line feeds), a barcode char length and other criteria 
            //like human typing speed &/or a lookup to confirm the scanned input is a barcode, eg.
            if (barCode.Length == 11)
            {
                barCodeTB.Text = barCode;
                GetClientInfo(barCode);
                barCode = string.Empty;
            }
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            //CollapseWindow();
        }

        private async void GetClientInfo(string barCode)
        {
            var clientInfo = await apiService.GetClientInfo(barCode);

            if(clientInfo.Status == "ok")
            {
                ClientWasReceived?.Invoke(clientInfo.Data);
            }
        }

        public void CollapseWindow()
        {
            barCode = string.Empty;
            this.Hide();
        }
    }
}
