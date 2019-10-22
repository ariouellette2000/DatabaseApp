using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseForFred
{
    public static class DB
    {
        private static Demo1Entities myDB = new Demo1Entities();

        public static IEnumerable<Product> GetProducts()
        {
            //More secure to put it here
            return myDB.Products.ToList();
        }

        public static Product getProduct(int id)
        {
            return myDB.Products.Find(id);
        }
        public static Customer getCustomer(int id)
        {
            return myDB.Customers.Find(id);
        }

        public static void createProduct(Product product)
        {
            myDB.Products.Add(product);
            myDB.SaveChanges();
        }

        public static void createCustomer(Customer customer)
        {
            myDB.Customers.Add(customer);
            myDB.SaveChanges();
        }

        public static void updateCustomerName(Customer customer)
        {
          
            int id = customer.CustomerId;
            Customer initialCust = getCustomer(id);
            initialCust.CustomerFirstName = customer.CustomerFirstName;
            initialCust.CustomerLastName = customer.CustomerLastName;
            myDB.Entry(initialCust).State = EntityState.Modified;
            myDB.SaveChanges();
        }

        public static void createSales(Customer customer, Product product, Sale sale)
        {
            sale.CustomerId = customer.CustomerId;
            sale.ProductId = product.ProductId;
            myDB.Sales.Add(sale);
            myDB.SaveChanges();
        }

        public static List<Sale> listSales()
        {
            return myDB.Sales.ToList();
        }


        public static void deleteCustomer(int id)
        {
            myDB.Customers.Remove(myDB.Customers.Find(id));
            myDB.SaveChanges();
        }

    }
}
