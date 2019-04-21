using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageApp
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public DateTime ArrivalDate { get; set; }

        public Product()
        {
            Id = Guid.NewGuid();
        }
    }
}
