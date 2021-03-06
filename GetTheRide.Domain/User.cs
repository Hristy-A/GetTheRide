namespace GetTheRide.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public int? VehicleId { get; set; }
        public virtual Vehicle? Vehicle { get; set; }
    }
}