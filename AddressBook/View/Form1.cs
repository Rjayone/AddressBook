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
			List<person> person = persons.ReadAll();
			List<city> city = cities.ReadAll();

			for (int section = 0; section < tableView.Columns.Count; section++)
			{
				if (section == (int)Sections.CitySection)
				{
					for (int j = 0; j < city.Count; j++)
					{
						tableView[j, (int)Sections.CitySection].Value = city[j].name;
					}
				}
			}
		}
	}
}
