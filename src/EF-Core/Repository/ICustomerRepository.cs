using System.Collections.Generic;
using EFCore.Domain;

namespace EFCore.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetById(int id);
        void Add(Customer customer);
        int Update(Customer customer);
        void Delete(Customer customer);
    }
}