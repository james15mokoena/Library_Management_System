using library_ms_webapi.Data;
using library_ms_webapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace library_ms_webapi.Services
{

    /// <summary>
    /// A service that provides functionality for user authentication.
    /// </summary>
    public class AuthService(AppDbContext context, UserService userService, PasswordService passwordService)
    {
        /// <summary>
        /// Used to interact with the database.
        /// </summary>
        private readonly AppDbContext _database = context;

        /// <summary>
        /// Used to interact with the user service.
        /// </summary>
        private readonly UserService _userService = userService;

        /// <summary>
        /// Will be used to verify user passwords during login.
        /// </summary>
        private readonly PasswordService _passwordService = passwordService;

        /// <summary>
        /// It is responsible for authenticating the user before authorizing them to access
        /// further functionality and features.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool Login(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                object? user = _userService.UserExists(username);

                if (user is not Librarian lib)
                {
                    if (user is Member member)
                        return _passwordService.VerifyPassword(password, member.Password);
                }
                else
                    return _passwordService.VerifyPassword(password, lib.Password);
            }
            
            // user does not exist or parameters are null or empty.
            return false;
        }

        /// <summary>
        /// It is responsible for authenticating "members" specifically so that we don't waste
        /// time querying the librarians table when the user is a "Member".
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool LoginFromMobile(string username, string password)
        {
            return Login(username, password);
        }

        /// <summary>
        /// It is responsible for authenticating "librarians" specifically so that we don't waste
        /// time querying the members table when the user is a "Librarian".
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool LoginFromWeb(string username, string password)
        {
            return Login(username, password);
        }        

    }

}