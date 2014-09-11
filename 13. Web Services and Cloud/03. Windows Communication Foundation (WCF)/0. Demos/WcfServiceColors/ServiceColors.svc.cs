using System;
using System.ServiceModel;

namespace WcfServiceColors
{
    [ServiceContract]
    public class ServiceColors
    {
        [OperationContract]
        public string GetColorARGB(string colorName)
        {
            if (colorName == "Red")
            {
                return "#FF00AA";
            }

            return null;
        }
    }
}
