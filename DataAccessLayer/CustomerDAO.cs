using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        static List<Customer> customers = new List<Customer>();
        public void GenerateSampleDataset()
        {
            customers.Add(new Customer() { Id = 1, Name = "Obama", Phone ="0123456789", Email = "Obama@gmail.com"});
            customers.Add(new Customer() { Id = 2, Name = "Barack", Phone = "0321456789", Email = "Barack@gmail.com" });
            customers.Add(new Customer() { Id = 3, Name = "Kim", Phone = "0456456789", Email = "Kimgmail.com" });
            customers.Add(new Customer() { Id = 4, Name = "Jong", Phone = "0567456789", Email = "Jong@gmail.com" });
            customers.Add(new Customer() { Id = 5, Name = "Putin", Phone = "0789456789", Email = "Putinm@gmail.com" });
        }

        public List<Customer> GetCustomers()
        {
            return customers;
        }
    }
}
