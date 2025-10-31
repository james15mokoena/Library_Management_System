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
        public async Task<IActionResult> RegisterLibrarian(LibrarianDto newLibrarian)
        {
            if (!string.IsNullOrEmpty(newLibrarian.StaffId) && !string.IsNullOrEmpty(newLibrarian.Role) &&
                newLibrarian.Role == "Librarian")
            {
                if (await service.RegisterUser(newLibrarian))
                    return CreatedAtAction(nameof(RegisterLibrarian), new { id = newLibrarian.StaffId });
            }

            return BadRequest("Failed to register the librarian.");
        }

        /// <summary>
        /// It is responsible for handling the request to delete a librarian's account.
        /// </summary>
        /// <param name="librarianId"></param>
        /// <returns></returns>
        [HttpDelete("{librarianId}")]
        public async Task<IActionResult> RemoveLibrarian(string librarianId)
        {
            if (!string.IsNullOrEmpty(librarianId))
            {
                bool isRemove = await service.RemoveUser(librarianId);
                return isRemove ? NoContent() : NotFound("Librarian does not exist!");
            }

            return BadRequest("Failed to remove the librarian.");
        }

        /// <summary>
        /// It is responsible for handling requests for registering a member's account.
        /// </summary>
        /// <param name="newMember"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterMember(MemberDto newMember)
        {
            if (!string.IsNullOrEmpty(newMember.MemberId) && !string.IsNullOrEmpty(newMember.Role) &&
                newMember.Role == "Member")
            {
                if (await service.RegisterUser(newMember))
                    return CreatedAtAction(nameof(RegisterMember), new { id = newMember.MemberId });
            }

            return BadRequest("Failed to register the member.");
        }

        /// <summary>
        /// It is responsible for handling the request to delete a member's account.
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [HttpDelete("{memberId}")]
        public async Task<IActionResult> RemoveMember(string memberId)
        {
            if (!string.IsNullOrEmpty(memberId))
            {
                bool isRemove = await service.RemoveUser(memberId);
                return isRemove ? NoContent() : NotFound("Member does not exist!");
            }

            return BadRequest("Failed to remove the member.");
        }
    }
}