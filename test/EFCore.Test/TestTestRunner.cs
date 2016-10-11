using System;
using System.Collections.Generic;
using System.Linq;
using EFCore.Domain;
using EFCore.Repository;
using Xunit;

namespace EFCore.Test
{
    public class DatabaseTests
    {
        Customer customer;
        CustomerRepository customerRepository;

        public DatabaseTests()
        {
            customer = new Customer()
            {
                Name = $"Customer-{DateTime.Now}",
                RegisterDate = DateTime.Now,
                Addresses = new List<Address>()
                {
                    new Address() { AddressType = AddressType.Home, Street = "1st Street" },
                }
            };

            customerRepository = new CustomerRepository(new AppDbContext());
        }


        // get all scenarios
        [Fact]
        public void Get_all_customers()
        {
            Add_single_customer();

            var customers = customerRepository.GetAllCustomers();

            Assert.NotNull(customers);
            Assert.True(customers.Any());
        }


        // get by id scenarios
        [Fact]
        public void Get_by_id_a_existent_customer()
        {
            Add_single_customer();

            var id = customer.Id;
            var insertedCustomer = customerRepository.GetById(id);

            Assert.NotNull(insertedCustomer);
            Assert.Equal(id, insertedCustomer.Id);
        }

        [Fact]
        public void Get_by_id_a_inexistent_customer()
        {
            var id = -1;
            var gotCustomer = customerRepository.GetById(customer.Id);

            Assert.Null(gotCustomer);
        }

        [Fact]
        public void Get_by_id_should_get_addresses_of_the_customer()
        {
            Add_customer_with_two_addresses();

            var id = customer.Id;
            var insertedCustomer = customerRepository.GetById(id);
            Func<Address, bool> allAddressesAreFilled = address => !string.IsNullOrEmpty(address?.Street);

            Assert.NotNull(insertedCustomer);
            Assert.NotNull(insertedCustomer.Addresses);
            Assert.Equal(2, insertedCustomer.Addresses.Count);
            Assert.True(insertedCustomer.Addresses.All(allAddressesAreFilled));
        }


        // insert scenarios
        [Fact]
        public void Add_single_customer()
        {
            customer.Name = $"Customer-{nameof(Add_single_customer)}";
            customerRepository.Add(customer);
        }

        [Fact]
        public void Add_customer_with_two_addresses()
        {
            var newAddress = new Address() { AddressType = AddressType.Work, Street = "2nd Avenue" };
            customer.Addresses.Add(newAddress);

            customer.Name = $"Customer-{nameof(Add_customer_with_two_addresses)}";
            customerRepository.Add(customer);
        }

        [Fact]
        public void Add_customer_without_address()
        {
            customer.Addresses.Clear();

            customer.Name = $"Customer-{nameof(Add_customer_without_address)}";
            customerRepository.Add(customer);
        }


        // update scenarios
        [Fact]
        public void Update_single_customer()
        {
            Add_single_customer();

            var newName = $"Update!-{customer.Name}";
            customer.Name = newName;

            var rowsAffected = customerRepository.Update(customer);
            var updatedCustomer = customerRepository.GetById(customer.Id);

            Assert.Equal(1, rowsAffected);
            Assert.NotNull(updatedCustomer);
            Assert.Equal(newName, updatedCustomer.Name);
        }
    }
}