using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Queries : Base
    {

        public Customers GetCustomer()
        {
            var customer = (from cust in context.Customers
                           select cust).FirstOrDefault();
            return customer;
        }

        public List<Products> GetProductsWithoutStock()
        {
            var products = context.Products.Where(x => x.UnitsInStock == 0).ToList();
            return products;
        }

        public List<Products> GetProductsMoreThan3PerUnit()
        {
            var products = (from prod in context.Products
                           where prod.UnitsInStock != 0 && prod.UnitPrice > 3
                           select prod).ToList();
            return products;
        }

        public List<Customers> GetCustomerByRegion(string s)
        {

            var customer = context.Customers.Where(x => x.Region == s).ToList();

            return customer;
        }

        public Products GetProductsByID()
        {
            var product = (from prod in context.Products
                           where prod.ProductID == 789
                           select prod).FirstOrDefault();

           return product;
        }

        public List<string> GetCustomers()
        {
            var customers = context.Customers.Select(x => x.CompanyName).Take(10).ToList();
            return customers;
        }

        public List<Orders> JoinCustomersAndOrders()
        {
            var join = (from customer in context.Customers
                       join order in context.Orders on customer.CustomerID equals order.CustomerID
                       where customer.Region == "WA" && order.OrderDate > new DateTime(1997, 1, 1)
                       select order).ToList();
            return join;
        }
    }
}
