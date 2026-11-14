using System.ComponentModel.DataAnnotations;


namespace Entities
{
    //Stored data uses lowercase names and System.Text.Json is case-sensitive: keep the names and add PropertyNameCaseInsensitive = true to the JsonSerializerOptions instead of renaming them
    public class User
    {
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        public string password { get; set; }
        public int id { get; set; }
    }
}
