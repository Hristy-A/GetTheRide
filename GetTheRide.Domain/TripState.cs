using System.ComponentModel.DataAnnotations;
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
    public class TripStateInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TripStateInfoId { get; set; }
        public string State { get; set; } = null!;

        public TripStateInfo() { }
        public TripStateInfo(TripState tripState)
        {
            TripStateInfoId = (int)tripState;
            State = tripState.ToString();
        }
    }
}