using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication4.Annotations;
using WpfApplication4.Command;
using WpfApplication4.Model;

namespace WpfApplication4.ViewModel
{
	class MainViewModel:BaseViewModel

	{
		private IEnumerable<Drink> drinks;
		public MainViewModel()
		{
			drinks = new DrinkService().GetDrinks();
		}




		private BaseViewModel viewModel;
		public BaseViewModel ViewModel
		{
			get
			{
				return viewModel;
			}
			set
			{
				viewModel = value;
				OnPropertyChanged("ViewModel");
			}
		}
		public ICommand DisplayPersonView
		{
			get
			{
				return new MainCommand(action => ViewModel = new ViewModelB());
			}
		}

		public IEnumerable<Drink> Drinks
		{
			get
			{
				return drinks;
			}

			set
			{
				drinks = value;
				OnPropertyChanged("Drinks");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
