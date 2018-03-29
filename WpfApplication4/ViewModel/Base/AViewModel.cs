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

		private IDrinkService serv;
		public AViewModel(IDrinkService serv):base(serv)
		{
			this.serv = serv;
			//drinks = Service.DrinkService.GetDrinks();
			Drinks = Repo.GetDrinks();
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
			var viewmodel = this.GetViewModel("MainViewModel");
			Current_ViewModel = viewmodel;
			//switch (obj)
			//{
			//	case "ExitCommand":
			//		Application.Current.Shutdown();
			//		break;
			//	default:
			//		Current_ViewModel = this.GetViewModel(obj);
			//		break;
			//}
		}
		private void OnSelectViewCommandMulti(int obj)
		{
			Current_ViewModel = this.GetViewModel("ItemViewModel");
			(Current_ViewModel as ItemViewModel).Drink = Drinks.First(x=>x.Id == obj);
		}

		private ViewModelBase _Current_ViewModel;
		public ViewModelBase Current_ViewModel
		{
			get { return _Current_ViewModel; }
			set { _Current_ViewModel = value; OnPropertyChanged("Current_ViewModel"); }
		}


	}
}
