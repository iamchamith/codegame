using System.ComponentModel.DataAnnotations;
using BlocklyPro.Core.Utility;

namespace BlocklyPro.Api.Model.Identity
{
    public class RegisterModel
    {
        [Required,StringLength(DbConstrants.Email)]
        public string Email { get; set; }
        [Required, StringLength(DbConstrants.Password)]
        public string Password { get; set; }
        [Required, StringLength(DbConstrants.Name)]
        public string Name { get; set; }
    }
}
