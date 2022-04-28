using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;
using Path = System.Windows.Shapes.Path;

namespace Finance_App.View
{
    public class Common : UserControl
    {

        public static DateTime selectedDate = DateTime.Today;
        public static string selectedFilter = "filterByWeek";



        public static Button CreateCatagoryButton(string? name, string? icon, Style? style)
        {
            

            Button button = new Button();
            
            button.Content = name;
            button.Style = style;
            button.Height = 50;
            button.Width = 230;
            button.Content = name;
            button.ToolTip = name;
            button.Name = icon;
            /* button.Foreground = new SolidColorBrush(Color.FromRgb(2, 117, 216));
             button.BorderBrush = new SolidColorBrush(Color.FromRgb(2, 117, 216));*/
            button.HorizontalAlignment = HorizontalAlignment.Left;
            //button.Padding = new Thickness(0,0,10,0);

            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            //stackPanel.Margin = new Thickness(0);

            Viewbox packIcon = FindIcon(icon);
            packIcon.Width = 20;
            packIcon.Height = 20;
            packIcon.VerticalAlignment = VerticalAlignment.Center;
            packIcon.HorizontalAlignment = HorizontalAlignment.Center;
            //packIcon.Foreground = new SolidColorBrush(Color.FromRgb(2, 117, 216));
            stackPanel.Children.Add(packIcon);

            TextBlock textBlock = new TextBlock();
            textBlock.Text = name;
            textBlock.Margin = new Thickness(10, 0, 0, 0);
            stackPanel.Children.Add(textBlock);

            button.Content = stackPanel;
            return button;

        }

       


