using Expense_Service.Models;

namespace Expense_Service.Services
{
    public interface ICatagoryRepository
    {
        public List<Catagory> GetAllCatagories();
        public Catagory GetCatagory(int id);
        public Catagory GetCatagoryByName(string name);
        public Catagory AddCatagory(Catagory catagory);
    }
}
