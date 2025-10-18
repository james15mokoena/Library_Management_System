using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library_ms_webapi.Models
{
    /// <summary>
    /// A model for storing books that a member once borrowed from the library.
    /// </summary>
    public class BookBorrowedHistory
    {
        /// <summary>
        /// The ID of the member who borrowed the book.
        /// </summary>
        [Column("MemberId")]
        public required string MemberId { get; set; }
        
        /// <summary>
        /// The Isbn of the book that a member once borrowed.
        /// </summary>
        [Column("Isbn")]
        public required string Isbn { get; set; }

        /// <summary>
        /// The date on which a member reserved the book.
        /// </summary>
        [Column("ReservedDate")]
        [DataType(DataType.Date)]
        public required DateTime ReservedDate { get; set; }
        
    }
}