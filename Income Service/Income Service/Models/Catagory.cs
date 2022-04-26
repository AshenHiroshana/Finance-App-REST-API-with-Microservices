using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Finance_App.Entity
{
    public class Catagory
    {
        [Required]
        private int? id;

        [Required]
        [MaxLength(100)]
        private string? name;

        [Required]
        private string? icon;

        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }

        public Catagory(int id, string? name, string? icon)
        {
            this.id = id;
            this.name = name;
            this.icon = icon;
        }

        public Catagory(int id)
        {
            this.id = id;
        }

        public Catagory()
        {
        }
    }
}
