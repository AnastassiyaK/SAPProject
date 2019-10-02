using Newtonsoft.Json;
using System;

namespace SAPBusiness.TilesData
{
    public class Tile
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("isRequiredLicense")]
        public bool HasLicenseTag { get; set; }

        [JsonProperty("taskType")]
        public string Type { get; set; }

        [JsonProperty("time")]
        private string TimeString { get; set; }

        public string Time
        {
            get
            {
                return GetTimeString();
            }
        }

        private string GetTimeString()
        {
            TimeSpan time = TimeSpan.FromSeconds(int.Parse(TimeString));
            var hours = time.Hours;
            var minutes = time.Minutes;
            string timeFormat = "";

            if (hours != 0 && minutes == 0)
            {
                return hours + " hr.";
            }
            else if (hours == 0 && minutes != 0)
            {
                return minutes + " min.";
            }
            else if (hours !=0 && minutes != 0)
            {
                timeFormat = hours + " hr. " + minutes + " min.";
                return timeFormat;
            }
            return timeFormat;
        }
    }
}
