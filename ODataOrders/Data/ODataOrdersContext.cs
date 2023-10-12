using Microsoft.EntityFrameworkCore;

namespace ODataOrders.Data
{
	public class ODataOrdersContext : DbContext
	{
        public ODataOrdersContext(DbContextOptions<ODataOrdersContext> options)
            : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}
