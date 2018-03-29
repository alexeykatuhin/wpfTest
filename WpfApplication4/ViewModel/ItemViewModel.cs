using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication4.Command;
using WpfApplication4.Model;
using WpfApplication4.ViewModel.Base;

namespace WpfApplication4.ViewModel
{
	public class ItemViewModel: AViewModel
	{

		private Drink drink;

		private IDrinkService service;
		public ItemViewModel(IDrinkService service) : base(service)
		{
			this.service = service;
			Sum = 0;
		}


		#region commnds

		

		
		private MainCommand _SetMoney;
		public MainCommand SetMoney
		{
			get
			{
				return _SetMoney ?? (_SetMoney = new MainCommand(obj =>
				{
					Sum += int.Parse(obj.ToString());
				}, (obj) =>
				{
					return true;
				}));
			}
		}

		private MainCommand _PayCommand;
		public MainCommand PayCommand
		{
			get
			{
				return _PayCommand ?? (_PayCommand = new MainCommand(obj =>
				{
					Drink.Quantity -= SelectedItem;
					Repo.UpdateDrink(Drink);	
				}, (obj) =>
				{
					
   					if (Sum  < Drink.Price*SelectedItem)
						return false;
					return true;
				}));
			}
		}
		#endregion
		#region props

		private int sum =0;

		private int _Id;
		public int Id
		{
			get
			{
				return _Id;
			}

			set
			{
				_Id = value;
				OnPropertyChanged("Id");
			}
		}



		

		public Drink Drink
		{
			get
			{
				return drink;
			}

			set
			{
				drink = value;
				OnPropertyChanged("Drink");
			}
		}
		public override event PropertyChangedEventHandler PropertyChanged;
		protected override void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(prop));

			}
		}
		//private event PropertyChangedEventHandler PropertyChanged;
		public List<int> QuantityList
		{
			get
			{
				List<int> res = new List<int>();
				for (int i = 0; i < drink.Quantity; i++)
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

		private List<int> quantityList;

		private int selectedItem=1;

		#endregion
	}
}
