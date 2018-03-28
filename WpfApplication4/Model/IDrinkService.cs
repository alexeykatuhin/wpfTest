using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication4.Model
{
	interface IDrinkService
	{
		IEnumerable<Drink> GetDrinks();
		void UpdateDrink(Drink drink);
	}
}
