using Microsoft.EntityFrameworkCore;

namespace BlogApi.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Bağlantı stringi tanımlanır.
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-GMLK7U1U;Initial Catalog=CoreBlogApiDB;User ID=sa;Password=123456789");

            //""
            //server=LAPTOP-GMLK7U1U;database=CoreBlogDb;integrated security=true;



        }
        public DbSet<Employee> Employees { get; set; }
    }
}
