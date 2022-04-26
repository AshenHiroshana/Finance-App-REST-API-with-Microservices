using Finance_App.Entity;

namespace Income_Service.Services
{
    public interface ICatagoryRepository
    {
        public List<Catagory> GetAllCatagories();
        public Catagory GetCatagory(int id);
        public Catagory GetCatagoryByName(string name);
        public Catagory AddCatagory(Catagory catagory);
    }
}
