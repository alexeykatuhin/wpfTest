using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApplication4.Classes
{
	[ValueConversion(typeof(double), typeof(string))]
	class CostConverter: IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter,
		   System.Globalization.CultureInfo culture)
		{
			// Возвращаем строку в формате 123.456.789 руб.
			return ((double)value) + " руб.";
		}

		public object ConvertBack(object value, Type targetType, object parameter,
			System.Globalization.CultureInfo culture)
		{

			return value;
		}
	}
}
