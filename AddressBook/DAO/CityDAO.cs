using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddressBook.Models;


namespace ConsoleApplication1.DAO
{
    class CityDAO
    {
        private AdressbookEntities context = new AdressbookEntities();

        public city Create(string name)
        {
            city city = context.cities.Create();
            city.name = name;
            context.cities.Add(city);
            context.SaveChanges();
            return city;
        }

        public city Read(int id)
        {
            city city = context.cities.Find(id);
            return city;
        }

        public List<city> ReadAll()
        {
            var list = from city in context.cities
                      select city;
            return list.ToList();
        }

        public void Update(city city)
        {
            context.Entry(city).State = System.Data.EntityState.Modified;
            context.SaveChanges();
        }


        public int FindByName(string name)
        {
            List<city> cityList = context.cities.SqlQuery("SELECT * from city WHERE city.name ='"+name+"'").ToList();
            if (cityList.Count == 0)
            {
                
                return Create(name).id;
            }

            return cityList[0].id;
        }

        public void Delete(int id)
        {
            city city = context.cities.Find(id);
            if (city == null)
            {
                MessageBox.Show("Не найдено города с таким id!");
            }
            else
            {
                context.cities.Remove(city);
                context.SaveChanges();
            }

        }
    }
}
