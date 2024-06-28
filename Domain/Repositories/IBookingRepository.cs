using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAll();
        Task<Booking> GetById(int id);
        Task<Booking> Create(Booking booking);
        Task<int> Update(Booking booking);
        Task<int> Delete(int id);
    }
}
