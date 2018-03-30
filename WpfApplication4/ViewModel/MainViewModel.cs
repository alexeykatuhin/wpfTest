using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApplication4.Annotations;
using WpfApplication4.Command;
using WpfApplication4.Model;
using WpfApplication4.ViewModel.Base;

namespace WpfApplication4.ViewModel
{
	class MainViewModel:AViewModel
	{

		public MainViewModel(IDrinkService serv) : base(serv)
		{
		}


	

	}
}
