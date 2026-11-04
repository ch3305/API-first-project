using System.ComponentModel.DataAnnotations;

namespace Entities { 

    public class LoginUser
    {
        public int id { get; set; }
        [Required]
        public string password { get; set; }
        [EmailAddress]
        public string email { get; set; }
    }
}

