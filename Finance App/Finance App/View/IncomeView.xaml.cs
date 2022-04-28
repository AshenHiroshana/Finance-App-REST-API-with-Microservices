
using Finance_App.Entity;
using Finance_App.Controller;
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
using System.IO;
using System.Text.Json;

namespace Finance_App.View
{
    /// <summary>
    /// Interaction logic for IncomeView.xaml
    /// </summary>
    public partial class IncomeView : UserControl
    {
        public IncomeView()
        {


            InitializeComponent();
            updateIncomeList();
            updateCatagoryList();


        }


        Button clickedButton;
        private void Button_Is_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (clickedButton != null)
            {
                Style? style1 = this.FindResource("OutlinedButton") as Style;
                clickedButton.Style = style1;
            }
            clickedButton = button;
            Style? style2 = this.FindResource("FlatDarkBgButton") as Style;
            button.Style = style2;

            string selectedCatagory = (string)button.ToolTip;
            txtSelectedCatagory.Foreground = new SolidColorBrush(Colors.Gray);
            txtSelectedCatagory.Text = "You selected " + selectedCatagory + " as your Category";

        }

        IncomeController incomeController = new IncomeController();
        private void AddIncome(object sender, RoutedEventArgs e)
        {
            if (clickedButton == null)
            {
                txtSelectedCatagory.Text = "Select a Catagory";
                txtSelectedCatagory.Foreground = new SolidColorBrush(Color.FromRgb(217, 83, 79));
            }
            else
            {

                String incomeDescription = txtIncomeDescription.Text;
                Double incomeAmount = double.Parse(txtIncomeAmount.Text);
                DateTime incomeDate = (DateTime)txtIncomeDate.GetValue(DatePicker.SelectedDateProperty);
                
                Catagory incomeCatagory = new Catagory();
                incomeCatagory.Name = (string)clickedButton.ToolTip;
                incomeCatagory.Icon = clickedButton.Name;

                

                Transaction incomeTransaction = new Transaction();
                incomeTransaction.Description = incomeDescription;
                incomeTransaction.Amount = incomeAmount;
                incomeTransaction.Date = incomeDate;
                incomeTransaction.Catagory = incomeCatagory;

                if (incomeUpdating)
                {
                    incomeUpdatedList.Add(incomeTransaction);
                    incomeController.updateIncomeListToFile(updatedIncome, incomeTransaction);
                    updateIncomeList();
                    ClearIncomeForm();
                    incomeDelete.Visibility = Visibility.Collapsed;

                }
                else
                {
                    incomeController.addIncomeToFile(incomeTransaction);
                    updateIncomeList();
                    ClearIncomeForm();
                }


            }

        }

        public void updateIncomeList(List<Transaction> incomeList = null)
        {

            if (incomeList == null)
            {
                incomeList = incomeController.GetIncomeListByFilter();
            }

            lstIncomeList.Children.Clear();
            lstIncomeList.RowDefinitions.Clear();
            for (int i = 0; i < incomeList.Count; i++)
            {

                Style? style = this.FindResource("OutlinedButton") as Style;
                string text = " Rs : " + incomeList[i].Amount;
                Button button = Common.CreateCatagoryButton(text, incomeList[i].Catagory.Icon, style);
                button.Click += new RoutedEventHandler(Income_Is_Click);
                button.Height = 30;
                button.Width = 190;
                button.Tag = i.ToString();
                button.ToolTip = incomeList[i].Description; ;
                //button.Name = icon;
                button.SetValue(Grid.RowProperty, (i));
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(40);
                lstIncomeList.RowDefinitions.Add(row);
                lstIncomeList.Children.Add(button);



            }


        }

