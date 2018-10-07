using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using IikoPaymentPlugin.View;
using IikoPaymentPlugin.APIModels.Response;
using Resto.Front.Api.V5.UI;
using Resto.Front.Api.V5;

namespace IikoPaymentPlugin
{
    class PaymentExtender : IDisposable
    {
        private readonly CompositeDisposable subscriptions;

        BarCodeScanWindow window;
        ClientWindow clientWindow;
        ClientModel currentClient;

        public PaymentExtender()
        {
            clientWindow = new ClientWindow();
            window = new BarCodeScanWindow();
            window.ClientWasReceived += SetClient;

            window.ShowDialog();
            //subscriptions = new CompositeDisposable
            //{
            //    PluginContext.Integration.AddButton(new Resto.Front.Api.V6.UI.Button("Сканировать баркод",  OpenBarCodeScanner)),
            //};
        }

        private void OpenBarCodeScanner(IViewManager viewManager, IReceiptPrinter receiptPrinter, IProgressBar progressBar)
        {
            window.Show();
        }

        public void Dispose()
        {
            subscriptions.Dispose();
        }

        private void SetClient(ClientModel client)
        {
            currentClient = client;
            clientWindow.SetClient(client);
            clientWindow.ShowDialog();
        }
    }
}
