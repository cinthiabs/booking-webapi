using Domain.Entities;

namespace Domain.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAll();
        Task<Booking> GetById(int id);
        Task<Booking> Create(Booking booking);
        Task<int> Update(Booking booking);
        Task<int> Delete(int id);
    }
}
