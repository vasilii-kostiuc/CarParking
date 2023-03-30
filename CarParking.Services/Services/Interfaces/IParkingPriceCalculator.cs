using CarParking.Models.Entities;

namespace CarParking.Services.Services.Interfaces
{
    public interface IParkingPriceCalculator
    {
        public decimal Calc(Zone zone, DateTime start, DateTime end);
    }
}
