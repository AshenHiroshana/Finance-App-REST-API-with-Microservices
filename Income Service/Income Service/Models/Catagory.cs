using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Income_Service.Models
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

        [JsonIgnore]
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        public Catagory()
        {
        }

      
    }
}
