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

        public async Task<IEnumerable<Parking>> getActive(int userId)
        {
            var parkings = await _parkingRepository.GetActive(userId);

            foreach (Parking parking in parkings)
            {
                parking.TotalPrice = _priceCalculator.Calc(parking.Zone, parking.StartTime, DateTime.Now);
            }

            return parkings;
        }

        public async Task<IEnumerable<Parking>> GetAllAsync()
        {
            var parkings = await _parkingRepository.GetAllAsync();

            foreach(Parking parking in parkings)
            {
                parking.TotalPrice = _priceCalculator.Calc(parking.Zone, parking.StartTime, DateTime.Now);
            }

            return parkings;
        }

        public async Task<IEnumerable<Parking>> GetAllAsync(int userId)
        {
            var parkings = await _parkingRepository.GetActive(userId);

            foreach (Parking parking in parkings)
            {
                parking.TotalPrice = _priceCalculator.Calc(parking.Zone, parking.StartTime, DateTime.Now);
            }

            return parkings;
        }

        public async Task<Parking> GetAsync(int parkingId)
        {
            return await _parkingRepository.FindAsync(parkingId);
        }

        public async Task<IEnumerable<Parking>> getHistory(int userId)
        {
            var parkings = await _parkingRepository.GetHistory(userId);
                       
            return parkings;
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
