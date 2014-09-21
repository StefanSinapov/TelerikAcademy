namespace Substring.Services
{
    using System.ServiceModel;

    [ServiceContract]
    public interface ISubstringService
    {
        [OperationContract]
        int GetNumberOfSubstrings(string text, string substring);
    }
}