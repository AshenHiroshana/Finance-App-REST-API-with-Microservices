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
    public class IncomeController
    {
        ApiConfig apiConfig = new ApiConfig();
        public async void addIncome(Transaction income)
        {
            HttpResponseMessage responseMessage = await apiConfig.PostAsync("Income/api/Incomes", income);

            if (!responseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show("ns");
                MessageBox.Show(responseMessage.ToString());
            }

            
        }


        public async void deleteIncomeFromFile(Transaction oldIncome)
        {
            HttpResponseMessage responseMessage = await apiConfig.DeleteAsync("Income/api/Incomes", oldIncome.Id);

            if (!responseMessage.IsSuccessStatusCode)
            {
                //return transactions; //Error 
            }

        }

        public async void updateIncome(Transaction oldIncome, Transaction newIncome)
        {

            List<Transaction> fullIncomeList = await GetIncomeList();
            foreach (Transaction fullIncome in fullIncomeList)
            {
              if (oldIncome.Id == fullIncome.Id)
                {
                    oldIncome = fullIncome;
                    
                }
               
            }
            newIncome.Id = await findIncomeId();

            HttpResponseMessage responseMessage = await apiConfig.PutAsync("Income/api/Incomes", newIncome);

            if (!responseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show("ns");
                MessageBox.Show(responseMessage.ToString());
            }

            
        }

        public async Task<List<Transaction>> GetIncomeListByFilter()
        {

                
                
                List<Transaction> incomeList = await GetIncomeList();
                

                List<Transaction> filteredIncomeList = new List<Transaction>();
                foreach (Transaction item in incomeList)
                {
                    DateTime itemDate = (DateTime)item.Date;
                    
                if (Common.selectedFilter == "filterByDate")
                    {
                        if (Common.selectedDate.Month == itemDate.Month && Common.selectedDate.Year == itemDate.Year && Common.selectedDate.Day == itemDate.Date.Day)
                        {
                            filteredIncomeList.Add(item);
                        }
                    }else if (Common.selectedFilter == "filterByMonth")
                    {
                        if (Common.selectedDate.Month == itemDate.Month && Common.selectedDate.Year == itemDate.Year)
                        {
                            filteredIncomeList.Add(item);
                        }
                    }
                    else if (Common.selectedFilter == "filterByYear")
                    {
                        if (Common.selectedDate.Year == itemDate.Year)
                        {
                            filteredIncomeList.Add(item);
                        }
                    }
                    else if (Common.selectedFilter == "filterByWeek")
                    {
                        int week = GetWeekOfYear(itemDate);
                        if (GetWeekOfYear(Common.selectedDate) == GetWeekOfYear(itemDate))
                        {
                            filteredIncomeList.Add(item);
                        }
                    }

            }

                List<Transaction> incomeList2 = filteredIncomeList.OrderByDescending(x => x.Date).ToList();
               

                return incomeList2;
           

        }

        public async Task<List<Transaction>> GetIncomeList()
        {
            List<Transaction> transactions = new List<Transaction>();

            HttpResponseMessage responseMessage = await apiConfig.GetAsync("Income/api/Incomes");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return transactions; //Error 
            }

            transactions = await responseMessage.Content.ReadFromJsonAsync<List<Transaction>>();
            return transactions;
        }

        public async Task<int> findIncomeId()
        {
            int id = 0;
            List<Transaction> incomeList = await GetIncomeList();
            if(incomeList != null)
            {
                for (int i = 0; i < incomeList.Count; i++)
                {
                    Transaction transaction = incomeList[i];
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
