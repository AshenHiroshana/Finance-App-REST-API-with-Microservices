using Finance_App.Controller;
using Finance_App.Entity;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Finance_App.View
{
    /// <summary>
    /// Interaction logic for PredictionView.xaml
    /// </summary>
    public partial class PredictionView : UserControl
    {
        public PredictionView()
        {
            InitializeComponent();
            UpdateIncomeChart();
            UpdateExpenseChart();


        }


        public void UpdateIncomeChart()
        {
            PredictionController predictionController = new PredictionController();
           
            double numberOfMonth = predictionController.ClculateCommingIncome();

            if (numberOfMonth < 1)
            {
                numberOfMonth = 1;
            }


            LiveCharts.SeriesCollection seriesCollection = new LiveCharts.SeriesCollection();

            IncomeController incomeController = new IncomeController();
            List<Transaction> incomeList = incomeController.GetIncomeListByFilter();

            List<Catagory> catagories = new List<Catagory>();
            Catagory newCatagory = new Catagory();

            Catagory chartCatagory = new Catagory();
            Double amount = 0;
            Double fullAmount = 0;

            foreach (Transaction transaction in incomeList)
            {

                if (!catagories.Any(item => item.Name == transaction.Catagory.Name))
                {
                    catagories.Add(transaction.Catagory);
                }

            }

            foreach (Catagory catagory in catagories)
            {
                foreach (Transaction transaction in incomeList)
                {
                    if (transaction.Catagory.Name == catagory.Name)
                    {
                        amount += (Double)transaction.Amount;

                    }
                }
                if (amount != 0)
                {
                    chartCatagory.Name = catagory.Name;
                    chartCatagory.Icon = catagory.Icon;

                    double nextAmount = amount / numberOfMonth;

                    PieSeries pieSeries = new PieSeries();
                    pieSeries.Title = catagory.Name;
                    pieSeries.Values = new ChartValues<ObservableValue> { new ObservableValue(Math.Round(nextAmount, 2)) };
                    pieSeries.DataLabels = true;
                    seriesCollection.Add(pieSeries);
                    fullAmount += nextAmount;
                    amount = 0;
                }

            }


            fullAmount = Math.Round(fullAmount, 2);

            txtIncomeTotalAmuont.Text = "Rs : " + fullAmount.ToString();
            fullAmount = 0;

            SeriesCollectionIncome = seriesCollection;
        }




        public void UpdateExpenseChart()
        {

            PredictionController predictionController = new PredictionController();

            double numberOfMonth = predictionController.ClculateCommingIncome();

           


            LiveCharts.SeriesCollection seriesCollection = new LiveCharts.SeriesCollection();

            ExpenseController expenseController = new ExpenseController();
            List<Transaction> expenseList = expenseController.GetExpenseListByFilter();

            List<Catagory> catagories = new List<Catagory>();
            Catagory newCatagory = new Catagory();

            Catagory chartCatagory = new Catagory();
            Double amount = 0;
            Double fullAmount = 0;

            foreach (Transaction transaction in expenseList)
            {

                if (!catagories.Any(item => item.Name == transaction.Catagory.Name))
                {
                    catagories.Add(transaction.Catagory);
                }

            }

            foreach (Catagory catagory in catagories)
            {
                foreach (Transaction transaction in expenseList)
                {
                    if (transaction.Catagory.Name == catagory.Name)
                    {
                        amount += (Double)transaction.Amount;

                    }
                }
                if (amount != 0)
                {
                    chartCatagory.Name = catagory.Name;
                    chartCatagory.Icon = catagory.Icon;

                    double nextAmount = amount / numberOfMonth;

                    PieSeries pieSeries = new PieSeries();
                    pieSeries.Title = catagory.Name;
                    pieSeries.Values = new ChartValues<ObservableValue> { new ObservableValue(Math.Round(nextAmount, 2)) };
                    pieSeries.DataLabels = true;
                    seriesCollection.Add(pieSeries);
                    fullAmount += nextAmount;
                    amount = 0;
                }
            }

            fullAmount = Math.Round(fullAmount, 2);
            txtExpenseTotalAmuont.Text = "Rs : " + fullAmount.ToString();
            fullAmount = 0;


            SeriesCollectionExpense = seriesCollection;



        }

        public SeriesCollection SeriesCollectionIncome { get; set; }

        public SeriesCollection SeriesCollectionExpense { get; set; }
    }
}
