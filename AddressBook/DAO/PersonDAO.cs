using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddressBook.Models;


namespace ConsoleApplication1.DAO
{
    class PersonDAO
    {
        private AdressbookEntities context = new AdressbookEntities();

        public person Create(string firstName, string name, string lastName,string telephone)
        {
            person person = context.people.Create();
            person.firstName = firstName;
            person.name = name;
            person.lastName = lastName;
            person.telephone = telephone;
            context.people.Add(person);
            context.SaveChanges();
            return person;
        }

        public person Read(int id)
        {
            person person = context.people.Find(id);
            return person;
        }

        public List<person> ReadAll()
        {
            var list = from person in context.people
                       select person;
            return list.ToList();
        }

        public void Update(person person)
        {
            context.Entry(person).State = System.Data.EntityState.Modified;
            context.SaveChanges();
        }


        public void Delete(int id)
        {
            person person = context.people.Find(id);
            if (person == null)
            {
                MessageBox.Show("Не найдено человека с таким id!");
            }
            else
            {
                context.people.Remove(person);
                context.SaveChanges();
            }

        }
        public int FindPerson(string firstName, string name, string lastName,string telephone){
            List<person> personList = context.people.SqlQuery("SELECT * from person WHERE person.firstName ='"+firstName+"'AND " +
            "person.name='"+name+"'AND person.lastName='"+lastName+"'AND person.telephone='"+telephone+"'").ToList();

            if (personList.Count == 0)
            {
                
                return Create(firstName, name, lastName,telephone).id;
            }

            return personList[0].id;

        }
    }
}
