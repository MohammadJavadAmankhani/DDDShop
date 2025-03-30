using System;
namespace DDDShop.Domain.Aggregates.Orders.ValueObjects;
public class Address
{
    public string Street { get; }
    public string City { get; }
    public string PostalCode { get; }
    public string Country { get; }

    private Address() { }

    public Address(string street, string city, string postalCode, string country)
    {
        Street = street ?? throw new ArgumentNullException(nameof(street));
        City = city ?? throw new ArgumentNullException(nameof(city));
        PostalCode = postalCode ?? throw new ArgumentNullException(nameof(postalCode));
        Country = country ?? throw new ArgumentNullException(nameof(country));
    }
}
