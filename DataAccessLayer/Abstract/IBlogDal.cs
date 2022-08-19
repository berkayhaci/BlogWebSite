using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog> //ihtiyacımız olan metotları sadece ilgili yerlerde tanımlayabiliriz (include,eager loading)
    {
        List<Blog> GetListWithCategory(); //kategori ile beraber blokları getir.
        List<Blog> GetListWithCategoryByWriter(int id);
    }
}
