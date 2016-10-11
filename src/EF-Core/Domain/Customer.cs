using System;
using System.Collections.Generic;

namespace EFCore.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}