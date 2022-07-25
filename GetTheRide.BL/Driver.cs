namespace GetTheRide.BL
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Vehicle Vehicle { get; set; } = null!;
    }
}
