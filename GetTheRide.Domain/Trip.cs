using System.ComponentModel.DataAnnotations.Schema;

namespace GetTheRide.Domain
{
    public class Trip
    {
        public Trip()
        {
            Passengers = new HashSet<User>();
        }

        public int Id { get; set; }
        public int AvailableSeats { get; set; }
        public TripState State { get; set; }
        public int DriverId { get; set; }

        public virtual User Driver { get; set; } = null!;
        public virtual ICollection<User> Passengers { get; set; }
    }
}
