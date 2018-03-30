using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Effects;
using System.Xml;
using System.Xml.Linq;
using WpfApplication4.ServiceReference1;

namespace WpfApplication4.Model
{
	class DrinkService:IDrinkService
	{

		string filepath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName + "\\data.xml";

		public IEnumerable<Drink> GetDrinks()
		{

			

			List<Drink> drinks = new List<Drink>();

			XmlDocument xDoc = new XmlDocument();
			xDoc.Load(filepath);
			//xDoc.Load(@"C:\Users\kav\Documents\Visual Studio 2015\Projects\WpfApplication4\WpfApplication4\data.xml");
			XmlElement xRoot = xDoc.DocumentElement;
			foreach (XmlElement xnode in xRoot)
			{

				var fsd = xnode.ChildNodes.Item(0);

				Drink drink = new Drink()
				{
					Id = int.Parse(xnode.ChildNodes.Item(0).InnerText),
					Name = xnode.ChildNodes.Item(1).InnerText,
					Description = xnode.ChildNodes.Item(2).InnerText,
					Price = double.Parse(xnode.ChildNodes.Item(3).InnerText),
					Type = xnode.ChildNodes.Item(4).InnerText == "Alcohol" ? TypeOfDrink.Alcohol : TypeOfDrink.NonAlcohol,
					Quantity = int.Parse(xnode.ChildNodes.Item(5).InnerText)
				};

				//SelectedDrink drink = new SelectedDrink()
				//{
				//	Id = int.Parse(xnode.Attributes.GetNamedItem("id").Value),
				//	Name = xnode.Attributes.GetNamedItem("name").Value,
				//	Description = xnode.Attributes.GetNamedItem("description").Value,
				//	Price = double.Parse(xnode.Attributes.GetNamedItem("price").Value),
				//	Type = xnode.Attributes.GetNamedItem("type").Value == "Alcohol"?TypeOfDrink.Alcohol : TypeOfDrink.NonAlcohol,
				//	Quantity = int.Parse(xnode.Attributes.GetNamedItem("quantity").Value)
				//};
				drinks.Add(drink);
			}
			return drinks;
		}

		public void UpdateDrink(Drink drink)
		{
			//XmlDocument xDoc = new XmlDocument();

			//xDoc.Load(filepath);
			//XmlElement xRoot = xDoc.DocumentElement;


			//foreach (XmlElement xnode in xRoot)
			//{
			//	if (int.Parse(xnode.ChildNodes.Item(0).InnerText) == drink.Id)
			//	{
					
			//		xnode.ChildNodes.Item(0).InnerText = drink.Quantity.ToString();
			//		break;
			//	}
			//}

			//xDoc.Save(filepath);

			/////////////
			XDocument doc = XDocument.Load(filepath);
			XNode node = doc.Root.FirstNode;
			while (node!=null)
			{
				XElement x = (XElement) node;
				XElement xx = (XElement) x.FirstNode;
				if (xx.Value == drink.Id.ToString())
				{
					XElement xxx =  ((XElement)x.LastNode);
					xxx.Value = drink.Quantity.ToString();
					break;
				}
				node = node.NextNode;

			}
			doc.Save(filepath);
			//////////////




			if (drink.Quantity == 0)
			{
				Service1Client client = new Service1Client("BasicHttpBinding_IService1");
					int resp = client.CheckData(drink.Id);
				MessageBox.Show("Был произведен запрос к службе. Ответ: " + resp);

			}

		}
	}
}
