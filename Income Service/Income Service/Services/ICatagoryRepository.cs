using Finance_App.Entity;

namespace Income_Service.Services
{
    public interface ICatagoryRepository
    {
        public List<Catagory> GetAllCatagories();
        public Catagory GetCatagory(int id);
    }
}
