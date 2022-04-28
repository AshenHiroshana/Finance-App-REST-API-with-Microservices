using Finance_App.Entity;
using Finance_App.View;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Finance_App.Controller
{
    public class PredictionController
    {

        public double ClculateCommingIncome()
        {
            IncomeController incomeController = new IncomeController();
            List<Transaction> transactions = incomeController.GetIncomeList();

            DateTime dateTimeMin = DateTime.Now;
            DateTime dateTimeMax = DateTime.Now;

            foreach (Transaction transaction in transactions)
            {
                if((DateTime)transaction.Date > dateTimeMax)
                {
                    dateTimeMax = (DateTime)transaction.Date;
                }

                if ((DateTime)transaction.Date < dateTimeMin)
                {
                    dateTimeMin = (DateTime)transaction.Date;
                }
            }

            double numberOfMonth = dateTimeMax.Subtract(dateTimeMin).Days / (365.25 / 12);

            numberOfMonth = Math.Ceiling(numberOfMonth);

            if (numberOfMonth < 1)
            {
                numberOfMonth = 1;
            }

            return numberOfMonth;
        }

        public double ClculateCommingExpense()
        {
            ExpenseController expenseController = new ExpenseController();
            List<Transaction> transactions = expenseController.GetExpenseList();

            DateTime dateTimeMin = DateTime.Now;
            DateTime dateTimeMax = DateTime.Now;

            foreach (Transaction transaction in transactions)
            {
                if ((DateTime)transaction.Date > dateTimeMax)
                {
                    dateTimeMax = (DateTime)transaction.Date;
                }

                if ((DateTime)transaction.Date < dateTimeMin)
                {
                    dateTimeMin = (DateTime)transaction.Date;
                }
            }
            double numberOfMonth = dateTimeMax.Subtract(dateTimeMin).Days / (365.25 / 12);


            numberOfMonth = Math.Ceiling(numberOfMonth);

            if (numberOfMonth < 1)
            {
                numberOfMonth = 1;
            }


            return numberOfMonth;
        }

    }
}
