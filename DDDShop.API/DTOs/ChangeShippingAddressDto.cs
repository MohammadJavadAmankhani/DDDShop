
namespace DDDShop.API.DTOs;

public record ChangeShippingAddressDto
{
    public string Street { get; init; } = default!;
    public string City { get; init; } = default!;
    public string PostalCode { get; init; } = default!;
    public string Country { get; init; } = default!;
}
