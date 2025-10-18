using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library_ms_webapi.Models
{
    
    /// <summary>
    /// A model for storing a book's data.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// A book's ISBN which also serves a unique identifier for the book.
        /// </summary>
        [Key]
        [Column("Isbn")]
        public required string Isbn { get; set; }
        
        /// <summary>
        /// The name of the author.
        /// </summary>
        [Column("Author")]
        public required string Author { get; set; }
        
        /// <summary>
        /// The genre of the book.
        /// </summary>
        [Column("Genre")]
        public required string Genre { get; set; }

        /// <summary>
        /// The date on which the book was published.
        /// </summary>
        [Column("PublishedDate")]
        [DataType(DataType.Date)]
        public required DateTime PublishedDate { get; set; }
        
        /// <summary>
        /// The publisher of the book.
        /// </summary>
        [Column("Publisher")]
        public required string Publisher { get; set; }

        /// <summary>
        /// A brief description about the book.
        /// </summary>
        [Column("Description")]
        [MaxLength(256)]
        public required string Description { get; set; }

        /// <summary>
        /// Indicates whether a copy of this book is still available.
        /// </summary>
        [Column("IsAvailable")]
        public required bool IsAvailable { get; set; }
        
        /// <summary>
        /// The number of available copies of the book.
        /// </summary>
        [Column("Quantity")]
        public required int Quantity{ get; set; }
    }
}