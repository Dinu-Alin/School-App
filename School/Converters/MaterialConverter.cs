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
    class MaterialConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if ((values[0] != null && values[1] != null && values[2] != null) &&
                (!values[0].Equals("") && !values[1].Equals("") && !values[2].Equals("")))
            {
                return new MaterialVM()
                {
                    IdMaterial = int.Parse(values[0].ToString()),
                    Type = values[1].ToString(),
                    Link = values[2].ToString()
                };
            }
            else
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            MaterialVM material = value as MaterialVM;
            object[] result = new object[3]
            {
                material.IdMaterial, 
                material.Type, 
                material.Link
            };
            return result;
        }
    }
}
