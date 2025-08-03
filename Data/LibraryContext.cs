using LibraryEFApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEFApp.Data
{
    public class LibraryContext: DbContext
    {
        public DbSet<Book> Books => Set<Book>();
        public LibraryContext() { }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;
                                        Database=LibraryDb;Trusted_Connection=True;");
            }
        }
    }
}
