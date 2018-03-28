using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApplication4.Annotations;
using WpfApplication4.Model;
using WpfApplication4.ViewModel.Base;

namespace WpfApplication4.ViewModel
{
	public   class Base_ViewModel : AViewModel
	{

		public Base_ViewModel()
		{
			this.AddViewModel(new MainViewModel() { DisplayName = "Main", InternalName = "MainViewModel" });
			this.AddViewModel(new ItemViewModel() { DisplayName = "Item", InternalName = "ItemViewModel" });

			this.Current_ViewModel = this.GetViewModel("MainViewModel");
		}
	}
}
