using System.ComponentModel.DataAnnotations;


namespace Entities
{
    public class User
    {
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        //In C#, properties are written in PascalCase: Password. text.txt stores the current names: if you rename them, set PropertyNameCaseInsensitive = true in the JsonSerializerOptions, so the existing file still loads
        public string password { get; set; }
        public int id { get; set; }
    }
}
