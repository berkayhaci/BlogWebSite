using System.ComponentModel.DataAnnotations;

namespace Katmanlı_Mimari.Models
{
    public class UserSignInVM
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adı Girin")]
        public string username { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Girin")]
        public string password { get; set; }
    }
}
