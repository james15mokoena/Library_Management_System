using library_ms_webapi.Data;
using Microsoft.AspNetCore.Mvc;

namespace library_ms_webapi.Services
{

    /// <summary>
    /// A service that provides functionality for user authentication.
    /// </summary>
    public class AuthService(AppDbContext context) : ControllerBase
    {
        /// <summary>
        /// Used to interact with the database.
        /// </summary>
        private readonly AppDbContext _database = context;

        /// <summary>
        /// It is responsible for authenticating the user before authorizing them to access
        /// further functionality and features.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        private bool Login(string username, string password, string role)
        {
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
            return Login(username, password, "Member");
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
            return Login(username, password, "Librarian");
        }        

    }

}