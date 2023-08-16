using Microsoft.EntityFrameworkCore;
using Phonebook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Phonebook.Data
{
    public static class ContactData
    {
        public static void AddToDb(Contact contact)
        {
            using(ContactContext db = new ContactContext())
            {
                db.Add(contact);
                db.SaveChanges();
            }
        }

        public static List<Contact> FindFromDb()
        {
            using (ContactContext db = new ContactContext())
            {
                DbSet<Contact> contacts = db.Contacts;
                return contacts.ToList();
            }
        }

        public static List<Contact> FindByNameFromDb(string name)
        {
            using (ContactContext db = new ContactContext())
            {
                IQueryable<Contact> contacts = db.Contacts.Where(contact => contact.name == name);
                // DbSet<Contact> contacts = (DbSet<Contact>)(from contact in db.Contacts where contact.name.Contains(name) select contact);
                return contacts.ToList();
            }
        }

        public static void EditToDb(int id, Contact updatedContact)
        {
            using (ContactContext db = new ContactContext())
            {
                Contact contact = db.Contacts.Find(id);

                if (contact != null)
                {
                    contact.name = updatedContact.name;
                    contact.phone = updatedContact.phone;
                    contact.email = updatedContact.email;
                }
                db.SaveChanges();
            }
        }

        public static void DeleteFromDb(int id)
        {
            using (ContactContext db = new ContactContext())
            {
                Contact contact = db.Contacts.Find(id);
                if (contact != null)
                {
                    db.Remove(contact);
                    db.SaveChanges();
                }
            }
        }
    }
}
