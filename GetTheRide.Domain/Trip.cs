using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTheRide.Domain
{
    public class Trip
    {
        public int Id { get; set; }
        public int AvailableSeats { get; set; }
        public TripState State { get; set; }

        public virtual User Driver { get; set; } = null!;
        public virtual ICollection<User>? Passengers { get; set; }
    }
}
