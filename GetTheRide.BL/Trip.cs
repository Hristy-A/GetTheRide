namespace GetTheRide.BL
{
    public class Trip
    {
        public int Id { get; set; }
        public int AvailableSeats { get; set; }
        public string State { get; set; }
        public Driver Driver { get; set; }
        public ICollection<Passenger> Passengers { get; set; }
    }
}