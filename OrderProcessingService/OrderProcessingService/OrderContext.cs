using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingService
{
    class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}
