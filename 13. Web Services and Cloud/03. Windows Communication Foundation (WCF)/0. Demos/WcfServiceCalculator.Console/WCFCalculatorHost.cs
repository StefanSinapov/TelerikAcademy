using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WcfServiceCalculator.Console
{
    class WCFCalculatorHost
    {
        static void Main()
        {
            Uri serviceAddress = new Uri("http://localhost:1234/calc");
            ServiceHost selfHost = new ServiceHost(typeof(ServiceCalculator), serviceAddress);

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            selfHost.Description.Behaviors.Add(smb);

            using (selfHost)
            {
                selfHost.Open();
                System.Console.WriteLine("The service is started at endpoint " + serviceAddress);

                System.Console.WriteLine("Press [Enter] to exit.");
                System.Console.ReadLine();
            }
        }
    }
}
