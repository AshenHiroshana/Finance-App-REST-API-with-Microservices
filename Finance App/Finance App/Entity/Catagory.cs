using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_App.Entity
{
    public class Catagory
    {
        private string? name;
        private string? icon;

        public string? Name { get; set; }
        public string? Icon { get; set; }

        public Catagory(string? name, string? icon)
        {
            this.name = name;
            this.icon = icon;
        }

        public Catagory()
        {
        }
    }
}
