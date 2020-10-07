using BankWebApi.Entitys;
using Microsoft.EntityFrameworkCore;


namespace BankWebApi.ContextFolder
{
    public class DataContext : DbContext
    {
        public DbSet<PhysClients> PhysClients { get; set; }
        public DbSet<CompanyClients> CompanyClients { get; set; }
        public DbSet<Giros> Giros { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Credits> Credits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;
                Database=WebApiBankDB;
                Trusted_Connection=True;");
        }
    }
}
