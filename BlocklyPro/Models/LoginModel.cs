using System.ComponentModel.DataAnnotations;

namespace BlocklyPro.Models
{
    public class LoginModel
    {
        [Required, StringLength(50)]
        public string Email { get; set; }
        [Required, StringLength(50)]
        public string Password { get; set; }
    }
}
