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

        public void Create(string city, string street, int house, int flat, string firstName, string name, string lastName)
        {
            adress adress = context.adresses.Create();

            CityDAO cityDAO = new CityDAO();
            adress.idCity = cityDAO.FindByName(city);
            adress.street = street;
            adress.house = house;
            adress.flat = flat;
            
            PersonDAO personDAO = new PersonDAO();
            adress.idPerson = personDAO.Find(firstName,name,lastName);
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
            var list = from adress in context.adresses
                       select adress;
            return list.ToList();
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
    }
}
