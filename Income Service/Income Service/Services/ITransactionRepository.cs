using Finance_App.Entity;

namespace Income_Service.Services
{
    public interface ITransactionRepository
    {
        public List<Transaction> GetAllTransactions();
        public Transaction GetTransaction(int id);
    }
}
