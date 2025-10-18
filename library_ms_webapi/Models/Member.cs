using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library_ms_webapi.Models
{
    /// <summary>
    /// A model for storing a library member's data.
    /// </summary>
    public class Member
    {

        /// <summary>
        /// The member's unique identifier allocated upon becoming a member of the library
        /// or registering a library account.
        /// </summary>
        [Key]
        [Column("MemberId")]
        public required string MemberId { get; set; }

        /// <summary>
        /// The first name of the member.
        /// </summary>
        [Column("FirstName")]
        public required string FirstName { get; set; }

        /// <summary>
        /// The middle name of the member.
        /// </summary>
        [Column("MiddleName")]
        public string? MiddleName { get; set; } = " ";
        
        /// <summary>
        /// The last name of the member.
        /// </summary>
        [Column("LastName")]
        public required string LastName { get; set; }
        
        /// <summary>
        /// The house number and street name of where the member resides. Example: <b>10 Nigel Road</b>,
        /// where "10" is the house number and "Nigel Road" is the street name.
        /// </summary>
        [Column("StreetName")]
        public required string StreetName { get; set; }

        /// <summary>
        /// The suburb or township where the member comes from. Example, <b>Westdene</b> a suburb
        /// in the city of Johannesburg.
        /// </summary>
        [Column("Suburb")]
        public required string Suburb { get; set; }

        /// <summary>
        /// The city or town where the member comes from. Examples, <b>Johannesburg</b> a city in
        /// South Africa.
        /// </summary>
        [Column("City")]
        public required string City { get; set; }

        /// <summary>
        /// The postal code of the suburb where the member lives or comes from. Example, <b>2092</b> for
        /// Westdene, Johannesburg.
        /// </summary>
        [Column("PostalCode")]
        [DataType(DataType.PostalCode)]
        public int PostalCode { get; set; }

        /// <summary>
        /// The province where the member comes from, for example, Gauteng.
        /// </summary>
        [Column("Province")]
        public required string Province { get; set; }

        /// <summary>
        /// The phone number of the member.
        /// </summary>
        [Column("PhoneNumber")]
        [DataType(DataType.PhoneNumber)]
        public required string PhoneNumber { get; set; }

        /// <summary>
        /// The email address of the member.
        /// </summary>
        [Column("Email")]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        /// <summary>
        /// The password of the member.
        /// </summary>
        [Column("Password")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        /// <summary>
        /// The member's role or user type in the system, which is always, "Member" type.
        /// </summary>
        [Column("Role")]
        public required string Role { get; set; } = "Member";
    }
}