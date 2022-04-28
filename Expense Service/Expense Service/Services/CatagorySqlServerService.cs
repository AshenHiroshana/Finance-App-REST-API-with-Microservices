using Expense_Service.DataAccess;
using Expense_Service.Models;

namespace Expense_Service.Services
{
    public class CatagorySqlServerService : ICatagoryRepository
    {
        private readonly ExpenseDbContext _context = new ExpenseDbContext();

        public Catagory AddCatagory(Catagory catagory)
        {
            _context.Catagories.Add(catagory);
            _context.SaveChanges();
            return catagory;

        }

        public List<Catagory> GetAllCatagories()
        {
            return _context.Catagories.ToList();
        }

        public Catagory GetCatagory(int id)
        {
            return _context.Catagories.Find(id);
        }

        public Catagory GetCatagoryByName(string name)
        {
            return _context.Catagories.Where(c => c.Name == name).FirstOrDefault();
        }
    }
}
