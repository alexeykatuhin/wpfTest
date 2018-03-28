using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication4.Model
{
	enum TypeOfDrink
	{
		Alcohol =0,
		NonAlcohol=1
	}
	interface IDrink
	{
		 int Id { get; set; }
		string Name { get; set; }
		string Description { get; set; }
		double Price { get; set; }
		TypeOfDrink Type { get; set; }
		int Quantity { get; set; }

	}
}
