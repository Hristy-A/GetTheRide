using AutoMapper;
using GetTheRide.BL;
using GetTheRide.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GetTheRide.Api.Controllers
{
    /*
- /trips
get: Get all Trips
  params: state=TripState
post: Create new Trip
- /{id}
  post: Assign/remove a passenger to/from the Trip
  delete: Cancel Trip

- /drivers
post: Create driver's account
put: Edit driver's account
delete: Delete driver's account
- /{id}
  get: Get driver's account info

- /passengers
post: Create passenger's account
put: Edit passenger's account
delete: Delete passenger's account
- /{id}
  get: Get passenger's account info
   */

    [ApiController]
    [Route("api/v1/[controller]")]
    public class TripController : ControllerBase, ITripController
    {
        private readonly IMapper _mapper;
        private readonly ILogger<TripController> _logger;
        private readonly GetTheRideDbContext _dbContext;

        public TripController(
            ILogger<TripController> logger,
            IMapper mapper,
            GetTheRideDbContext dbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get all trips in given state.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] Domain.TripState state)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create trip.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Trip trip)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cancel trip.
        /// </summary>
        [HttpDelete("{tripId}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int tripId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Assign/remove passenger to/from the trip.
        /// </summary>
        [HttpPost("{tripId}")]
        public async Task<IActionResult> ManagePassengerAsync([FromRoute] int tripId, [FromBody] Passenger passenger, [FromQuery] bool assign)
        {
            if (assign)
                return await AddPassenger(tripId, passenger);
            else
                return await RemovePassenger(tripId, passenger);
        }

        private async Task<IActionResult> AddPassenger(int tripId, Passenger passenger)
        {
            throw new NotImplementedException();
        }

        private async Task<IActionResult> RemovePassenger(int tripId, Passenger passenger)
        {
            throw new NotImplementedException();
        }
    }
}
