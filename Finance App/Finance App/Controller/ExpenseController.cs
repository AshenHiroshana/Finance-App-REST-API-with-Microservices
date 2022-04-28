using Finance_App.Entity;
using Finance_App.View;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Finance_App.Controller
{
    internal class ExpenseController
    {
        public void addExpenseToFile(Transaction expense)
        {

            List<Transaction> expenseList = GetExpenseList();

            expense.Id = findExpenseId();
            expenseList.Add(expense);

            PreData.expenseList = expenseList;


        }


        public void deleteExpenseFromFile(Transaction oldExpense)
        {


            List<Transaction> fullExpenseList = GetExpenseList();
            foreach (Transaction fullExpense in fullExpenseList)
            {
                if (oldExpense.Id == fullExpense.Id)
                {
                    oldExpense = fullExpense;

                }

            }

            fullExpenseList.Remove(oldExpense);

            PreData.expenseList = fullExpenseList;

        }

        public void updateExpenseListToFile(Transaction oldExpense, Transaction newExpense)
        {

            List<Transaction> fullExpenseList = GetExpenseList();
            foreach (Transaction fullExpense in fullExpenseList)
            {
                if (oldExpense.Id == fullExpense.Id)
                {
                    oldExpense = fullExpense;
                    
                }
               
            }
            newExpense.Id = findExpenseId();

            fullExpenseList.Remove(oldExpense);
            fullExpenseList.Add(newExpense);

            PreData.expenseList = fullExpenseList;


        }

        public List<Transaction> GetExpenseListByFilter()
        {


                List<Transaction> expenseList = GetExpenseList();

                List<Transaction> filteredExpenseList = new List<Transaction>();
                foreach (Transaction item in expenseList)
                {
                    DateTime itemDate = (DateTime)item.Date;
                    if (Common.selectedFilter == "filterByDate")
                    {
                        if (Common.selectedDate.Month == itemDate.Month && Common.selectedDate.Year == itemDate.Year && Common.selectedDate.Day == itemDate.Date.Day)
                        {
                            filteredExpenseList.Add(item);
                        }
                    }
                    else if (Common.selectedFilter == "filterByMonth")
                    {
                        if (Common.selectedDate.Month == itemDate.Month && Common.selectedDate.Year == itemDate.Year)
                        {
                            filteredExpenseList.Add(item);
                        }
                    }
                    else if (Common.selectedFilter == "filterByYear")
                    {
                        if (Common.selectedDate.Year == itemDate.Year)
                        {
                            filteredExpenseList.Add(item);
                        }
                    }
                    else if (Common.selectedFilter == "filterByWeek")
                    {
                        int week = GetWeekOfYear(itemDate);
                        if (GetWeekOfYear(Common.selectedDate) == GetWeekOfYear(itemDate))
                        {
                            filteredExpenseList.Add(item);
                        }
                    }

            }

                List<Transaction> expenseList2 = filteredExpenseList.OrderByDescending(x => x.Date).ToList();


                return expenseList2;
           

        }

        public List<Transaction> GetExpenseList()
        {
            if(PreData.expenseList == null)
            {
                PreData.expenseList = new List<Transaction>();
            }
                
            return PreData.expenseList;
        
        }

        public int findExpenseId()
        {
            int id = 0;
            List<Transaction> expenseList = GetExpenseList();
            if (expenseList != null)
            {
                for (int i = 0; i < expenseList.Count; i++)
                {
                    Transaction transaction = expenseList[i];
                    id = (int)transaction.Id;
                }
            }
            return ++id;

        }
        public static int GetWeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

    }
}
