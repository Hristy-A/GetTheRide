using AutoMapper;
using GetTheRide.BL;
using GetTheRide.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GetTheRide.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DriversController : ControllerBase, IUserController<Driver>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<TripsController> _logger;
        private readonly GetTheRideDbContext _dbContext;

        public DriversController(
            ILogger<TripsController> logger,
            IMapper mapper,
            GetTheRideDbContext dbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Driver user)
        {
            try
            {
                var dbUser = _mapper.Map<Domain.User>(user);
                await _dbContext.Users.AddAsync(dbUser);
                await _dbContext.SaveChangesAsync();

                //var createdUser = await _dbContext.Users.FirstOrDefault(x=>x.)
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int userId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAsync([FromRoute] int userId)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateAsync([FromBody] Driver user)
        {
            throw new NotImplementedException();
        }
    }
}
