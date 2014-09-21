namespace DayPicker.Services
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDayPickerService
    {
        [OperationContract]
        string GetDayOfWeek(DateTime date);
    }
}