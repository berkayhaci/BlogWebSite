using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; } // ön izleme kısmı
        public string BlogImage { get; set; } //resimler çok yer kaplayacağı için dosya yolu 
        public bool BlogStatus { get; set; }
        public DateTime BlogCreateDate { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int WriterID { get; set; }
        public Writer Writer { get; set; }

        public List<Comment> Comments { get; set; }

    }
}
