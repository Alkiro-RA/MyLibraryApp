using System.ComponentModel.DataAnnotations;

namespace MyLibraryApp.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }
        
        public int MemberId { get; set; }
        
        public virtual User? Member { get; set; }
    }
}
