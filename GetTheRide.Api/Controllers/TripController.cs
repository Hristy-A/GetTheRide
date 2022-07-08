using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GetTheRide.BL;

namespace GetTheRide.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly ILogger<TripController> _logger;

        public TripController(ILogger<TripController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;

            
            // For single entity
            //_mapper.Map<Trip>(object)

            // For colelctions
            //_mapper.ProjectTo<Trip>(collection)
        }

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
                    VehicleId = 1,
                    Vehicle = new Domain.Vehicle()
                    {
                        Id = 1,
                        Seats = 4,
                        Name = "car",
                        UserId = 1
                    }
                },
            };

            var trip = _mapper.Map<Trip>(dbTrip);
            return new List<Trip>() { trip };
        }
    }
}