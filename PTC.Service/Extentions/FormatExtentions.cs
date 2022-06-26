using System;

namespace PTC.Application.Extentions
{
    public static class FormatExtentions
    {
        public static string DoFormat(this decimal value)
        {
            return value.ToString("C");
        }

        public static DateTime? DoFormat(this DateTime? value)
        {
            return !(value is null) ? Convert.ToDateTime(Convert.ToDateTime(value).ToString("dd/MM/yyyy")).Date : null; 
        }
    }
}
