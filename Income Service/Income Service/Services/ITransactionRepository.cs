using Income_Service.Models;

namespace Income_Service.Services
{
    public interface ITransactionRepository
    {
        public List<Transaction> GetAllTransactions();
        public Transaction GetTransaction(int id);
        public Transaction AddTransaction(Transaction transaction);
        public Transaction UpdateTransaction(Transaction transaction);
        public void DeleteTransaction(Transaction transaction);

    }
}
