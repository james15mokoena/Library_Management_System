using library_ms_webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace library_ms_webapi.Data
{
    /// <summary>
    /// It manages the mapping of models to database tables.
    /// </summary>
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        /// <summary>
        /// Maps the Member model to a table of members.
        /// </summary>
        public DbSet<Member> Members { get; set; }
        
        /// <summary>
        /// Maps the Librarian model to a table of librarians.
        /// </summary>
        public DbSet<Librarian> Librarians { get; set; }
        
        /// <summary>
        /// Maps the Book model to a table of books.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Maps the ReservedBook model to a table of reserved books.
        /// </summary>
        public DbSet<ReservedBook> ReservedBooks { get; set; }

        /// <summary>
        /// Maps the OverdueBook model to a table of overdue books.
        /// </summary>
        public DbSet<OverdueBook> OverdueBooks { get; set; }

        /// <summary>
        /// Maps the SettledBook model to a table of settled books.
        /// </summary>
        public DbSet<SettledBook> SettledBooksBooks { get; set; }

        /// <summary>
        /// Maps the BookBorrowedHistory model to a table of once borrowed books.
        /// </summary>
        public DbSet<BookBorrowedHistory> BooksBorrowedHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // The tables below have a composite key.
            modelBuilder.Entity<ReservedBook>().HasKey(rb => new { rb.MemberId, rb.Isbn });
            modelBuilder.Entity<OverdueBook>().HasKey(rb => new { rb.MemberId, rb.Isbn });
            modelBuilder.Entity<SettledBook>().HasKey(rb => new { rb.MemberId, rb.Isbn });
            modelBuilder.Entity<BookBorrowedHistory>().HasKey(rb => new { rb.MemberId, rb.Isbn });
        }
    }
}