using System;
using System.Globalization;

namespace Consulting.Common.Utility
{
    public sealed class DateConvertor
    {
        private const string Format = "{0}/{1}/{2} {3}:{4}:{5} ";
        public static readonly DateConvertor Instance = new DateConvertor();

        public string ConvertGregorianToPersianDatetime(DateTime dateTime)
        {
            var persianCalander = new PersianCalendar();
            return string.Format("{0}/{1}/{2} {3}:{4}:{5}", persianCalander.GetYear(dateTime),
                persianCalander.GetMonth(dateTime), persianCalander.GetDayOfMonth(dateTime), persianCalander.GetHour(dateTime),
                persianCalander.GetMinute(dateTime), persianCalander.GetSecond(dateTime));
        }

        public DateTime ConvertPersianDatetimeToGregorian(string pdatetime)
        {
            DateTime Persiandatetime = Convert.ToDateTime(pdatetime);
            PersianCalendar pcalender = new PersianCalendar();
            DateTime resultdate = pcalender.ToDateTime(Persiandatetime.Year, Persiandatetime.Month, Persiandatetime.Day, Persiandatetime.Hour, Persiandatetime.Minute, Persiandatetime.Second, Persiandatetime.Millisecond);
            return resultdate;
        }

        public DateTime ConvertPersianDatetimeToGregorian(DateTime Persiandatetime)
        {
            PersianCalendar pcalender = new PersianCalendar();
            DateTime resultdate = pcalender.ToDateTime(Persiandatetime.Year, Persiandatetime.Month, Persiandatetime.Day, Persiandatetime.Hour, Persiandatetime.Minute, Persiandatetime.Second, Persiandatetime.Millisecond);
            return resultdate;
        }

        public int GetPersianYear(DateTime time)
        {
            var persianCalander = new PersianCalendar();
            return persianCalander.GetYear(time);
        }

        public int GetPersianDay(DateTime time)
        {
            var persianCalander = new PersianCalendar();
            return persianCalander.GetDayOfMonth(time);
        }

        public int GetPersianMonth(DateTime time)
        {
            var persianCalander = new PersianCalendar();
            return persianCalander.GetMonth(time);
        }

        public string ConvertGregorianToPersianDate(DateTime dateTime)
        {
            var persianCalander = new PersianCalendar();
            return string.Format(Format, persianCalander.GetYear(dateTime).ToString("0000"),
                persianCalander.GetMonth(dateTime).ToString("00"), persianCalander.GetDayOfMonth(dateTime).ToString("00"), persianCalander.GetHour(dateTime).ToString("00"),
               persianCalander.GetMinute(dateTime).ToString("00") , persianCalander.GetSecond(dateTime).ToString("00"));
        }

        public string GetPersianTime(DateTime dateTime)
        {
            var persianCalander = new PersianCalendar();
            return string.Format("{0}:{1}:{2}", persianCalander.GetHour(dateTime).ToString("00"),
                persianCalander.GetMinute(dateTime).ToString("00"), persianCalander.GetSecond(dateTime).ToString("00"));
        }

        public bool IsLeapYear(DateTime date)
        {
            var persianCalander = new PersianCalendar();
            var year = this.GetPersianYear(date);
            return persianCalander.IsLeapYear(year);
        }

    }
}
