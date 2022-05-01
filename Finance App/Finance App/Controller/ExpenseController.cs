using Finance_App.Entity;
using Finance_App.Resource;
using Finance_App.View;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Finance_App.Controller
{
    internal class ExpenseController
    {
        ApiConfig apiConfig = new ApiConfig();
        public async void addExpense(Transaction expense)
        {

            HttpResponseMessage responseMessage = await apiConfig.PostAsync("Expense/api/Expenses", expense);

            if (!responseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show("ns");
                MessageBox.Show(responseMessage.ToString());
            }


        }


        public async void deleteExpenseFromFile(Transaction oldExpense)
        {


            HttpResponseMessage responseMessage = await apiConfig.DeleteAsync("Expense/api/Expenses", oldExpense.Id);

            if (!responseMessage.IsSuccessStatusCode)
            {
                //return transactions; //Error 
            }

        }

        public async void updateExpense(Transaction oldExpense, Transaction newExpense)
        {

            List<Transaction> fullExpenseList = await GetExpenseList();
            foreach (Transaction fullExpense in fullExpenseList)
            {
                if (oldExpense.Id == fullExpense.Id)
                {
                    oldExpense = fullExpense;
                    
                }
               
            }
            newExpense.Id = await findExpenseId();

            HttpResponseMessage responseMessage = await apiConfig.PutAsync("Expense/api/Expenses", newExpense);

            if (!responseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show("ns");
                MessageBox.Show(responseMessage.ToString());
            }


        }

        public async Task<List<Transaction>> GetExpenseListByFilter()
        {


                List<Transaction> expenseList = await GetExpenseList();
                

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

        public async Task<List<Transaction>> GetExpenseList()
        {
            List<Transaction> transactions = new List<Transaction>();

            HttpResponseMessage responseMessage = await apiConfig.GetAsync("Expense/api/Expenses");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return transactions; //Error 
            }

            transactions = await responseMessage.Content.ReadFromJsonAsync<List<Transaction>>();
            return transactions;

        }

        public async Task<int> findExpenseId()
        {
            int id = 0;
            List<Transaction> expenseList = await GetExpenseList();
            if (expenseList != null)
            {
                for (int i = 0; i < expenseList.Count; i++)
                {
                    Transaction transaction = expenseList[i];
                    id = (int)transaction.Id;
                }
            }
            return id;

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
