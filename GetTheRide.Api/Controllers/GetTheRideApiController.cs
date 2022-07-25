using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trip = GetTheRide.BL.Trip;

namespace GetTheRide.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetTheRideApiController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly ILogger<GetTheRideApiController> _logger;

        public GetTheRideApiController(ILogger<GetTheRideApiController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;

#if DEBUG
            _logger.Log(LogLevel.Debug, "Dependencies successful injected");
#endif

            // For single entity
            //_mapper.Map<Trip>(object)

            // For colelctions
            //_mapper.ProjectTo<Trip>(collection)
        }

        //[HttpPost]
        //public ActionResult<Driver> AddDriver(Driver driver, GetTheRideDbContext context)
        //{
        //    // if login exists checking

        //    var user = _mapper.Map<User>(driver);

        //    context.Users.Add(_mapper.Map<User>(driver));
        //}

        [HttpGet(Name = "GetTrips")]
        public IEnumerable<Trip> Get()
        {
            var dbTrip = new Domain.Trip()
            {
                Id = 1,
                AvailableSeats = 4,
                State = Domain.TripState.Open,
                Driver = new Domain.User()
                {
                    Id = 1,
                    FirstName = "a",
                    LastName = "b",
                    Vehicle = new Domain.Vehicle()
                    {
                        Id = 1,
                        Seats = 4,
                        Name = "car",
                    }
                },
            };

            var trip = _mapper.Map<Trip>(dbTrip);
            return new List<Trip>() { trip };
        }
    }
}
