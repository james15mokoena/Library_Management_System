using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library_ms_webapi.Models
{
    /// <summary>
    /// A model for storing data about a book that have been loaned/reserved to a member
    /// of the library.
    /// </summary>
    public class ReservedBook
    {
        /// <summary>
        /// The ID of a member who borrowed the book.
        /// <br /> <br />
        /// <b>Note:</b> This property is a composite key member.
        /// </summary>
        [Column("MemberId")]
        public required string MemberId { get; set; }

        /// <summary>
        /// The Isbn of a book that a member have borrowed.
        /// <br /> <br />
        /// <b>Note:</b> This property is a composite key member.
        /// </summary>
        [Column("Isbn")]
        public required string Isbn { get; set; }

        /// <summary>
        /// The date on which a member reserved the book.
        /// </summary>
        [Column("ReservedDate")]
        [DataType(DataType.Date)]
        public required DateTime ReservedDate { get; set; }
        
        /// <summary>
        /// The date on which the book must be returned to the library.
        /// </summary>
        [Column("DueDate")]
        [DataType(DataType.Date)]
        public required DateTime DueDate{ get; set; }
    }
}