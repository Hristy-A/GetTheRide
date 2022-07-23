namespace GetTheRide.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool IsInTrip { get; set; }

        public Vehicle? Vehicle { get; set; }
        public Trip? Trip { get; set; }
    }
}