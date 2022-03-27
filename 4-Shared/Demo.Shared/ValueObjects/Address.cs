namespace Demo.Shared.ValueObjects
{
    public class Address
    {
        public int Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string ZipCode { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Complement { get; private set; }
        private Address() { }
        public Address(int number, string neighborhood, string zipCode,
            string city, string state, string complement)
            :this()
        {
            Number = number;
            Neighborhood = neighborhood;
            ZipCode = zipCode;
            City = city;
            State = state;
            Complement = complement;
        }

        
    }
}