        Boolean incomeUpdating = false;
        List<Transaction> incomeUpdatedList;
        Transaction updatedIncome;
        private void Income_Is_Click(object sender, RoutedEventArgs e)
        {
            if (updatedIncome != null)
            {
                incomeUpdatedList.Add(updatedIncome);
            }
            else
            {
                incomeUpdatedList = incomeController.GetIncomeListByFilter();
            }

            Button_Is_Click(sender, e);
            incomeUpdating = true;
            Button button = sender as Button;
            int id = int.Parse((string)button.Tag);

            for (int i = 0; i < incomeUpdatedList.Count; i++)
            {
                if (i == id)
                {
                    updatedIncome = incomeUpdatedList[i];
                    incomeUpdatedList.RemoveAt(i);
                    updateIncomeList(incomeUpdatedList);
                }
            }

            txtIncomeAmount.Text = updatedIncome.Amount.ToString();
            txtIncomeDescription.Text = updatedIncome.Description;
            txtSelectedCatagory.Text = "You selected " + updatedIncome.Catagory.Name + " as your Category";
            txtIncomeDate.Text = updatedIncome.Date.ToString();

            incomeDelete.Visibility = Visibility.Visible;
        }

        private void Next(object sender, RoutedEventArgs e)
        {

            Boolean approveTxtIncomeDescription = false;
            Boolean approveTxtIncomeAmount = false;
            Boolean approveTxtIncomeDate = false;
            Double x;

            if (txtIncomeDescription.Text == "")
            {
                txtIncomeDescription.BorderBrush = new SolidColorBrush(Color.FromRgb(217, 83, 79));
            }
            if (txtIncomeAmount.Text == "" || !double.TryParse(txtIncomeAmount.Text, out x))
            {
                txtIncomeAmount.BorderBrush = new SolidColorBrush(Color.FromRgb(217, 83, 79));
            }
            if (txtIncomeDate.Text == "")
            {
                txtIncomeDate.BorderBrush = new SolidColorBrush(Color.FromRgb(217, 83, 79));
            }

            if (txtIncomeDescription.Text != "")
            {
                txtIncomeDescription.BorderBrush = new SolidColorBrush(Color.FromRgb(70, 70, 70));
                approveTxtIncomeDescription = true;
            }

            if (txtIncomeAmount.Text != "" && double.TryParse(txtIncomeAmount.Text, out x))
            {

                txtIncomeAmount.BorderBrush = new SolidColorBrush(Color.FromRgb(70, 70, 70));
                approveTxtIncomeAmount = true;
            }
            if (txtIncomeDate.Text != "")
            {
                txtIncomeDate.BorderBrush = new SolidColorBrush(Color.FromRgb(70, 70, 70));
                approveTxtIncomeDate = true;
            }

            if (approveTxtIncomeDate && approveTxtIncomeDescription && approveTxtIncomeAmount)
            {
                IncomeForm1.Visibility = Visibility.Hidden;
                IncomeForm2.Visibility = Visibility.Visible;
            }

        }

        private void Prev(object sender, RoutedEventArgs e)
        {
            IncomeForm2.Visibility = Visibility.Hidden;
            IncomeForm1.Visibility = Visibility.Visible;
        }

        private void NextAddCatagory(object sender, RoutedEventArgs e)
        {
            IncomeForm2.Visibility = Visibility.Hidden;
            AddCatagoryForm.Visibility = Visibility.Visible;
        }

        private void PrevAddCatagory(object sender, RoutedEventArgs e)
        {
            IncomeForm2.Visibility = Visibility.Visible;
            AddCatagoryForm.Visibility = Visibility.Hidden;
        }

        private void ClearIncomeForm1(object sender, RoutedEventArgs e)
        {
            txtIncomeDescription.Text = "";
            txtIncomeAmount.Text = "";
            txtIncomeDate.Text = "";
        }

        public void ClearIncomeForm()
        {
            incomeUpdating = false;
            updatedIncome = null;
            incomeUpdatedList = null;

            txtIncomeDescription.Text = "";
            txtIncomeAmount.Text = "";
            txtIncomeDate.DataContext = null;

            txtSelectedCatagory.Text = "Select a Catagory";
            txtSelectedCatagory.Foreground = new SolidColorBrush(Color.FromRgb(217, 83, 79));

            if (clickedButton != null)
            {
                Style? style1 = this.FindResource("OutlinedButton") as Style;
                clickedButton.Style = style1;
            }

            clickedButton = null;

            IncomeForm2.Visibility = Visibility.Hidden;
            IncomeForm1.Visibility = Visibility.Visible;
        }

