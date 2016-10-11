namespace EFCore.Domain
{
    public class Address
    {
        public int Id { get; set; }
        public AddressType AddressType { get; set; }
        public string Street { get; set; }
    }
}