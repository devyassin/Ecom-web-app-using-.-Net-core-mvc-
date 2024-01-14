
using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class MyDbContext : DbContext
    {

 

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> users { get; set; }

        public DbSet<Todo> todos { get; set; }


        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Data Source=Localhost\SQLPRACTICE;Initial Catalog=TodoDb;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
        }
    }
}
