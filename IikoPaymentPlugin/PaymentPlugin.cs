using Resto.Front.Api.V5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace IikoPaymentPlugin
{
    class PaymentPlugin : MarshalByRefObject, IFrontPlugin
    {
        private readonly Stack<IDisposable> subscriptions = new Stack<IDisposable>();

        public PaymentPlugin()
        {
            //PluginContext.Log.Info("Initializing PaymentPlugin");

            //var point = PluginContext.Operations.GetHostTerminalPointsOfSale();
            subscriptions.Push(new PaymentExtender());
        }

        public void Dispose()
        {
            while (subscriptions.Any())
            {
                var subscription = subscriptions.Pop();
                try
                {
                    subscription.Dispose();
                }
                catch (RemotingException)
                {
                    // nothing to do with the lost connection
                }
            }
        }
    }
}
