namespace GetTheRide.Domain
{
    public class Trip
    {
        public Trip()
        {
            Passengers = new HashSet<UserTrip>();
        }

        public int Id { get; set; }
        public int AvailableSeats { get; set; }
        public TripState State { get; set; }

        public virtual User Driver { get; set; } = null!;
        public ICollection<UserTrip> Passengers { get; set; }
    }

    public class UserTrip
    {
        public int Id { get; set; }

        public Trip Trip { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
