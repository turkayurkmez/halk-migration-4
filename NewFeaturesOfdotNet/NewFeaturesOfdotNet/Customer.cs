using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeaturesOfdotNet
{
    public class Customer
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public string Country { get; set; }
    }
    public class CustomerService
    {
        public IEnumerable<Customer> GetCustomers() => new List<Customer>()
        {
            new(){ Name ="Samsung", Country="Kore", Budget=100000},
            new(){ Name ="Hyundai", Country="Kore", Budget=150000},
            new(){ Name ="Apple", Country="Amerika", Budget=70000},

        };

    }
}
