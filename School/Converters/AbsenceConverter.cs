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
    class AbsenceConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if ((values[0] != null && values[1] != null && values[2] != null && values[3] != null) &&
                (!values[0].Equals("") && !values[1].Equals("") && !values[2].Equals("") && !values[3].Equals("")))
            {
                bool is_justified;
                bool result_is_justified = bool.TryParse(values[2].ToString(), out is_justified);

                bool can_be_justified;
                bool result_can_be_justified = bool.TryParse(values[2].ToString(), out can_be_justified);

                System.DateTime dateTime;

                bool result_date = System.DateTime.TryParse(values[1].ToString(), out dateTime);
                if (result_can_be_justified && result_is_justified && result_date)
                {
                    return new AbsenceVM()
                    {
                        IdAbsence = int.Parse(values[0].ToString()),
                        Date = dateTime,
                        IsJustified = is_justified,
                        CanBeJustified = can_be_justified

                    };
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            AbsenceVM absence = value as AbsenceVM;
            object[] result = new object[4]
            {
                absence.IdAbsence, 
                absence.Date, 
                absence.IsJustified, 
                absence.CanBeJustified
            };
            return result;
        }
    }

}
