using Finance_App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_App.Controller
{
    public class PreData
    {
        public static List<Catagory> incomeCatagories;
        public static List<Catagory> expenseCatagories;

        public static List<Transaction> expenseList;
        public static List<Transaction> incomeList;



        public PreData()
        {
        }
    }
}
