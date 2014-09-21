namespace Substring.Console
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using Services;
    using ServiceSubstring;

    class SubstringConsoleDemo
    {
        private const string HostUrl = "http://localhost:8733/Design_Time_Addresses/Substring.Services/";

        static void Main()
        {
            try
            {
                // Try to open host -> if host is already open it's throws an exception
                using (var selfHost = HostSubstringModuleService())
                {
                    selfHost.Open();
                    GetNumberOfSubstrings();
                }
            }
            catch (Exception)
            {
                // Use already opened host
                GetNumberOfSubstrings();
            }
        }

        private static ServiceHost HostSubstringModuleService()
        {
            var serviceAddress = new Uri(HostUrl);
            var smb = new ServiceMetadataBehavior
            {
                HttpGetEnabled = true
            };

            var selfHost = new ServiceHost(typeof(SubstringService), serviceAddress);
            selfHost.Description.Behaviors.Add(smb);
            return selfHost;
        }

        private static void GetNumberOfSubstrings()
        {
            var client = new SubstringServiceClient();

            Console.Write("Text: ");
            var text = Console.ReadLine();

            Console.Write("Substring: ");
            var substring = Console.ReadLine();

            Console.WriteLine("Number of substrings: " + client.GetNumberOfSubstrings(text, substring));
        }
    }
}
