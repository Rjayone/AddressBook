using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddressBook.Models;

namespace ConsoleApplication1.DAO
{
    class AdressDAO
    {
        private AdressbookEntities context = new AdressbookEntities();

        public void Create(string city,string country, string street, int house, int flat, string firstName, string name, string lastName, string telephone)
        {
            adress adress = context.adresses.Create();

            CityDAO cityDAO = new CityDAO();
            adress.idCity = cityDAO.FindCity(city, country);
            adress.street = street;
            adress.house = house;
            adress.flat = flat;
            
            PersonDAO personDAO = new PersonDAO();
            adress.idPerson = personDAO.FindPerson(firstName,name,lastName,telephone);
            context.adresses.Add(adress);
            context.SaveChanges();
        }

        public adress Read(int id)
        {
            adress adress = context.adresses.Find(id);
            return adress;
        }

        public List<adress> ReadAll()
        {
            List<adress> adressList = context.adresses.SqlQuery("SELECT * FROM adress INNER JOIN city ON adress.idCity = city.id INNER JOIN person ON " +
                    "adress.idPerson = person.id").ToList();
            if (adressList.Count() == 0)
            {
                MessageBox.Show("Не найдено адресов!");
            }

            return adressList;
        }

        public void Update(adress adress)
        {
            context.Entry(adress).State = System.Data.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            adress adress = context.adresses.Find(id);
            if (adress == null)
            {
                MessageBox.Show("Не найдено адреса с таким id!");
            }
            else
            {
                context.adresses.Remove(adress);
                context.SaveChanges();
            }

        }
        public List<adress> SearchByCity(string city,string country)
        {
            List<adress> adressList = context.adresses.SqlQuery("SELECT * FROM adress INNER JOIN city ON adress.idCity = city.id INNER JOIN person ON "+
                    "adress.idPerson = person.id WHERE city.name = '"+city+"' AND city.country='"+country+"'").ToList();
            if (adressList.Count() == 0)
            {
                MessageBox.Show("Не найдено адресов по данному запросу!");
            }
                
            return adressList;
        }
    }
}
