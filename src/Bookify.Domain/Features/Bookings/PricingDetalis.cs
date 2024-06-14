using Bookify.Domain.Shared;

namespace Bookify.Domain.Features.Bookings;

public record PricingDetalis(
    Money PriceForPeriod,
    Money CleaningFee,
    Money AmenitiesUpCharge,
    Money TotalPrice);