
namespace library_ms_webapi.DTO
{
    /// <summary>
    /// A DTO for the Librarian model.
    /// </summary>
    public class LibrarianDto : IUserDto
    {
        /// <summary>
        /// The librarian's unique identifier which is their staff ID..
        /// </summary>
        public string? StaffId { get; set; } = null;

        /// <summary>
        /// The first name of the librarian.
        /// </summary>
        public string? FirstName { get; set; } = null;

        /// <summary>
        /// The middle name of the librarian.
        /// </summary>
        public string? MiddleName { get; set; } = null;

        /// <summary>
        /// The last name of the librarian.
        /// </summary>
        public string? LastName { get; set; } = null;

        /// <summary>
        /// The house number and street name of where the librarian resides. Example: <b>10 Nigel Road</b>,
        /// where "10" is the house number and "Nigel Road" is the street name.
        /// </summary>
        public string? StreetName { get; set; } = null;

        /// <summary>
        /// The suburb or township where the librarian comes from. Example, <b>Westdene</b> a suburb
        /// in the city of Johannesburg.
        /// </summary>
        public string? Suburb { get; set; } = null;

        /// <summary>
        /// The city or town where the librarian comes from. Examples, <b>Johannesburg</b> a city in
        /// South Africa.
        /// </summary>
        public string? City { get; set; } = null;

        /// <summary>
        /// The postal code of the suburb where the librarian lives or comes from. Example, <b>2092</b> for
        /// Westdene, Johannesburg.
        /// </summary>
        public int PostalCode { get; set; } = -1;

        /// <summary>
        /// The province where the librarian comes from, for example, Gauteng.
        /// </summary>
        public string? Province { get; set; } = null;

        /// <summary>
        /// The phone number of the librarian.
        /// </summary>
        public string? PhoneNumber { get; set; } = null;

        /// <summary>
        /// The email address of the librarian.
        /// </summary>
        public string? Email { get; set; } = null;

        /// <summary>
        /// The password of the librarian.
        /// </summary>
        public string? Password { get; set; } = null;

        /// <summary>
        /// The librarian's role or user type in the system, which is always, "Librarian" type.
        /// </summary>
        public string? Role { get; set; } = "Librarian";
    }
}