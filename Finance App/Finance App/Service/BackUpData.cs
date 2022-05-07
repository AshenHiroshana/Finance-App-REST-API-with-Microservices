using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace Finance_App.Service
{
    internal class BackUpData
    {

        public static void writeBacakUpDataToFile(string file, string jsonString)
        {
            //string jsonString = JsonSerializer.Serialize(fullExpenseList);

            StreamWriter writer = new StreamWriter("./"+file+".txt");
            writer.Write(jsonString);
            writer.Close();
        }

        public static string readBacakUpDataFromFile(string file)
        {
            StreamReader reader = new StreamReader("./" + file + ".txt");
            String json = reader.ReadToEnd();
            reader.Close();
            return json;

            /*List<Transaction> expenseList = JsonSerializer.Deserialize<List<Transaction>>(json)!;*/
        }

    }

}
