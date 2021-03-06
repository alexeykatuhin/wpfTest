﻿using System;
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
			return ((double)value) + " руб.";
		}

		public object ConvertBack(object value, Type targetType, object parameter,
			System.Globalization.CultureInfo culture)
		{

			return value;
		}
	}

	[ValueConversion(typeof(int), typeof(string))]
	class CostConverterInt : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter,
		   System.Globalization.CultureInfo culture)
		{
			return ((int)value) + " руб.";
		}

		public object ConvertBack(object value, Type targetType, object parameter,
			System.Globalization.CultureInfo culture)
		{

			return value;
		}
	}
}
