using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_App.Entity
{
    public class Transaction
    {
        private int? id;
        private Double? amount;
        private string? description;
        private Catagory? catagory;
        private DateTime? date;


        public Double? Amount { get; set; }
        public string? Description { get; set; }
        public Catagory? Catagory { get; set; }
        public DateTime? Date { get; set; }
        public int? Id { get; set; }

        public Transaction()
        {
        }

        public Transaction(int id, Double? amount, string? description, Catagory? catagory, DateTime? dateOnly)
        {
            this.id = id;
            this.amount = amount;
            this.description = description;
            this.catagory = catagory;
            this.Date = dateOnly;
        }


    }
}
