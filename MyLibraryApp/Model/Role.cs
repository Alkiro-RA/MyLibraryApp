using System.ComponentModel.DataAnnotations;

namespace MyLibraryApp.Model
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
