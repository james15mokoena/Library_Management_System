using library_ms_webapi.DTO;
using library_ms_webapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace library_ms_webapi.Controllers
{
    /// <summary>
    /// It is responsible for handling HTTP requests that are concerned with user management.
    /// </summary>
    /// <param name="uService"></param>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController(UserService uService) : ControllerBase
    {
        /// <summary>
        /// Will be used to interact with the database.
        /// </summary>
        private readonly UserService service = uService;

        /// <summary>
        /// It is responsible for handling requests for registering a librarian's account.
        /// </summary>
        /// <param name="newLibrarian"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterLibrarian([FromBody] LibrarianDto newLibrarian)
        {
            if (!string.IsNullOrEmpty(newLibrarian.StaffId))
            {
                if (await service.RegisterLibrarian(newLibrarian))
                    return CreatedAtAction(nameof(RegisterLibrarian), new { id = newLibrarian.StaffId });
            }

            return BadRequest("Failed to register the librarian.");
        }
    }
}