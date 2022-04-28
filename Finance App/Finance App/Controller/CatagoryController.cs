using Finance_App.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Finance_App.Controller
{
    public class CatagoryController
    {

        

        public void SaveIncomeCatagory(Catagory catagory)
        {

            //List<Catagory> catagories = GetIncomeCatagory();
            PreData.incomeCatagories.Add(catagory);
 

        }

        public List<Catagory> GetIncomeCatagory()
        {

            try
            {
                if (PreData.incomeCatagories == null)
                {
                    StreamReader reader = new StreamReader("C:/Users/Ashen/Desktop/OriginalIncomeCatagoryList.txt");
                    String json = reader.ReadToEnd();
                    reader.Close();

                    PreData.incomeCatagories = JsonSerializer.Deserialize<List<Catagory>>(json)!;
                   

                    return PreData.incomeCatagories;
                }
                else
                {
                    
                    return PreData.incomeCatagories;


                }
            }
            catch (Exception ex2)
            {
                
                PreData.incomeCatagories = new List<Catagory>();
                return PreData.incomeCatagories;


            }

        }



        public void SaveExpenseCatagory(Catagory catagory)
        {

            PreData.expenseCatagories.Add(catagory);

        }

        public List<Catagory> GetExpenseCatagory()
        {

            try
            {
                if (PreData.expenseCatagories == null)
                {
                    StreamReader reader = new StreamReader("C:/Users/Ashen/Desktop/OriginalExpenseCatagoryList.txt");
                    String json = reader.ReadToEnd();
                    reader.Close();

                    PreData.expenseCatagories = JsonSerializer.Deserialize<List<Catagory>>(json)!;


                    return PreData.expenseCatagories;
                }
                else
                {

                    return PreData.expenseCatagories;


                }
            }
            catch (Exception ex)
            {
                
                    PreData.expenseCatagories = new List<Catagory>();
                    return PreData.expenseCatagories;
                
            }

        }
    }
}
