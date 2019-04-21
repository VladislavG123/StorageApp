namespace StorageApp
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AppContext : DbContext
    {
        public AppContext()
            : base("name=AppContext")
        {
        }

        public DbSet<Product> Products { get; set; }
    }

}