
namespace library_ms_webapi.DTO
{
    /// <summary>
    /// A DTO for the Member model.
    /// </summary>
    public class MemberDto : IUserDto
    {

        /// <summary>
        /// The member's unique identifier allocated upon becoming a member of the library
        /// or registering a library account.
        /// </summary>      
        public string? MemberId { get; set; } = null;

        /// <summary>
        /// The first name of the member.
        /// </summary>
        public string? FirstName { get; set; } = null;

        /// <summary>
        /// The middle name of the member.
        /// </summary>
        public string? MiddleName { get; set; } = null;

        /// <summary>
        /// The last name of the member.
        /// </summary>
        public string? LastName { get; set; } = null;

        /// <summary>
        /// The house number and street name of where the member resides. Example: <b>10 Nigel Road</b>,
        /// where "10" is the house number and "Nigel Road" is the street name.
        /// </summary>        
        public string? StreetName { get; set; } = null;

        /// <summary>
        /// The suburb or township where the member comes from. Example, <b>Westdene</b> a suburb
        /// in the city of Johannesburg.
        /// </summary>
        public string? Suburb { get; set; } = null;

        /// <summary>
        /// The city or town where the member comes from. Examples, <b>Johannesburg</b> a city in
        /// South Africa.
        /// </summary>        
        public string? City { get; set; } = null;

        /// <summary>
        /// The postal code of the suburb where the member lives or comes from. Example, <b>2092</b> for
        /// Westdene, Johannesburg.
        /// </summary>
        public int PostalCode { get; set; } = -1;

        /// <summary>
        /// The province where the member comes from, for example, Gauteng.
        /// </summary>        
        public string? Province { get; set; } = null;

        /// <summary>
        /// The phone number of the member.
        /// </summary>
        public string? PhoneNumber { get; set; } = null;

        /// <summary>
        /// The email address of the member.
        /// </summary>
        public string? Email { get; set; } = null;

        /// <summary>
        /// The password of the member.
        /// </summary>
        public string? Password { get; set; } = null;

        /// <summary>
        /// The member's role or user type in the system, which is always, "Member" type.
        /// </summary>
        public string? Role { get; set; } = "Member";
    }
}