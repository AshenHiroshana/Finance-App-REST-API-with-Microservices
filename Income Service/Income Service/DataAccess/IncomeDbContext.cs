using Income_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Income_Service.DataAccess
{
    public class IncomeDbContext: DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Catagory> Catagories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = "Server=DESKTOP-150BK28; Database=Income; User Id=root; Password=1234";
            var connectionString = "Server=tcp:incomeservicedbserver.database.windows.net,1433;Initial Catalog=Income_Service_db;Persist Security Info=False;User ID=Ashen;Password=Earth1234@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catagory>().HasData(new Catagory[]
            {
                new Catagory { Id = 1, Name = "Home", Icon = "Home"},
                new Catagory { Id = 2, Name = "Salary", Icon = "Dollar"},
                new Catagory { Id = 3, Name = "Other", Icon = "QuestionMark"}
            });

            modelBuilder.Entity<Transaction>().HasData(new Transaction[]
            {
                new Transaction { Id = 1, Amount = 100, Description = "a", Date = DateTime.Now, CatagoryId = 1},
                new Transaction { Id = 2, Amount = 100, Description = "a", Date = DateTime.Now, CatagoryId = 2}
            });

            modelBuilder.Entity<Catagory>().HasIndex(c => c.Name).IsUnique();

            
            //modelBuilder.Entity<Transaction>().HasOne<Catagory>().WithMany().HasForeignKey(c => c.Id);

        }

    }
}