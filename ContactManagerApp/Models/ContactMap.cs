using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManagerApp.Models
{
    public class ContactMap : ClassMap<Contact>
    {
        public ContactMap()
        {
            Map(m => m.Id).Ignore();  // Игнорируем поле Id, так как оно генерируется в базе данных
            Map(m => m.Name).Name("Name");
            Map(m => m.DateOfBirth).Name("DateOfBirth").TypeConverterOption.Format("dd.MM.yyyy");
            Map(m => m.Married).Name("Married");
            Map(m => m.Phone).Name("Phone");
            Map(m => m.Salary).Name("Salary");

            // Use custom YesNoBooleanConverter for the Married field
            Map(m => m.Married).Name("Married").TypeConverter<YesNoBooleanConverter>();
        }
    }
}