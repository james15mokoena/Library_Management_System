using library_ms_webapi.Data;
using library_ms_webapi.DTO;
using library_ms_webapi.Models;

namespace library_ms_webapi.Services
{
    /// <summary>
    /// It provides the functionality for managing users.
    /// </summary>
    public class UserService(AppDbContext context, PasswordService passwordService)
    {

        /// <summary>
        /// Will be used to interact with the data.
        /// </summary>
        private readonly AppDbContext database = context; 

        /// <summary>
        /// Will be used to hash user password during registration.
        /// </summary>
        private readonly PasswordService _passwordService = passwordService;     

        /// <summary>
        /// It is responsible for creating a user's account.
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public async Task<bool> RegisterUser(IUserDto newUser)
        {
            if (IsDataValid(newUser))
            {
                
                if (newUser is LibrarianDto lib)
                {
                    lib = (newUser as LibrarianDto)!;

                    // does a user with the same ID/username already exist?
                    if (!IsUsernameUnique(lib.StaffId!))
                        return false;

                    Librarian newLib = new()
                    {
                        StaffId = lib.StaffId!,
                        City = lib.City!,
                        Email = lib.Email!,
                        FirstName = lib.FirstName!,
                        MiddleName = lib.MiddleName!,
                        LastName = lib.LastName!,
                        Password = _passwordService.GeneratePasswordHash(lib.Password!),
                        PhoneNumber = lib.PhoneNumber!,
                        Province = lib.Province!,
                        Role = lib.Role!,
                        StreetName = lib.StreetName!,
                        Suburb = lib.Suburb!,
                        PostalCode = lib.PostalCode
                    };

                    await database.Librarians.AddAsync(newLib);
                }
                else if (newUser is MemberDto mem)
                {
                    mem = (newUser as MemberDto)!;

                    // does a user with the same ID/username already exist?
                    if (!IsUsernameUnique(mem.MemberId!))
                        return false;

                    Member newMem = new()
                    {
                        MemberId = mem.MemberId!,
                        City = mem.City!,
                        Email = mem.Email!,
                        FirstName = mem.FirstName!,
                        MiddleName = mem.MiddleName!,
                        LastName = mem.LastName!,
                        Password = _passwordService.GeneratePasswordHash(mem.Password!),
                        PhoneNumber = mem.PhoneNumber!,
                        Province = mem.Province!,
                        Role = mem.Role!,
                        StreetName = mem.StreetName!,
                        Suburb = mem.Suburb!,
                        PostalCode = mem.PostalCode
                    };

                    await database.Members.AddAsync(newMem);
                }
                
                return await database.SaveChangesAsync() > 0;
            }

            return false;
        }

        /// <summary>
        /// It is responsible for checking the properties of a Member or LIbrarian to ensure that
        /// they are not set to unacceptable values.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static bool IsDataValid(IUserDto data)
        {            
            if (data != null && data is LibrarianDto)
            {
                return !string.IsNullOrEmpty((data as LibrarianDto)!.StaffId) &&
                       !string.IsNullOrEmpty((data as LibrarianDto)!.FirstName) &&
                       !string.IsNullOrEmpty((data as LibrarianDto)!.LastName) &&
                       !string.IsNullOrEmpty((data as LibrarianDto)!.StreetName) &&
                       !string.IsNullOrEmpty((data as LibrarianDto)!.Suburb) &&
                       !string.IsNullOrEmpty((data as LibrarianDto)!.City) &&
                       !string.IsNullOrEmpty((data as LibrarianDto)!.Province) &&
                       !string.IsNullOrEmpty((data as LibrarianDto)!.PhoneNumber) &&
                       !string.IsNullOrEmpty((data as LibrarianDto)!.Email) &&
                       !string.IsNullOrEmpty((data as LibrarianDto)!.Password) &&
                       !string.IsNullOrEmpty((data as LibrarianDto)!.Role) &&
                       (data as LibrarianDto)!.PostalCode > 0;                
            }
            else if(data != null && data is MemberDto)
            {
                return !string.IsNullOrEmpty((data as MemberDto)!.MemberId) &&
                       !string.IsNullOrEmpty((data as MemberDto)!.FirstName) &&
                       !string.IsNullOrEmpty((data as MemberDto)!.LastName) &&
                       !string.IsNullOrEmpty((data as MemberDto)!.StreetName) &&
                       !string.IsNullOrEmpty((data as MemberDto)!.Suburb) &&
                       !string.IsNullOrEmpty((data as MemberDto)!.City) &&
                       !string.IsNullOrEmpty((data as MemberDto)!.Province) &&
                       !string.IsNullOrEmpty((data as MemberDto)!.PhoneNumber) &&
                       !string.IsNullOrEmpty((data as MemberDto)!.Email) &&
                       !string.IsNullOrEmpty((data as MemberDto)!.Password) &&
                       !string.IsNullOrEmpty((data as MemberDto)!.Role) &&
                       (data as MemberDto)!.PostalCode > 0;
            }

            return false;
        }        

        /// <summary>
        /// It is responsible for removing the specified user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> RemoveUser(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                // is it a librarian to be removed?
                if (UserExists(userId) is not Librarian lib)
                {
                    // is it a Member (that is, a student)?
                    if (UserExists(userId) is Member member)
                    {
                        database.Members.Remove(member);
                        return await database.SaveChangesAsync() > 0;
                    }
                }
                else
                {
                    database.Librarians.Remove(lib);
                    return await database.SaveChangesAsync() > 0;
                }                        
            }

            // its neither Librarian nor Member, meaning the user does not exist.
            return false;
        }

        /// <summary>
        /// Checks if a user with the given user ID exists, either as Member or Librarian.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public object? UserExists(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                // is it a librarian's ID?
                Librarian? lib = database.Librarians.FirstOrDefault(l => l.StaffId == userId);

                if (lib == null)
                {
                    // is it a member's ID?
                    Member? member = database.Members.FirstOrDefault(m => m.MemberId == userId);

                    if (member != null)
                        return member;
                }
                else
                    return lib;
            }

            // no user exists with that ID.
            return null;
        }
        
        /// <summary>
        /// Checks if there's a user who already has the same ID/username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private bool IsUsernameUnique(string username)
        {            
            return UserExists(username) == null;
        }
    }
}