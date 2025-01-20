using System.Data.Entity;
using ContactManagerApp.Models;

namespace ContactManagerApp
{
    public partial class ContactDbContext : DbContext
    {
        public ContactDbContext()
            : base("name=ContactManager")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
