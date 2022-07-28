using System;

namespace PTC.Application.Extentions
{
    public static class ApplicationFormatExtentions
    {
        public static string DoFormat(this decimal value)
        {
            return value.ToString("C");
        }

        public static DateTime? DoFormat(this DateTime? value)
        {
            return value is not null ? Convert.ToDateTime(Convert.ToDateTime(value).ToString("dd/MM/yyyy")).Date : null;
        }
    }
}
