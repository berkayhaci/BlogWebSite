using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public string WriterImage { get; set; }
        public bool WriterStatus { get; set; }
        public string WriterEmail { get; set; }
        public string WriterPassword { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
