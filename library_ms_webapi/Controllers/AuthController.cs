using library_ms_webapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace library_ms_webapi.Controllers
{
    
    /// <summary>
    /// A controller that provides functionality for user authentication.
    /// </summary>
    public class AuthController(AuthService authService): ControllerBase
    {
        /// <summary>
        /// Used to handle requests for user authentication.
        /// </summary>
        private readonly AuthService service = authService;


    }

}