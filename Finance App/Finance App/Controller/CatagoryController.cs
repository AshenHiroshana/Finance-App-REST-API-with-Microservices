using Finance_App.Entity;
using Finance_App.Resource;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    
    public class CatagoryController
    {

        ApiConfig apiConfig = new ApiConfig();

        public async Task SaveIncomeCatagory(Catagory catagory)
        {

            
            HttpResponseMessage responseMessage = await apiConfig.PostAsync("Income/api/Categories",catagory);

            if (!responseMessage.IsSuccessStatusCode)
            {
                //return catagories; //Error 
            }

        }

        public async Task<List<Catagory>> GetIncomeCatagory()
        {
   
            List<Catagory> catagories = new List<Catagory>();

            HttpResponseMessage responseMessage = await apiConfig.GetAsync("Income/api/Categories");
           
            if (!responseMessage.IsSuccessStatusCode)
            {
                return catagories; //Error 
            }

            catagories = await responseMessage.Content.ReadFromJsonAsync<List<Catagory>>();
            return catagories;

        }



        public async void SaveExpenseCatagory(Catagory catagory)
        {

            HttpResponseMessage responseMessage = await apiConfig.PostAsync("Expense/api/Categories", catagory);

            if (!responseMessage.IsSuccessStatusCode)
            {
                //return catagories; //Error 
            }

        }

        public async Task<List<Catagory>> GetExpenseCatagory()
        {

            List<Catagory> catagories = new List<Catagory>();

            HttpResponseMessage responseMessage = await apiConfig.GetAsync("Expense/api/Categories");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return catagories; //Error 
            }

            catagories = await responseMessage.Content.ReadFromJsonAsync<List<Catagory>>();
            return catagories;

        }
    }
}
