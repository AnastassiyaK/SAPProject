namespace SAPBusiness.TilesData
{
    using System;

    public class TimeConverter : ITimeConverter
    {
        public string GetTime(int seconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
            var hours = timeSpan.Hours;
            var minutes = timeSpan.Minutes;
            string timeFormat = "";

            if (hours != 0 && minutes == 0)
            {
                return hours + " hr.";
            }
            else if (hours == 0 && minutes != 0)
            {
                return minutes + " min.";
            }
            else if (hours != 0 && minutes != 0)
            {
                timeFormat = hours + " hr. " + minutes + " min.";
                return timeFormat;
            }

            return timeFormat;
        }
    }
}
