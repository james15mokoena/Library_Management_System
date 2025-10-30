using library_ms_webapi.Data;
using library_ms_webapi.DTO;
using library_ms_webapi.Models;

namespace library_ms_webapi.Services
{
    /// <summary>
    /// It provides the functionality for managing users.
    /// </summary>
    public class UserService(AppDbContext context)
    {

        /// <summary>
        /// Will be used to interact with the data.
        /// </summary>
        private readonly AppDbContext database = context;

        /// <summary>
        /// It is responsible for registering a librarian.
        /// </summary>
        /// <param name="newLibrarian"></param>
        /// <returns></returns>
        public async Task<bool> RegisterLibrarian(LibrarianDto newLibrarian)
        {                
            return await RegisterUser(newLibrarian);
        }

        /// <summary>
        /// It is responsible for registering a student who is registered at the school
        /// and wants to have a library account also.
        /// </summary>
        /// <param name="newMember"></param>
        /// <returns></returns>
        public async Task<bool> RegisterMember(MemberDto newMember)
        {
            return await RegisterMember(newMember);
        }

        /// <summary>
        /// It is responsible for creating a user's account.
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        private async Task<bool> RegisterUser(IUserDto newUser)
        {
            if (IsDataValid(newUser))
            {
                if (newUser is LibrarianDto)
                {
                    LibrarianDto lib = (newUser as LibrarianDto)!;

                    Librarian newLib = new()
                    {
                        StaffId = lib.StaffId!,
                        City = lib.City!,
                        Email = lib.Email!,
                        FirstName = lib.FirstName!,
                        MiddleName = lib.MiddleName!,
                        LastName = lib.LastName!,
                        Password = lib.Password!,
                        PhoneNumber = lib.PhoneNumber!,
                        Province = lib.Province!,
                        Role = lib.Role!,
                        StreetName = lib.StreetName!,
                        Suburb = lib.Suburb!,
                        PostalCode = lib.PostalCode
                    };

                    await database.Librarians.AddAsync(newLib);
                }
                else if (newUser is MemberDto)
                {
                    MemberDto mem = (newUser as MemberDto)!;

                    Member newMem = new()
                    {
                        MemberId = mem.MemberId!,
                        City = mem.City!,
                        Email = mem.Email!,
                        FirstName = mem.FirstName!,
                        MiddleName = mem.MiddleName!,
                        LastName = mem.LastName!,
                        Password = mem.Password!,
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
        /// It is responsible for removing a librarian's account.
        /// </summary>
        /// <param name="librarian"></param>
        /// <returns></returns>
        public bool RemoveLibrarian(LibrarianDto librarian)
        {
            return false;
        }

        /// <summary>
        /// It is responsible for removing a member's account.
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public bool RemoveMember(MemberDto member)
        {
            return false;
        }

        /// <summary>
        /// It is responsible for removing the specified user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private bool RemoveUser(IUserDto user)
        {
            return false;
        }
    }
}