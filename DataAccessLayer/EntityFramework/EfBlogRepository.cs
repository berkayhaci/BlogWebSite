using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntitiyLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory() //burada 2 seçenek var db için.Ya  private readonly ApplicationDbContext db yapısı kullanılıp, ctor`da public StudentRepository(ApplicationDbContext db) :base(db) bu şekilde ya da burdaki gibi
        {

            using(var c=new Context())  
            {
                return c.Blogs.Include(c=>c.Category).ToList(); //business katmanından bu metot çağırılması gerek
                
            }

                 
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using(var c = new Context())
            {
                return c.Blogs.Include(c=>c.Category).Where(x=>x.WriterID == id).ToList();
            }
        }
    }
}
