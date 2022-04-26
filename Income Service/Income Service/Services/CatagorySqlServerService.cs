using Finance_App.Entity;
using Income_Service.DataAccess;

namespace Income_Service.Services
{
    public class CatagorySqlServerService : ICatagoryRepository
    {
        private readonly IncomeDbContext _context = new IncomeDbContext();

        public List<Catagory> GetAllCatagories()
        {
            return _context.Catagories.ToList();
        }

        public Catagory GetCatagory(int id)
        {
            return _context.Catagories.Find(id);
        }
    }
}
