using Finance_App.Entity;
using Income_Service.DataAccess;

namespace Income_Service.Services
{
    public class CatagorySqlServerService : ICatagoryRepository
    {
        private readonly IncomeDbContext _context = new IncomeDbContext();

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
