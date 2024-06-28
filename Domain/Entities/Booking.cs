namespace Domain.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public bool? RatingStatus { get; set; }
        public bool? CommentStatus { get; set; }
        public virtual Customer Customer { get; set; }  
        public virtual Vehicle Vehicle { get; set; }
    }
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Model { get; set; } = string.Empty;
    }
}
