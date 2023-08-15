using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Model
{
    public class ContactContext: DbContext
    {
        public DbSet<Contact> Contacts { get; set;}

        public string path = @"E:\University\Microsoft\Phonebook\Phonebook.db";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={path}");
    }
}
