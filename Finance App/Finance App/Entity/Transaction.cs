using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_App.Entity
{
    public class Transaction
    {
        


        public Double? Amount { get; set; }
        public string? Description { get; set; }
        public Catagory? Catagory { get; set; }
        public DateTime? Date { get; set; }
        public int? Id { get; set; }

        public Transaction()
        {
        }



    }
}
