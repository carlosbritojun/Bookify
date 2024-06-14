using Bookify.Domain.Features.Apartments;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Features.Bookings;

public class PricingService
{
    public PricingDetalis Calculate(Apartment apartment, DateRange period)
    {
        var currency = apartment.Price.Currency;

        var priceForPeriod = new Money(
            apartment.Price.Amount * period.LengthInDays,
            currency);

        decimal percentageUpCharge = GetPercentageUpChard(apartment.Amenities);

        var amenitiesUpCharge = Money.Zero();
        if (percentageUpCharge > 0)
        {
            amenitiesUpCharge = new Money(
                priceForPeriod.Amount * percentageUpCharge,
                currency);
        }

        var totalPrice = Money.Zero();

        totalPrice += priceForPeriod;

        if (!apartment.CleaningFee.IsZero())
        {
            totalPrice += apartment.CleaningFee;
        }

        totalPrice += amenitiesUpCharge;

        return new PricingDetalis(priceForPeriod, apartment.CleaningFee, amenitiesUpCharge, totalPrice);

    }

    private decimal GetPercentageUpChard(List<Amenity> amenities) => amenities.Sum(a => a switch
    {
        Amenity.GardenView or Amenity.MountainView => 0.05m,
        Amenity.AirConditioning => 0.01m,
        Amenity.Parking => 0.01m,
        _ => 0
    });
}
