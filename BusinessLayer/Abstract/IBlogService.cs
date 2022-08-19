using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> GetBlogWithCategory(); //ef blog repodan gelir.Extra blog için tanımlandı
        List<Blog> GetBlogListByWriter(int id);
        
    }
}
