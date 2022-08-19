using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>

    {
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Bağlantı stringi tanımlanır.
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-GMLK7U1U;Initial Catalog=CoreBlogDB;User ID=sa;Password=123456789");

            //""
            //server=LAPTOP-GMLK7U1U;database=CoreBlogDb;integrated security=true;

           

        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get;  set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }


    }

}
