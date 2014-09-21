namespace DayPicker.Console
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using DayPickerService;

    public class DayPickerConsole
    {
        public static void Main()
        {
            const string url = "http://localhost:8733/Design_Time_Addresses/DayPicker/Services/DayPicker/";

            try
            {
                // Try to open host -> if host is already opened it's throws an exception
                using (var selfHost = HostSubstringModuleService(url))
                {
                    selfHost.Open();
                    ShowDayOfWeek();
                }
            }
            catch (Exception)
            {
                // Use already opened host
                ShowDayOfWeek();
            }
        }

        private static ServiceHost HostSubstringModuleService(string url)
        {
            var serviceAddress = new Uri(url);
            var smb = new ServiceMetadataBehavior
            {
                HttpGetEnabled = true
            };

            var selfHost = new ServiceHost(typeof(Services.DayPickerService), serviceAddress);
            selfHost.Description.Behaviors.Add(smb);
            return selfHost;
        }

        private static void ShowDayOfWeek()
        {
            var client = new DayPickerServiceClient();
            var date = DateTime.Now;
            Console.WriteLine("{0:d} -> {1}", date, client.GetDayOfWeek(date));
        }
    }
}