        string icon = "AddCircle";
        private void AddCatagoryIcon(object sender, RoutedEventArgs e)
        {
            selectedIcon.Children.Clear();
            Button button = sender as Button;
            icon = button.Name;
            Viewbox packIcon = Common.FindIcon(icon, false);
            packIcon.Width = 20;
            packIcon.Height = 20;
            packIcon.VerticalAlignment = VerticalAlignment.Center;
            packIcon.HorizontalAlignment = HorizontalAlignment.Center;
            packIcon.Margin = new Thickness(450, 0, 0, 11);
            selectedIcon.Children.Add(packIcon);
        }


       
       

        private void AddCatagory(object sender, RoutedEventArgs e)
        {
           
            if (txtCatagoryname.Text == "")
            {
                txtCatagoryname.BorderBrush = new SolidColorBrush(Color.FromRgb(217, 83, 79));
            }
            if (txtCatagoryname.Text != "")
            {
                CatagoryController catagoryController = new CatagoryController();
                List<Catagory> catagories = catagoryController.GetIncomeCatagory();

                Boolean isSet = false;

                foreach (Catagory item in catagories)
                {
                    if (item.Name == txtCatagoryname.Text)
                    {
                        isSet = true;   
                        break;
                    }
                }

                if (isSet)
                {
                    MessageBox.Show("This Category Already in the List");
                   
                    txtCatagoryname.BorderBrush = new SolidColorBrush(Color.FromRgb(217, 83, 79));
                }
                else
                {
                    txtCatagoryname.BorderBrush = new SolidColorBrush(Color.FromRgb(70, 70, 70));
                    Catagory catagory = new Catagory();
                    catagory.Name = txtCatagoryname.Text;
                    catagory.Icon = icon;

                    txtCatagoryname.Text = "";
                    catagoryController.SaveIncomeCatagory(catagory);

                    updateCatagoryList();
                    IncomeForm2.Visibility = Visibility.Visible;
                    AddCatagoryForm.Visibility = Visibility.Hidden;
                }


            }




        }

        private void updateCatagoryList()
        {

            CatagoryList.Children.Clear();
            CatagoryList.RowDefinitions.Clear();

            CatagoryController catagoryController = new CatagoryController();

            List<Catagory> catagories = catagoryController.GetIncomeCatagory();



            List<Button> x = new List<Button>();

            for (int i = 0; i < catagories.Count; i++)
            {

                Style? style = this.FindResource("OutlinedButton") as Style;
                Button button = Common.CreateCatagoryButton(catagories[i].Name, catagories[i].Icon, style);
                button.Click += new RoutedEventHandler(Button_Is_Click);
                // button.Click += new EventHandler(Catagory_Is_Click);

                button.SetValue(Grid.RowProperty, (i / 2));
                button.SetValue(Grid.ColumnProperty, (i % 2));

               if (i % 2 == 0)
                {
                    RowDefinition row = new RowDefinition();
                    row.Height = new GridLength(70);
                    CatagoryList.RowDefinitions.Add(row);
                }

                CatagoryList.Children.Add(button);

            }

        }


        private void deleteIncomeItem(object sender, RoutedEventArgs e)
        {


            string message = "Are you sure to Delete Income ?";
            string caption = "Delete";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;

            MessageBoxResult messageBoxResult = MessageBox.Show(message, caption, buttons, icon);


            if (messageBoxResult == MessageBoxResult.Yes)
            {
                incomeController.deleteIncomeFromFile(updatedIncome);
                updateIncomeList();
                ClearIncomeForm();
                incomeDelete.Visibility = Visibility.Collapsed;
            }
           

        }


    }
}
