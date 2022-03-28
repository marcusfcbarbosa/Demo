using System;

namespace Demo.Shared.ValueObjects
{
    public class Address
    {
        public Guid Id { get; private set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Complement { get; set; }
        private Address() { }
        public Address(int number, string neighborhood,
                       string zipCode, string city,
                       string state, string complement)
                        : this()
        {
            Id = Guid.NewGuid();
            Number = number;
            Neighborhood = neighborhood;
            ZipCode = zipCode;
            City = city;
            State = state;
            Complement = complement;
        }
    }
}
