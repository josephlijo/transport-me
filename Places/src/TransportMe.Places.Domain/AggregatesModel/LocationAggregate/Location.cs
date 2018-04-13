using System;
using TransportMe.Places.Domain.SeedWork;

namespace TransportMe.Places.Domain.AggregatesModel.LocationAggregate
{
    public class Location
        : Entity, IAggregateRoot
    {
        public string IdentityGuid { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public Address Address { get; private set; }

        public Location(string identity)
        {
            IdentityGuid = !string.IsNullOrWhiteSpace(identity) ? identity : throw new ArgumentNullException(nameof(identity));
        }

        public Location(string identity, string name, string description, Address address)
            : this(identity)
        {
            this.Name = name;
            this.Description = description;
            this.Address = address;
        }
    }
}
