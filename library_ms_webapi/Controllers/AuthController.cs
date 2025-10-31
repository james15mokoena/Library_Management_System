using library_ms_webapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace library_ms_webapi.Controllers
{

    /// <summary>
    /// A controller that provides functionality for user authentication.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController(AuthService authService) : ControllerBase
    {
        /// <summary>
        /// Used to handle requests for user authentication.
        /// </summary>
        private readonly AuthService service = authService;

        /// <summary>
        /// It is responsible for authenticating a user before giving them access to the system.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                return service.Login(username, password) ? Ok("Successfully logged in!") : NotFound("Login failed!");

            return BadRequest("Request failed.");
        }

    }

}