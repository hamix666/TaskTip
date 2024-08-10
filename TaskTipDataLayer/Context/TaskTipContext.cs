using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskTipDataLayer.Entity;

namespace TaskTipDataLayer.Context;

public class TaskTipContext :DbContext
{
    public TaskTipContext(DbContextOptions<TaskTipContext> options) : base(options)
    {
        
    }

    public TaskTipContext()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json").Build();

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        base.OnConfiguring(optionsBuilder);

    }

    #region DbSet
    public DbSet<Customer> Customers_List { get; set; }
    
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new CustomerConfiguration().Configure(modelBuilder.Entity<Customer>());
        base.OnModelCreating(modelBuilder);
    }
}