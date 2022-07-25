namespace GetTheRide.BL
{
    public class Trip
    {
        public int Id { get; set; }
        public int AvailableSeats { get; set; }
        public string State { get; set; } = null!;
        public Driver Driver { get; set; } = null!;
        public ICollection<Passenger> Passengers { get; set; } = null!;
    }
}