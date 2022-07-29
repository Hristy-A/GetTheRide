using GetTheRide.BL;
using Microsoft.AspNetCore.Mvc;

namespace GetTheRide.Api.Controllers
{
    public interface ITripController
    {
        Task<IActionResult> GetAsync(Domain.TripState state);
        Task<IActionResult> CreateAsync(Trip trip);
        Task<IActionResult> DeleteAsync(int tripId);
        Task<IActionResult> ManagePassengerAsync(int tripId, Passenger passenger, bool assign);
    }
}
