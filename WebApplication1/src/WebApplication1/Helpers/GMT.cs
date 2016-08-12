using System;

namespace WebApplication1.Helpers
{
    public static class GMT
    {
        public static DateTime Now
        {
            get
            {
                //return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"));
                return TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.Utc, TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"));
            }
        }
    }
}
