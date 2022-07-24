using System.ComponentModel.DataAnnotations;

namespace BullyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string  Name { get; set; }
        public int DisplayOrder { get; set; }   
        public DateTime CreatedDatetime { get; set; } = DateTime.Now;
    }
}
