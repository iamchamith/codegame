using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlocklyPro.Core.Utility;

namespace BlocklyPro.Core.Domain
{
    [Table(nameof(User), Schema = "Identity")]
    public class User : BaseEntity
    {
        [Required, StringLength(DbConstrants.Name)]
        public string Name { get; protected set; }
        [Required, StringLength(DbConstrants.Email)]
        public string Email { get; protected set; }
        [Required, StringLength(DbConstrants.Password)]
        public string Password { get; protected set; }

        public User()
        {
        }
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public User Validate(string password)
        {
            if (Password != password)
            {
                throw new InvalidDataException("Invalid password");
            }
            return this;
        }

    }
}
