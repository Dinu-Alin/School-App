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
    class TeacherConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if ((values[0] != null && values[1] != null && values[2] != null && values[3] != null && values[4] != null) &&
                (!values[0].Equals("") && !values[1].Equals("") && !values[2].Equals("") && !values[3].Equals("") && !values[4].Equals("")))
            {
                return new TeacherVM()
                {
                    IdTeacher = int.Parse(values[0].ToString()),
                    Person = new PersonVM()
                    {
                        FirstName = values[1].ToString(),
                        LastName = values[2].ToString(),
                        Username = values[3].ToString(),
                        Password = values[4].ToString()
                    }
                };
            }
            else
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            TeacherVM teacher = value as TeacherVM;
            object[] result = new object[5]
            {
                teacher.IdTeacher,
                teacher.Person.FirstName,
                teacher.Person.LastName,
                teacher.Person.Username,
                teacher.Person.Password
            };
            return result;
        }
    }
}
