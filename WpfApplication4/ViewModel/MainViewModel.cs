using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApplication4.Annotations;
using WpfApplication4.Command;
using WpfApplication4.Model;
using WpfApplication4.ViewModel.Base;

namespace WpfApplication4.ViewModel
{
	class MainViewModel:AViewModel

	{
		private MainCommand _CommandBtn;
		public MainCommand CommandBtn
		{
			get
			{
				return _CommandBtn ?? (_CommandBtn = new MainCommand(obj =>
				{
	
				}, (obj) =>
				{
					return true;
				}));
			}
		}
		private IEnumerable<Drink> drinks;

		public MainViewModel(IDrinkService serv) :base(serv)
		{
	
		}
		private void OnSelectViewCommand(string obj)
		{
			switch (obj)
			{
				case "ExitCommand":
					Application.Current.Shutdown();
					break;
				default:
					Current_ViewModel = this.GetViewModel(obj);
					break;
			}
		}





		//public IEnumerable<Drink> Drinks
		//{
		//	get
		//	{
		//		return drinks;
		//	}

		//	set
		//	{
		//		drinks = value;
		//		OnPropertyChanged("Drinks");
		//	}
		//}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
