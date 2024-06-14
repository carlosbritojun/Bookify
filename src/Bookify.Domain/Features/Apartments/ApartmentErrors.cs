using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Features.Apartments;

public static class ApartmentErrors
{
    public static Error NotFound = new(
        "User.NotFound",
        "The apartmet with the specified identifier was not found");
}
