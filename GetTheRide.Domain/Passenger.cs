using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTheRide.Domain
{
    public class Passenger
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public int UserId { get; set; }

        public Trip Trip { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
