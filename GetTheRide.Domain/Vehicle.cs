namespace GetTheRide.Domain
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Seats { get; set; }
        public int DriverId { get; set; }

        public User User { get; set; } = null!;
    }
}
