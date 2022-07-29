using Microsoft.AspNetCore.Mvc;

namespace GetTheRide.Api.Controllers
{
    public interface IUserController<T>
    {
        Task<IActionResult> GetAsync(int userId);
        Task<IActionResult> CreateAsync(T user);
        Task<IActionResult> UpdateAsync(T user);
        Task<IActionResult> DeleteAsync(int userId);
    }
}
