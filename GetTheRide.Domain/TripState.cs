using GetTheRide.Domain.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetTheRide.Domain
{
    public enum TripState
    {
        Open = 1,
        Closed,
        Canceled
    }

    [EnumDescriber(typeof(TripState))]
    [Table("trip_state")]
    public class TripStateInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string State { get; set; } = null!;

        public TripStateInfo() { }
        public TripStateInfo(TripState tripState)
        {
            Id = (int)tripState;
            State = tripState.ToString();
        }
    }
}
