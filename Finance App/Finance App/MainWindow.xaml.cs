using Finance_App.Controller;
using Finance_App.View;
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

namespace Finance_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PreData preData = new PreData();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            string menuItem = lbi.Name.ToString();

            if(menuItem == "Home")
                DataContext = new HomeView();
            if (menuItem == "Income")
                DataContext = new IncomeView();
            if (menuItem == "Expence")
                DataContext = new ExpenseView();
            if (menuItem == "Prediction")
                DataContext = new PredictionView();

        }


        private void dragMe(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void closeApp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void closeHoverON(object sender, MouseEventArgs e)
        {
            if (sender is Ellipse ellipse)
            {
                BrushConverter converter = new BrushConverter();
                ellipse.Fill = converter.ConvertFromString("#F33") as Brush;
            }
        }

        private void closeHoverOFF(object sender, MouseEventArgs e)
        {
            if (sender is Ellipse ellipse)
            {
                BrushConverter converter = new BrushConverter();
                ellipse.Fill = converter.ConvertFromString("#D00") as Brush;
            }
        }


        private void minimizeApp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                
            }
        }

        private void minimizeHoverON(object sender, MouseEventArgs e)
        {
            if (sender is Ellipse ellipse)
            {
                BrushConverter converter = new BrushConverter();
                ellipse.Fill = converter.ConvertFromString("#FF3") as Brush;
            }
        }

        private void minimizeHoverOFF(object sender, MouseEventArgs e)
        {
            if (sender is Ellipse ellipse)
            {
                BrushConverter converter = new BrushConverter();
                ellipse.Fill = converter.ConvertFromString("#DD0") as Brush;
            }
        }

        private void Expences_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void changeSelectedFilter(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            ComboBoxItem boxItem = (ComboBoxItem)comboBox.SelectedItem;
            Common.selectedFilter = boxItem.Name;

            ListBox listBox = (ListBox)menuList;
           if (listBox != null && listBox.SelectedItem != null)
            {
                ListBoxItem selectedMenuItem = (ListBoxItem)listBox.SelectedItem;

                string menuItem = selectedMenuItem.Name.ToString();
                if (menuItem == "Home")
                    DataContext = new HomeView();
                if (menuItem == "Income")
                    DataContext = new IncomeView();
                if (menuItem == "Expence")
                    DataContext = new ExpenseView();
                if (menuItem == "Prediction")
                    DataContext = new PredictionView();
            }
        }

       
        private void changeSelectedDate(object sender, RoutedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            Common.selectedDate = (DateTime)datePicker.GetValue(DatePicker.SelectedDateProperty);
            ListBox listBox = (ListBox)menuList;
            ListBoxItem selectedMenuItem = (ListBoxItem)listBox.SelectedItem;

            string menuItem = selectedMenuItem.Name.ToString();
            if (menuItem == "Home")
                DataContext = new HomeView();
            if (menuItem == "Income")
                DataContext = new IncomeView();
            if (menuItem == "Expence")
                DataContext = new ExpenseView();
            if (menuItem == "Prediction")
                DataContext = new PredictionView();

        }

        
    }
}
