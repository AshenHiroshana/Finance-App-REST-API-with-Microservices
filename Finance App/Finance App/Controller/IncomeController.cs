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
    public class IncomeController
    {
        public void addIncomeToFile(Transaction income)
        {

            List<Transaction> incomeList = GetIncomeList();

            income.Id = findIncomeId();
            incomeList.Add(income);

            PreData.incomeList = incomeList;


        }

        public void deleteIncomeFromFile(Transaction oldIncome)
        {


            List<Transaction> fullIncomeList = GetIncomeList();
            foreach (Transaction fullIncome in fullIncomeList)
            {
                if (oldIncome.Id == fullIncome.Id)
                {
                    oldIncome = fullIncome;

                }

            }

            fullIncomeList.Remove(oldIncome);

            PreData.incomeList = fullIncomeList;


        }

        public void updateIncomeListToFile(Transaction oldIncome, Transaction newIncome)
        {

            List<Transaction> fullIncomeList = GetIncomeList();
            foreach (Transaction fullIncome in fullIncomeList)
            {
              if (oldIncome.Id == fullIncome.Id)
                {
                    oldIncome = fullIncome;
                    
                }
               
            }
            newIncome.Id = findIncomeId(); 

            fullIncomeList.Remove(oldIncome);
            fullIncomeList.Add(newIncome);

            PreData.incomeList = fullIncomeList;


        }

        public List<Transaction> GetIncomeListByFilter()
        {

                
                   
                List<Transaction> incomeList = GetIncomeList();

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

        public List<Transaction> GetIncomeList()
        {
            if (PreData.incomeList == null)
            {
                PreData.incomeList = new List<Transaction>();
            }

            return PreData.incomeList;
        }

        public int findIncomeId()
        {
            int id = 0;
            List<Transaction> incomeList = GetIncomeList();
            if(incomeList != null)
            {
                for (int i = 0; i < incomeList.Count; i++)
                {
                    Transaction transaction = incomeList[i];
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
