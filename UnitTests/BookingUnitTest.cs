using Castle.Core.Resource;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;

namespace UnitTests
{
    public class BookingUnitTest
    {
        private readonly Mock<IBookingService> _bookingServiceMock;
        private readonly BookingController _bookingController;
        private static Booking? _bookings;

        public BookingUnitTest()
        {
            _bookingServiceMock = new Mock<IBookingService>();
            _bookingController = new BookingController(_bookingServiceMock.Object);
            _bookings = new Booking
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                CustomerId = 4,
                VehicleId = 4,
                CommentStatus = true,
                RatingStatus = false,
                Customer = new Customer { CustomerId = 1, Name = "Joao Silva" },
                Vehicle = new Vehicle { VehicleId = 1, Model = "Fox" }
            };
        }

        [Fact]
        public async Task Test_PostCreateBooking()
        {
            _bookingServiceMock.Setup(service => service.Create(It.IsAny<Booking>())).ReturnsAsync(_bookings);

            // Act
            var result = await _bookingController.Create(_bookings) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal(_bookings, result.Value);
        }
        
        [Fact]
        public async Task Test_GetAllBookings()
        {
            // Act
            var result = await _bookingController.GetAll() as OkObjectResult;
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        public async Task Test_GetBookingById()
        {
            int bookingId = 1;
            var expectedBooking = new Booking
            {
                BookingId = bookingId,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(10),
                CustomerId = 1,
                VehicleId = 1,
                CommentStatus = true,
                RatingStatus = false,
                Customer = new Customer { CustomerId = 1, Name = "Cinthia Barbosa" },
                Vehicle = new Vehicle { VehicleId = 1, Model = "Toyota" }
            };

            _bookingServiceMock.Setup(service => service.GetById(bookingId)).ReturnsAsync(expectedBooking);

            // Act
            var result = await _bookingController.GetById(bookingId) as OkObjectResult;
            var actualBooking = result.Value as Booking;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.NotNull(actualBooking);
            Assert.Equal(expectedBooking.BookingId, actualBooking.BookingId);
        }


    }
}
