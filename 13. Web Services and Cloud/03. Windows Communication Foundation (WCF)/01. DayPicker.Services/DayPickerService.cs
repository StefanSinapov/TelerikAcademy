namespace DayPicker.Services
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class DayPickerService : IDayPickerService
    {
        public string GetDayOfWeek(DateTime date)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("bg-BG");
            return date.ToString("dddd");
        }
    }
}