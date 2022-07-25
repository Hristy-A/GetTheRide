namespace GetTheRide.Domain
{
    public class Trip
    {
        public Trip()
        {
            Passengers = new HashSet<Passenger>();
        }

        public int Id { get; set; }
        public int AvailableSeats { get; set; }
        public TripState State { get; set; }
        public int UserId { get; set; }

        public virtual User Driver { get; set; } = null!;
        public ICollection<Passenger> Passengers { get; set; }
    }
}
