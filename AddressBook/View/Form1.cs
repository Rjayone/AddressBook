using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApplication1.DAO;
using AddressBook.Models;

namespace AddressBook
{

	//Перечисление доступных колонок
	enum Sections
	{
		CitySection,
		AddressSection,
		FirstNameSection,
		LastNameSection,
		PhoneSection
	};

	public partial class Form1 : Form
	{
		AdressDAO addresses = new AdressDAO();
		PersonDAO persons = new PersonDAO();
		CityDAO cities = new CityDAO();

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			List<adress> address = addresses.ReadAll();
			
			List<city> city = cities.ReadAll();

			for (int section = 0; section < tableView.Columns.Count; section++)
			{
				if (section == (int)Sections.CitySection)
				{
					for (int j = 0; j < city.Count; j++)
					{
						city person = address[j].city;
						tableView[j, (int)Sections.CitySection].Value = city[j].name;
					}
				}

				if(section == (int)Sections.AddressSection)
				{
					for (int j = 0; j < city.Count; j++)
					{
						string addressString = address[j].street + " " + address[j].house + ", " +address[j].flat;
						tableView[j, (int)Sections.CitySection].Value = addressString;
					}
				}

				if (section == (int)Sections.FirstNameSection)
				{
					for (int j = 0; j < city.Count; j++)
					{
						string person = address[j].person.firstName;
						tableView[j, (int)Sections.CitySection].Value = person;
					}
				}

				if (section == (int)Sections.LastNameSection)
				{
					for (int j = 0; j < city.Count; j++)
					{
						string person = address[j].person.lastName;
						tableView[j, (int)Sections.CitySection].Value = person;
					}
				}

				//if (section == (int)Sections.PhoneSection)
				//{
				//	for (int j = 0; j < city.Count; j++)
				//	{
				//		string person = address[j].;
				//		tableView[j, (int)Sections.CitySection].Value = person;
				//	}
				//}
			}
		}
	}
}
