namespace _02.Data_Access_Objects
{
    using Northwind.Model;

    public class NorthwindDao
    {

        public int InsertCustomer(Customer customer)
        {
            using (var dbContext = new NorthwindEntities())
            {
                dbContext.Customers.Add(customer);
                return dbContext.SaveChanges();
            }
        }

        public Customer DeleteCustomer(Customer customer)
        {
            using (var dbContext = new NorthwindEntities())
            {
                dbContext.Customers.Remove(customer);
                dbContext.SaveChanges();
            }

            return customer;
        }

        public int DeleteCustomerById(string id)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var customer = dbContext.Customers.Find(id);
                dbContext.Customers.Remove(customer);
                return dbContext.SaveChanges();
            }
        }

        public int ModifyCustomer(string id, string newCompanyName)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var customer = dbContext.Customers.Find(id);
                if (customer != null)
                {
                    customer.CompanyName = newCompanyName;                    
                }
                return dbContext.SaveChanges();
            }
        }
    }
}