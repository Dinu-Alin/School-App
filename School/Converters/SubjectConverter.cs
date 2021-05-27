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
    class SubjectConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if ((values[0] != null && values[1] != null && values[2] != null ) &&
                (!values[0].Equals("") && !values[1].Equals("") && !values[2].Equals("")))
            {
                return new SubjectVM()
                {
                    IdSubject = int.Parse(values[0].ToString()),
                    Name = values[1].ToString(),
                    Term = int.Parse(values[2].ToString())
                };
            }
            else
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            SubjectVM subject = value as SubjectVM;
            object[] result = new object[3]
            {
                subject.IdSubject,
                subject.Name,
                subject.Term
            };
            return result;
        }
    }
}
