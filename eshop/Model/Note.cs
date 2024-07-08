using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace eshop.Model
{
    [Table("note")]
    public class Note
    {
        public Note() { }
        public Note(NoteDto dto) { 
            this.Title = dto.Title;
            this.Description = dto.Description;
            this.Date = dto.Date;
            this.UserId = dto.UserId;
        }

        [Key]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        public long UserId { get; set; }
        public User? User { get; set; }
    }
}
