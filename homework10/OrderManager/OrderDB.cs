using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager {
    public class OrderDB:DbContext {
        public OrderDB():base("OrderDataBase") {
        }
        public DbSet<Order> Order { get; set; }

        public DbSet<OrderDetails> OrderItem { get; set; }
    
    }
}
