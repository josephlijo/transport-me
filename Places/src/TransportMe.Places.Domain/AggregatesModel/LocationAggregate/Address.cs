using System;
using System.Collections.Generic;
using TransportMe.Places.Domain.SeedWork;

namespace TransportMe.Places.Domain.AggregatesModel.LocationAggregate
{
    public class Address : ValueObject
    {
        public String Street { get; }
        public String City { get; }
        public String State { get; }
        public String Country { get; }
        public String ZipCode { get; }

        private Address()
        {
        }

        public Address(string street, string city, string state, string country, string zipcode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
            yield return State;
            yield return Country;
            yield return ZipCode;
        }
    }
}
