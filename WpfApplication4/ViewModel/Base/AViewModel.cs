using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WpfApplication4.Classes;
using WpfApplication4.Command;
using WpfApplication4.Model;

namespace WpfApplication4.ViewModel.Base
{
	public abstract class AViewModel : ViewModelBase
	{
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
		public string Name { get; set; }
		public RelayCommand<string> SelectViewCommand { get; set; }
		public RelayCommand<int> SelectItemCommand { get; set; }

		public AViewModel()
		{
			drinks = Service.DrinkService.GetDrinks();

			SelectItemCommand = new RelayCommand<int>(OnSelectViewCommandMulti);
			SelectViewCommand = new RelayCommand<string>(OnSelectViewCommand);
		}

		private static ObservableCollection<ViewModelBase> _ViewModels;
		public static ObservableCollection<ViewModelBase> ViewModels
		{
			get { return _ViewModels; }
			set { _ViewModels = value; }
		}

		public void AddViewModel(ViewModelBase viewmodel)
		{
			if (ViewModels == null)
				ViewModels = new ObservableCollection<ViewModelBase>();

			var currentVNs = (from vms in ViewModels where vms.InternalName == viewmodel.InternalName select vms).FirstOrDefault();
			if (currentVNs == null)
				ViewModels.Add(viewmodel);
		}

		public ViewModelBase GetViewModel(string viewmodel)
		{
			return ViewModels.FirstOrDefault(item => item.InternalName == viewmodel);
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
		private void OnSelectViewCommandMulti(int obj)
		{
			Id = obj;
			Current_ViewModel = this.GetViewModel("ItemViewModel");
		}

		private ViewModelBase _Current_ViewModel;
		public ViewModelBase Current_ViewModel
		{
			get { return _Current_ViewModel; }
			set { _Current_ViewModel = value; OnPropertyChanged("Current_ViewModel"); }
		}

		public int Id
		{
			get
			{
				return id;
			}

			set
			{
				id = value; OnPropertyChanged("Id");
			}
		}

		private int id;
	}
}
