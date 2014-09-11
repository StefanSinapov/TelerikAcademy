using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfServiceCalculator.Console
{
    [ServiceContract]
    public interface IServiceCalculator
    {
        [OperationContract]
        int Calculate(int firstValue, int secondValue, CalculationOperation operationType);
    }

    [DataContract]
    public enum CalculationOperation
    {
        [EnumMember]
        Add,
        [EnumMember]
        Substract,
        [EnumMember]
        Multiply,
        [EnumMember]
        Divide
    }
}
