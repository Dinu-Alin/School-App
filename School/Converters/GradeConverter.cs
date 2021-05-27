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
    class GradeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if ((values[0] != null && values[1] != null && values[2] != null && values[3] != null) &&
                (!values[0].Equals("") && !values[1].Equals("") && !values[2].Equals("") && !values[3].Equals("")))
            {


                System.DateTime dateTime;

                bool result_date = System.DateTime.TryParse(values[1].ToString(), out dateTime);

                bool isMidterm;
                bool result_is_midterm = bool.TryParse(values[3].ToString(), out isMidterm);

                if(result_is_midterm && result_date)
                {
                    return new GradeVM()
                    {
                        IdGrade = int.Parse(values[0].ToString()),
                        Date = dateTime,
                        Mark = int.Parse(values[2].ToString()),
                        IsMidterm = isMidterm
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
            GradeVM grade = value as GradeVM;
            object[] result = new object[4]
            {
                grade.IdGrade,
                grade.Date,
                grade.Mark,
                grade.IsMidterm
            };
            return result;
        }
    }
}
