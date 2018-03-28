using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApplication4.Annotations;

namespace WpfApplication4.Model
{
	class Drink:IDrink, INotifyPropertyChanged
	{
		private int _id;
		private string _name;
		private string _description;
		private double _price;
		private TypeOfDrink _type;
		private int _quantity;

		public int Id
		{
			get { return _id; }
			set
			{
				_id = value;
				OnPropertyChanged("Id");
			}
		}

		public string Name
		{
			get { return _name; }
			set { _name = value;
				OnPropertyChanged("Name");
			}
		}

		public string Description
		{
			get { return _description; }
			set
			{
				_description = value;

				OnPropertyChanged("Description");
			}
		}

		public double Price
		{
			get { return _price; }
			set { _price = value;
				OnPropertyChanged("Price");
			}
		}

		public TypeOfDrink Type
		{
			get { return _type; }
			set { _type = value;
			
				OnPropertyChanged("Type");
			}
		}

		public int Quantity
		{
			get { return _quantity; }
			set { _quantity = value;
				OnPropertyChanged("Quantity");
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
