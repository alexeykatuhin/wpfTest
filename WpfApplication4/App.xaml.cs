using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using WpfApplication4.Model;
using WpfApplication4.ViewModel;
using WpfApplication4.ViewModel.Base;

namespace WpfApplication4
{
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			IUnityContainer container = new UnityContainer();
			container.RegisterType<IDrinkService, DrinkService>();
			container.Resolve<MainWindow>().Show();

		}
	}
}
