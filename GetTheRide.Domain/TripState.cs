using System.ComponentModel.DataAnnotations.Schema;

namespace GetTheRide.Domain
{
    public enum TripState
    {
        Open,
        Closed,
        Canceled
    }

    [EnumDescriber(typeof(TripState))]
    public class TripStateInfo
    {
        public int TripStateId { get; set; }
        public string State { get; set; } = null!;

        public TripStateInfo() { }
        public TripStateInfo(TripState tripState)
        {
            TripStateId = (int)tripState;
            State = tripState.ToString();
        }
    }
}