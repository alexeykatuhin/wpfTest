using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WpfApplication4.Command;
using WpfApplication4.Model;
using WpfApplication4.ViewModel.Base;

namespace WpfApplication4.ViewModel
{
	public class ItemViewModel: AViewModel
	{



	
		public ItemViewModel(IDrinkService service) : base(service)
		{
			Sum = 0;
			SetMoney = new RelayCommand<string>(OnSetMoney);
			BackCommand = new RelayCommand<object>(OnBackCommand);
			PayCommand = new RelayCommand<object>(OnPayCommand, CanExecute);
		}


		#region Commands

		

		
		public RelayCommand<string> SetMoney { get; set; }
		public RelayCommand<object> BackCommand { get; set; }
		public RelayCommand<object> PayCommand { get; set; }

		private bool CanExecute(object o)
		{
			if (Sum < SelectedDrink.Price * SelectedItem)
				return false;
			return true;
		}

		private void OnSetMoney(string obj)
		{
			Sum += int.Parse(obj);
		}

		private void OnBackCommand(object obj)
		{
			Sum = 0;
			SelectedItem = 1;
			(obj as RelayCommand<int?>).Execute(null);
		}
		private void OnPayCommand(object obj)
		{
			SelectedDrink.Quantity -= SelectedItem;
			Repo.UpdateDrink(SelectedDrink);
			Sum = 0;
			SelectedItem = 1;
			(obj as RelayCommand<int?>).Execute(null);
		}
		#endregion

		#region Properties


		private Drink selectedDrink;

		public Drink SelectedDrink
		{
			get
			{
				return selectedDrink;
			}

			set
			{
				selectedDrink = value;
				OnPropertyChanged("SelectedDrink");
			}
		}
		private List<int> quantityList;
		public List<int> QuantityList
		{
			get
			{
				List<int> res = new List<int>();
				for (int i = 0; i < SelectedDrink.Quantity; i++)
				{
					res.Add(i + 1);

				}
				return res;
			}

			set
			{
				quantityList = value;
				OnPropertyChanged("QuantityList");
			}
		}


		private int sum = 0;
		public int Sum
		{
			get
			{
				return sum;
			}

			set
			{
				sum = value;
				OnPropertyChanged("Sum");
			}
		}

		public int SelectedItem
		{
			get
			{
				return selectedItem;
			}

			set
			{
				selectedItem = value;
			}
		}



		private int selectedItem = 1;
		#endregion
	}
}
