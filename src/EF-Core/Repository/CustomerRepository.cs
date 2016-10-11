using System.Collections.Generic;
using System.Linq;
using EFCore.Domain;

namespace EFCore.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;

        // constructor
        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        // publics
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _appDbContext.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            return _appDbContext.Customers.SingleOrDefault(c => c.Id == id);
        }

        public void Add(Customer customer)
        {
            _appDbContext.Add(customer);
            _appDbContext.SaveChanges();
        }

        public int Update(Customer customer)
        {
            return _appDbContext.SaveChanges();
        }

        public void Delete(Customer customer)
        {

        }
    }
}