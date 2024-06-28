using Domain.Entities;
using Domain.Interfaces;
using Domain.Services;

namespace Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository) 
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<Booking> Create(Booking booking)
        {
            return await _bookingRepository.Create(booking);
        }

        public async Task<int> Delete(int id)
        {
            return await _bookingRepository.Delete(id);
        }

        public async Task<IEnumerable<Booking>> GetAll()
        {
            return await _bookingRepository.GetAll();
        }

        public async Task<Booking> GetById(int id)
        {
            return await _bookingRepository.GetById(id);
        }

        public async Task<int> Update(Booking booking)
        {
            return await _bookingRepository.Update(booking);
        }
    }
}
