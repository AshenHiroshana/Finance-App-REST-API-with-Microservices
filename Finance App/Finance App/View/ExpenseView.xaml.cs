using Finance_App.Entity;
using Finance_App.Controller;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Data;

namespace Finance_App.View
{
    /// <summary>
    /// Interaction logic for ExpenseView.xaml
    /// </summary>
    public partial class ExpenseView : UserControl
    {
        public ExpenseView()
        {


            InitializeComponent();
            updateExpenseList();
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

        ExpenseController expenseController = new ExpenseController();
        private void AddExpense(object sender, RoutedEventArgs e)
        {
            if (clickedButton == null)
            {
                txtSelectedCatagory.Text = "Select a Catagory";
                txtSelectedCatagory.Foreground = new SolidColorBrush(Color.FromRgb(217, 83, 79));
            }
            else
            {

                String expenseDescription = txtExpenseDescription.Text;
                Double expenseAmount = double.Parse(txtExpenseAmount.Text);
                DateTime expenseDate = (DateTime)txtExpenseDate.GetValue(DatePicker.SelectedDateProperty);
                
                Catagory expenseCatagory = new Catagory();
                expenseCatagory.Name = (string)clickedButton.ToolTip;
                expenseCatagory.Icon = clickedButton.Name;

                

                Transaction expenseTransaction = new Transaction();
                expenseTransaction.Description = expenseDescription;
                expenseTransaction.Amount = expenseAmount;
                expenseTransaction.Date = expenseDate;
                expenseTransaction.Catagory = expenseCatagory;

                if (expenseUpdating)
                {
                    expenseUpdatedList.Add(expenseTransaction);
                    expenseController.updateExpenseListToFile(updatedExpense, expenseTransaction);
                    updateExpenseList();
                    ClearExpenseForm();
                    expenseDelete.Visibility = Visibility.Collapsed;


                }
                else
                {
                    expenseController.addExpenseToFile(expenseTransaction);
                    updateExpenseList();
                    ClearExpenseForm();

                }


            }

        }

        public void updateExpenseList(List<Transaction> expenseList = null)
        {

            if (expenseList == null)
            {
                expenseList = expenseController.GetExpenseListByFilter();
            }

            lstExpenseList.Children.Clear();
            lstExpenseList.RowDefinitions.Clear();
            for (int i = 0; i < expenseList.Count; i++)
            {

                Style? style = this.FindResource("OutlinedButton") as Style;
                string text = " Rs : " + expenseList[i].Amount;
                Button button = Common.CreateCatagoryButton(text, expenseList[i].Catagory.Icon, style);
                button.Click += new RoutedEventHandler(Expense_Is_Click);
                button.Height = 30;
                button.Width = 190;
                button.Tag = i.ToString();
                button.ToolTip = expenseList[i].Description; ;
                //button.Name = icon;
                button.SetValue(Grid.RowProperty, (i));
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(40);
                lstExpenseList.RowDefinitions.Add(row);
                lstExpenseList.Children.Add(button);



            }


        }

        Boolean expenseUpdating = false;
        List<Transaction> expenseUpdatedList;
        Transaction updatedExpense;
        private void Expense_Is_Click(object sender, RoutedEventArgs e)
        {
            if (updatedExpense != null)
            {
                expenseUpdatedList.Add(updatedExpense);
            }
            else
            {
                expenseUpdatedList = expenseController.GetExpenseListByFilter();
            }

            Button_Is_Click(sender, e);
            expenseUpdating = true;
            Button button = sender as Button;
            int id = int.Parse((string)button.Tag);

            for (int i = 0; i < expenseUpdatedList.Count; i++)
            {
                if (i == id)
                {
                    updatedExpense = expenseUpdatedList[i];
                    expenseUpdatedList.RemoveAt(i);
                    updateExpenseList(expenseUpdatedList);
                }
            }

            txtExpenseAmount.Text = updatedExpense.Amount.ToString();
            txtExpenseDescription.Text = updatedExpense.Description;
            txtSelectedCatagory.Text = "You selected " + updatedExpense.Catagory.Name + " as your Category";
            txtExpenseDate.Text = updatedExpense.Date.ToString();

            expenseDelete.Visibility = Visibility.Visible;
        }

        private void Next(object sender, RoutedEventArgs e)
        {

            Boolean approveTxtExpenseDescription = false;
            Boolean approveTxtExpenseAmount = false;
            Boolean approveTxtExpenseDate = false;
            Double x;

            if (txtExpenseDescription.Text == "")
            {
                txtExpenseDescription.BorderBrush = new SolidColorBrush(Color.FromRgb(217, 83, 79));
            }
            if (txtExpenseAmount.Text == "" || !double.TryParse(txtExpenseAmount.Text, out x))
            {
                txtExpenseAmount.BorderBrush = new SolidColorBrush(Color.FromRgb(217, 83, 79));
            }
            if (txtExpenseDate.Text == "")
            {
                txtExpenseDate.BorderBrush = new SolidColorBrush(Color.FromRgb(217, 83, 79));
            }

            if (txtExpenseDescription.Text != "")
            {
                txtExpenseDescription.BorderBrush = new SolidColorBrush(Color.FromRgb(70, 70, 70));
                approveTxtExpenseDescription = true;
            }

            if (txtExpenseAmount.Text != "" && double.TryParse(txtExpenseAmount.Text, out x))
            {

                txtExpenseAmount.BorderBrush = new SolidColorBrush(Color.FromRgb(70, 70, 70));
                approveTxtExpenseAmount = true;
            }
            if (txtExpenseDate.Text != "")
            {
                txtExpenseDate.BorderBrush = new SolidColorBrush(Color.FromRgb(70, 70, 70));
                approveTxtExpenseDate = true;
            }

            if (approveTxtExpenseDate && approveTxtExpenseDescription && approveTxtExpenseAmount)
            {
                ExpenseForm1.Visibility = Visibility.Hidden;
                ExpenseForm2.Visibility = Visibility.Visible;
            }

        }

        private void Prev(object sender, RoutedEventArgs e)
        {
            ExpenseForm2.Visibility = Visibility.Hidden;
            ExpenseForm1.Visibility = Visibility.Visible;
        }

        private void NextAddCatagory(object sender, RoutedEventArgs e)
        {
            ExpenseForm2.Visibility = Visibility.Hidden;
            AddCatagoryForm.Visibility = Visibility.Visible;
        }

        private void PrevAddCatagory(object sender, RoutedEventArgs e)
        {
            ExpenseForm2.Visibility = Visibility.Visible;
            AddCatagoryForm.Visibility = Visibility.Hidden;
        }

        private void ClearExpenseForm1(object sender, RoutedEventArgs e)
        {
            txtExpenseDescription.Text = "";
            txtExpenseAmount.Text = "";
            txtExpenseDate.Text = "";
        }

        public void ClearExpenseForm()
        {
            expenseUpdating = false;
            updatedExpense = null;
            expenseUpdatedList = null;

            txtExpenseDescription.Text = "";
            txtExpenseAmount.Text = "";
            txtExpenseDate.Text = "";

            txtSelectedCatagory.Text = "Select a Catagory";
            txtSelectedCatagory.Foreground = new SolidColorBrush(Color.FromRgb(217, 83, 79));

            if (clickedButton != null)
            {
                Style? style1 = this.FindResource("OutlinedButton") as Style;
                clickedButton.Style = style1;
            }

            clickedButton = null;

            ExpenseForm2.Visibility = Visibility.Hidden;
            ExpenseForm1.Visibility = Visibility.Visible;
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
                List<Catagory> catagories = catagoryController.GetExpenseCatagory();

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
                    catagoryController.SaveExpenseCatagory(catagory);

                    updateCatagoryList();
                    ExpenseForm2.Visibility = Visibility.Visible;
                    AddCatagoryForm.Visibility = Visibility.Hidden;
                }


            }




        }

        private void updateCatagoryList()
        {

            CatagoryList.Children.Clear();
            CatagoryList.RowDefinitions.Clear();

            CatagoryController catagoryController = new CatagoryController();

            List<Catagory> catagories = catagoryController.GetExpenseCatagory();



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

        private void deleteExpenseItem(object sender, RoutedEventArgs e)
        {

            
            string message = "Are you sure to Delete Expense ?";
            string caption = "Delete";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;

            MessageBoxResult messageBoxResult = MessageBox.Show(message, caption, buttons, icon);


            if (messageBoxResult == MessageBoxResult.Yes)
            {
                expenseController.deleteExpenseFromFile(updatedExpense);
                updateExpenseList();
                ClearExpenseForm();
                expenseDelete.Visibility = Visibility.Collapsed;
            }
            

            

        }


    }
}