        public static Viewbox FindIcon(string name, Boolean colorDefault = true)
        {
            Path path = new Path();
            if (colorDefault)
            {
                path.Fill = new SolidColorBrush(Color.FromRgb(98, 0, 240));
            }
            else
            {
                path.Fill = new SolidColorBrush(Color.FromRgb(92, 184, 92));
            }



             switch (name)
             {
                 case "Home":
                     path.SetValue(System.Windows.Shapes.Path.DataProperty, Geometry.Parse("M 10,20 V 14 H 14 V 20 H 19 V 12 H22 L 12,3 L 2,12 H 5 V 20 H 10 Z"));
                     break;

                 case "Car":
                     path.SetValue(System.Windows.Shapes.Path.DataProperty, Geometry.Parse("M5,11 L6.5,6.5 H17.5 L19,11 M17.5,16 A1.5,1.5 0 0,1 16,14.5 A1.5,1.5 0 0,1 17.5,13 A1.5,1.5 0 0,1 19,14.5 A1.5,1.5 0 0,1 17.5,16 M6.5,16 A1.5,1.5 0 0,1 5,14.5 A1.5,1.5 0 0,1 6.5,13 A1.5,1.5 0 0,1 8,14.5 A1.5,1.5 0 0,1 6.5,16 M18.92,6 C18.72,5.42 18.16,5 17.5,5 H6.5 C5.84,5 5.28,5.42 5.08,6 L3,12 V20 A1,1 0 0,0 4,21 H5 A1,1 0 0,0 6,20 V19 H18 V20 A1,1 0 0,0 19,21 H20 A1,1 0 0,0 21,20 V12 L18.92,6 Z"));
                     break;

                 case "Travel":
                     path.SetValue(System.Windows.Shapes.Path.DataProperty, Geometry.Parse("M12,4 H5 A3,3 0 0,0 2,7 V15 A3,3 0 0,0 5,18 L4,19 V20 H5 L7,17.97 L9,18 V13 H4 V6 H13 V8 H15 V7 A3,3 0 0,0 12,4 M5,14 A1,1 0 0,1 6,15 A1,1 0 0,1 5,16 A1,1 0 0,1 4,15 A1,1 0 0,1 5,14 M20.57,9.66 C20.43,9.26 20.05,9 19.6,9 H12.41 C11.95,9 11.58,9.26 11.43,9.66 L10,13.77 V19.28 C10,19.66 10.32,20 10.7,20 H11.32 C11.7,20 12,19.62 12,19.24 V18 H20 V19.24 C20,19.62 20.31,20 20.69,20 H21.3 C21.68,20 22,19.66 22,19.28 V17.91 L22,13.77 L20.57,9.66 M12.41,10 H19.6 L20.63,13 H11.38 L12.41,10 M12,16 A1,1 0 0,1 11,15 A1,1 0 0,1 12,14 A1,1 0 0,1 13,15 A1,1 0 0,1 12,16 M20,16 A1,1 0 0,1 19,15 A1,1 0 0,1 20,14 A1,1 0 0,1 21,15 A1,1 0 0,1 20,16 Z"));
                    break;

                case "Food":
                     path.SetValue(System.Windows.Shapes.Path.DataProperty, Geometry.Parse("M18.06 23 H19.72 C20.56 23 21.25 22.35 21.35 21.53 L23 5.05 H18 V1 H16.03 V5.05 H11.06 L11.36 7.39 C13.07 7.86 14.67 8.71 15.63 9.65 C17.07 11.07 18.06 12.54 18.06 14.94 V23 M1 22 V21 H16.03 V22 C16.03 22.54 15.58 23 15 23 H2 C1.45 23 1 22.54 1 22 M16.03 15 C16.03 7 1 7 1 15 H16.03 M1 17 H16 V19 H1 V17 Z"));
                    break;

                case "TshirtCrewOutline":
                     path.SetValue(System.Windows.Shapes.Path.DataProperty, Geometry.Parse("M16,21 H8 A1,1 0 0,1 7,20 V12.07 L5.7,13.12 C5.31,13.5 4.68,13.5 4.29,13.12 L1.46,10.29 C1.07,9.9 1.07,9.27 1.46,8.88 L7.34,3 H9 C9,4.1 10.34,5 12,5 C13.66,5 15,4.1 15,3 H16.66 L22.54,8.88 C22.93,9.27 22.93,9.9 22.54,10.29 L19.71,13.12 C19.32,13.5 18.69,13.5 18.3,13.12 L17,12.07 V20 A1,1 0 0,1 16,21 M20.42,9.58 L16.11,5.28 C15.8,5.63 15.43,5.94 15,6.2 C14.16,6.7 13.13,7 12,7 C10.3,7 8.79,6.32 7.89,5.28 L3.58,9.58 L5,11 L8,9 H9 V19 H15 V9 H16 L19,11 L20.42,9.58 Z"));
                    break;

                case "Pill":
                     path.SetValue(System.Windows.Shapes.Path.DataProperty, Geometry.Parse("M4.22,11.29 L11.29,4.22 C13.64,1.88 17.43,1.88 19.78,4.22 C22.12,6.56 22.12,10.36 19.78,12.71L12.71,19.78 C10.36,22.12 6.56,22.12 4.22,19.78 C1.88,17.43 1.88,13.64 4.22,11.29 M5.64,12.71 C4.59,13.75 4.24,15.24 4.6,16.57 L10.59,10.59 L14.83,14.83 L18.36,11.29 C19.93,9.73 19.93,7.2 18.36,5.64 C16.8,4.07 14.27,4.07 12.71,5.64 L5.64,12.71 Z"));
                    break;

                case "FuelPump":
                     path.SetValue(System.Windows.Shapes.Path.DataProperty, Geometry.Parse("M18,10A1,1 0 0,1 17,9A1,1 0 0,1 18,8A1,1 0 0,1 19,9A1,1 0 0,1 18,10M12,10H6V5H12M19.77,7.23L19.78,7.22L16.06,3.5L15,4.56L17.11,6.67C16.17,7 15.5,7.93 15.5,9A2.5,2.5 0 0,0 18,11.5C18.36,11.5 18.69,11.42 19,11.29V18.5A1,1 0 0,1 18,19.5A1,1 0 0,1 17,18.5V14C17,12.89 16.1,12 15,12H14V5C14,3.89 13.1,3 12,3H6C4.89,3 4,3.89 4,5V21H14V13.5H15.5V18.5A2.5,2.5 0 0,0 18,21A2.5,2.5 0 0,0 20.5,18.5V9C20.5,8.31 20.22,7.68 19.77,7.23Z"));
                    break;

                case "BabyFaceOutline":
                     path.SetValue(System.Windows.Shapes.Path.DataProperty, Geometry.Parse("M14.5,9.25A1.25,1.25 0 0,1 15.75,10.5A1.25,1.25 0 0,1 14.5,11.75A1.25,1.25 0 0,1 13.25,10.5A1.25,1.25 0 0,1 14.5,9.25M9.5,9.25A1.25,1.25 0 0,1 10.75,10.5A1.25,1.25 0 0,1 9.5,11.75A1.25,1.25 0 0,1 8.25,10.5A1.25,1.25 0 0,1 9.5,9.25M7.5,14H16.5C15.74,15.77 14,17 12,17C10,17 8.26,15.77 7.5,14M1,12C1,10.19 2.2,8.66 3.86,8.17C5.29,5.11 8.4,3 12,3C15.6,3 18.71,5.11 20.15,8.17C21.8,8.66 23,10.19 23,12C23,13.81 21.8,15.34 20.15,15.83C18.71,18.89 15.6,21 12,21C8.4,21 5.29,18.89 3.86,15.83C2.2,15.34 1,13.81 1,12M12,5C8.82,5 6.14,7.12 5.28,10H5A2,2 0 0,0 3,12A2,2 0 0,0 5,14H5.28C6.14,16.88 8.82,19 12,19C15.18,19 17.86,16.88 18.72,14H19A2,2 0 0,0 21,12A2,2 0 0,0 19,10H18.72C17.86,7.12 15.18,5 12,5Z"));
                    break;

                case "QuestionMark":
                     path.SetValue(System.Windows.Shapes.Path.DataProperty, Geometry.Parse("M10,19H13V22H10V19M12,2C17.35,2.22 19.68,7.62 16.5,11.67C15.67,12.67 14.33,13.33 13.67,14.17C13,15 13,16 13,17H10C10,15.33 10,13.92 10.67,12.92C11.33,11.92 12.67,11.33 13.5,10.67C15.92,8.43 15.32,5.26 12,5A3,3 0 0,0 9,8H6A6,6 0 0,1 12,2Z"));
                    break;
                case "AddCircle":
                     path.SetValue(System.Windows.Shapes.Path.DataProperty, Geometry.Parse("M17,13H13V17H11V13H7V11H11V7H13V11H17M12,2A10,10 0 0,0 2,12A10,10 0 0,0 12,22A10,10 0 0,0 22,12A10,10 0 0,0 12,2Z"));
                    break;
                case "Dollar":
                     path.SetValue(System.Windows.Shapes.Path.DataProperty, Geometry.Parse("M7,15H9C9,16.08 10.37,17 12,17C13.63,17 15,16.08 15,15C15,13.9 13.96,13.5 11.76,12.97C9.64,12.44 7,11.78 7,9C7,7.21 8.47,5.69 10.5,5.18V3H13.5V5.18C15.53,5.69 17,7.21 17,9H15C15,7.92 13.63,7 12,7C10.37,7 9,7.92 9,9C9,10.1 10.04,10.5 12.24,11.03C14.36,11.56 17,12.22 17,15C17,16.79 15.53,18.31 13.5,18.82V21H10.5V18.82C8.47,18.31 7,16.79 7,15Z"));
                    break;

                default:
                     path.SetValue(System.Windows.Shapes.Path.DataProperty, Geometry.Parse("M10,19H13V22H10V19M12,2C17.35,2.22 19.68,7.62 16.5,11.67C15.67,12.67 14.33,13.33 13.67,14.17C13,15 13,16 13,17H10C10,15.33 10,13.92 10.67,12.92C11.33,11.92 12.67,11.33 13.5,10.67C15.92,8.43 15.32,5.26 12,5A3,3 0 0,0 9,8H6A6,6 0 0,1 12,2Z"));
                    break;

            }



            Canvas canvas = new Canvas();
            canvas.Width = 24;
            canvas.Height = 24;
            canvas.Children.Add(path);

            Viewbox viewbox = new Viewbox();
            viewbox.Height = 20;
            viewbox.Width = 20;
            viewbox.Child = canvas;


            return viewbox;

        }




    }
}
