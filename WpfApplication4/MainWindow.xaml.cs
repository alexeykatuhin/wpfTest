﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication4.Classes;
using WpfApplication4.Model;
using WpfApplication4.ViewModel;

namespace WpfApplication4
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		//public MainWindow(IDrinkService service)
		//{
		//	InitializeComponent();

		//	Service.DrinkService = service;
		//	DataContext = new Base_ViewModel();
		//}

		public MainWindow()
		{
			InitializeComponent();

			//Service.DrinkService = service;
			//DataContext = new Base_ViewModel();
		}

	}
}
