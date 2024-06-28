using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private static List<Booking> _bookings;

        static BookingRepository()
        {
            _bookings = new List<Booking>
            {
                new Booking
                { 
                        BookingId = 1, 
                        StartDate = DateTime.Now, 
                        EndDate = DateTime.Now.AddDays(10), 
                        CustomerId = 1, 
                        VehicleId = 1 ,
                        CommentStatus = true,
                        RatingStatus = false,
                        Customer = new Customer { CustomerId = 1, Name = "Cinthia Barbosa" },
                        Vehicle = new Vehicle { VehicleId = 1, Model = "Toyota" }
                },
                new Booking
                { 
                    BookingId = 2, 
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(10), 
                    CustomerId = 2, 
                    VehicleId = 2,
                    RatingStatus = true,
                    CommentStatus = true,
                    Customer = new Customer { CustomerId = 2, Name = "Maria Silva" },
                    Vehicle = new Vehicle { VehicleId = 2, Model = "Uno" }
                },
                new Booking
                {
                    BookingId = 3,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    CustomerId = 3,
                    VehicleId = 2,
                    RatingStatus = true,
                    CommentStatus = false,
                    Customer = new Customer { CustomerId = 3, Name = "Ana Barbosa" },
                    Vehicle = new Vehicle { VehicleId = 2, Model = "Uno" }
                }
            };
        }

        public Task<Booking> Create(Booking booking)
        {
            booking.BookingId = _bookings.Count + 1; 
            _bookings.Add(booking);
            return Task.FromResult(booking); 
        }

        public Task<int> Delete(int id)
        {
            var bookingToRemove = _bookings.FirstOrDefault(b => b.BookingId == id);
            if (bookingToRemove != null)
            {
                _bookings.Remove(bookingToRemove);
                return Task.FromResult(id);
            }
            return Task.FromResult(-1); 
        }

        public Task<IEnumerable<Booking>> GetAll()
        {
            return Task.FromResult<IEnumerable<Booking>>(_bookings);
        }

        public Task<Booking> GetById(int id)
        {
            var booking = _bookings.FirstOrDefault(b => b.BookingId == id);
            if(booking == null)
            {
                return Task.FromResult(new Booking { BookingId = 0 });
            }
            return Task.FromResult(booking);
        }

        public Task<int> Update(Booking booking)
        {
            var existingBooking = _bookings.FirstOrDefault(b => b.BookingId == booking.BookingId);
            if (existingBooking is not null)
            {
                existingBooking.StartDate = booking.StartDate;
                existingBooking.EndDate = booking.EndDate;
                existingBooking.CustomerId = booking.CustomerId;
                existingBooking.VehicleId = booking.VehicleId;
                existingBooking.RatingStatus = booking.RatingStatus;
                existingBooking.CommentStatus = booking.CommentStatus;
                existingBooking.Customer = booking.Customer;
                existingBooking.Vehicle = booking.Vehicle;
                return Task.FromResult(1); 
            }
            return Task.FromResult(0); 
        }
    }
}
