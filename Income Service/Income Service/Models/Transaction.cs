using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Finance_App.Entity
{
    public class Transaction
    {
            
        [Key]
        public int? Id { get; set; }

        [Required]
        public Double? Amount { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        [Required]
        public DateTime? Date { get; set; }
        
        public int CatagoryId { get; set; }
       
        public Transaction()
        {
        }



    }
}
