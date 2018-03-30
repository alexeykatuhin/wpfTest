using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using WpfApplication4.Annotations;
using WpfApplication4.Classes;
using WpfApplication4.Command;
using WpfApplication4.Model;

namespace WpfApplication4.ViewModel.Base
{
	public abstract class AViewModel : INotifyPropertyChanged
	{
		public AViewModel(IDrinkService serv)
		{
			Repo = serv;
			Drinks = Repo.GetDrinks();
			SelectViewCommand = new RelayCommand<int?>(OnSelectViewCommand, CanExecute);
		}

		#region Commands

		

		public RelayCommand<int?> SelectViewCommand { get; set; }
		private bool CanExecute(int? i)
		{
			if (i == null)
				return true;
			if (Drinks.First(x => x.Id == i.Value).Quantity == 0)
				return false;
			return true;
		}

		private static ObservableCollection<AViewModel> _ViewModels;
		public static ObservableCollection<AViewModel> ViewModels
		{
			get { return _ViewModels; }
			set { _ViewModels = value; }
		}
		private void OnSelectViewCommand(int? obj)
		{
			if (obj == null)
			{
		
				Current_ViewModel = GetViewModel("MainViewModel");
				Drinks = Repo.GetDrinks();
				return;
			}
			Current_ViewModel = this.GetViewModel("ItemViewModel");
			(Current_ViewModel as ItemViewModel).SelectedDrink = Drinks.First(x=>x.Id == obj);
		}


		#endregion
		#region Properties

		private IEnumerable<Drink> drinks;

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


		public IDrinkService Repo { get; }

		private AViewModel _Current_ViewModel;
		public AViewModel Current_ViewModel
		{
			get { return _Current_ViewModel; }
			set { _Current_ViewModel = value; OnPropertyChanged("Current_ViewModel"); }
		}



		public string Name { get; set; }


		#endregion
		#region Methods
		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void AddViewModel(AViewModel viewmodel)
		{
			if (ViewModels == null)
				ViewModels = new ObservableCollection<AViewModel>();
			ViewModels.Add(viewmodel);
		}

		public AViewModel GetViewModel(string viewmodel)
		{
			return ViewModels.FirstOrDefault(item => item.Name == viewmodel);
		}
		#endregion





	}
}
