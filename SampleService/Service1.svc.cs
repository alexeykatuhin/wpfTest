using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SampleService
{
	// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
	// ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
	public class Service1 : IService1
	{
		//немного не понял, что значит список всех напитков и какова его связь с получаемым id, поэтому сделал просто список id некоторых напитков
		List<int> idList= new List<int>()
		{
			1,3,5,7,9,11
		};

		public int CheckData(int id)
		{
			if (idList.Any(x => x == id))
				return 1;
			return 0;
		}

		public string TestConnection()
		{
			return "OK";
		}
	}

	
}
