﻿using System;
using System.Collections.Generic;
using TransportMe.Places.Domain.SeedWork;

namespace TransportMe.Places.Domain.AggregatesModel.LocationAggregate
{
    public class Address : ValueObject
    {
        // Are immutable and we should not allow to set them once constructed
        public String Street { get; private set; }
        public String City { get; private set; }
        public String State { get; private set; }
        public String Country { get; private set; }
        public String ZipCode { get; private set; }

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
