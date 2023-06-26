using CarParking.DataAccess.Repositories.Interfaces;
using CarParking.Models.Entities;
using CarParking.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParking.Services.Services
{
    public class ParkingPriceCalculator : IParkingPriceCalculator
    {
        public decimal Calc(Zone zone, DateTime start, DateTime end)
        {
            TimeSpan timeAtParking = end - start;

            decimal priceByMinit = zone.PricePerHour / 60;

            decimal totalPrice = priceByMinit * (decimal)timeAtParking.TotalMinutes;

            return totalPrice;
        }
    }
}
