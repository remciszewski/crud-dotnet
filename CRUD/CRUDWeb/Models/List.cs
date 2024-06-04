using System.ComponentModel.DataAnnotations;

namespace CRUDWeb.Models
{
    public class List
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
