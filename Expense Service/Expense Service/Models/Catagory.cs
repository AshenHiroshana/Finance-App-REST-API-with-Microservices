using System.ComponentModel.DataAnnotations;

namespace Expense_Service.Models
{
    public class Catagory
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string? Icon { get; set; }

        public Catagory()
        {
        }

    }
}
