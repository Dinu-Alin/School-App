using School.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace School.Converters
{
    public class StudentConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if ((values[0] != null && values[1] != null && values[2] != null && values[3] != null && values[4] != null && values[5] != null) &&
                (!values[0].Equals("") && !values[1].Equals("") && !values[2].Equals("") && !values[3].Equals("") && !values[4].Equals("") && !values[5].Equals("")))
            {
                return new StudentVM()
                {
                    Id = int.Parse(values[0].ToString()),
                    Person = new PersonVM()
                    {
                        FirstName = values[1].ToString(),
                        LastName = values[2].ToString(),
                        Username = values[3].ToString(),
                        Password = values[4].ToString()
                    },
                    IdClass = int.Parse(values[5].ToString())
                };
            }
            else
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            StudentVM student = value as StudentVM;
            object[] result = new object[6]
            {
                student.Id,
                student.Person.FirstName,
                student.Person.LastName,
                student.Person.Username,
                student.Person.Password,
                student.IdClass
            };
            return result;
        }
    }
}
