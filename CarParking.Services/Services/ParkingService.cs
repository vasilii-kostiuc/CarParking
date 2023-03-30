using AutoMapper;
using CarParking.DataAccess.Repositories.Interfaces;
using CarParking.Models.Entities;
using CarParking.Services.Models.Parking;
using CarParking.Services.Services.Interfaces;

namespace CarParking.Services.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IMapper _mapper;
        private readonly IParkingRepository _parkingRepository;
        private readonly IParkingPriceCalculator _priceCalculator;

        public ParkingService(IMapper mapper, IParkingRepository parkingRepository, IParkingPriceCalculator priceCalculator)
        {
            _mapper = mapper;
            _parkingRepository = parkingRepository;
            _priceCalculator = priceCalculator;
        }

        public async Task<Parking> StartAsync(ParkingStartDto parkingStart)
        {
            var parking = _mapper.Map<Parking>(parkingStart);

            await _parkingRepository.AddAsync(parking);

            return parking;
        }

        public async Task<Parking> StopAsync(int id)
        {
            var parking = await _parkingRepository.FindAsync(id);

            parking.EndTime = DateTime.Now;
            parking.TotalPrice = _priceCalculator.Calc(parking.Zone, parking.StartTime, parking.EndTime);

            await _parkingRepository.UpdateAsync(parking);
            return parking;
        }
    }
}
