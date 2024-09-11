/*
Time
The concept of time is dealt with in .NET using the DateTime struct. There are routines to convert between local time and UTC. Arithmetic can be performed with the help of TimeSpan.

Timezone
The TimeZoneInfo class provides routines for handling the differences between time zones. The TimeZoneInfo class also contains methods that facilitate dealing with daylight saving time.
The CultureInfo class supports locale dependent date time formats.
To support cross-platform coding the RuntimeInformation class allows you to detect which operating system your code is executing on, Linux, Windows or OSX.

Instructions
In this exercise you are back in the world of salons (first introduced in the datetimes exercise). As with a number of your projects another of your clients has had great success and opened outlets in London and Paris in addition to their New York base.
*/

using System;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            if (location == Location.Paris) 
            {
                TimeZoneInfo paris = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
                DateTime date = DateTime.Parse(appointmentDateDescription);

                DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(date, paris);
                return utcTime;
            }
            else if (location == Location.NewYork) 
            {
                TimeZoneInfo newYork = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime date = DateTime.Parse(appointmentDateDescription);

                DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(date, newYork);
                return utcTime;
            }
            else
            {
                TimeZoneInfo london = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
                DateTime date = DateTime.Parse(appointmentDateDescription);

                DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(date, london);
                return utcTime;
            }
        }
        else //Linux/Mac
        {
            if (location == Location.Paris)
            {
                TimeZoneInfo paris = TimeZoneInfo.FindSystemTimeZoneById("Europe/Paris");
                DateTime date = DateTime.Parse(appointmentDateDescription);

                DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(date, paris);
                return utcTime;
            }
            else if (location == Location.NewYork)
            {
                TimeZoneInfo newYork = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
                DateTime date = DateTime.Parse(appointmentDateDescription);

                DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(date, newYork);
                return utcTime;
            }
            else
            {
                TimeZoneInfo london = TimeZoneInfo.FindSystemTimeZoneById("Europe/London");
                DateTime date = DateTime.Parse(appointmentDateDescription);

                DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(date, london);
                return utcTime;
            }
        }
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        throw new NotImplementedException("Please implement the (static) Appointment.GetAlertTime() method");
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        throw new NotImplementedException("Please implement the (static) Appointment.HasDaylightSavingChanged() method");
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        throw new NotImplementedException("Please implement the (static) Appointment.NormalizeDateTime() method");
    }
}
