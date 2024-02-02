using Microsoft.EntityFrameworkCore;

namespace CustomerOrders.Models
{
    public partial class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration Config=new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                //UseLazyLoadingProxies()加上此方法為自動仔入導覽屬性的內容          
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(Config.GetConnectionString("Northwind"));
            }
        }
    }
}
