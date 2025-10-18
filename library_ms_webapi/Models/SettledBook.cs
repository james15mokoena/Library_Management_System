using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library_ms_webapi.Models
{
    /// <summary>
    /// A model for storing data about a book that was once overdue but whose fine has been paid
    /// by a library member.
    /// </summary>
    public class SettledBook
    {
        /// <summary>
        /// The ID of a member who has settled the fine for holding a book longer that the set period.
        /// <br /> <br />
        /// <b>Note:</b> This property is a composite key member.
        /// </summary>
        [Column("MemberId")]
        public required string MemberId { get; set; }

        /// <summary>
        /// The Isbn of a book whose fine has been settled.
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
        public required DateTime DueDate { get; set; }
        
        /// <summary>
        /// The date on which the book's fine was settled by a member.
        /// </summary>
        [Column("SettledDate")]
        [DataType(DataType.Date)]
        public required DateTime SettledDate{ get; set; }
    }
}