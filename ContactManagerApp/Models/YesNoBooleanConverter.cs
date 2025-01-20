using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManagerApp.Models
{
    public class YesNoBooleanConverter : ITypeConverter
    {
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.Equals(text, "Yes", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            if (string.Equals(text, "No", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            return false; // Default to false if it's neither Yes nor No
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return (bool)value ? "Yes" : "No";
        }
    }
}