using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyLibraryApp.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(25)]
        public string? Name { get; set; }

        [MaxLength(25)]
        public string? Surname { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        public string Password { get; set; }
        
        [Required]
        public int RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual List<Book>? Books { get; set; }
    }
}
