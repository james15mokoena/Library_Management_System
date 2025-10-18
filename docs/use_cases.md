# Identifying Uses Cases & Actors

## A. Objective

> Develop a comprehensive system for managing a single library.

---

## B. Actors

> 1. Librarian
> 2. Member
> 3. Manager

---

## C. Use Cases

### C.1 Librarian

> The system should allow a Librarian:
> 
> 1. To __manage the catalog of books__.
> 2. To __track book loans__.
> 3. To __manage member registrations__.
> 4. To __add a book to the catalog__.
> 5. To __update a book in the catalog__.
> 6. To __remove a book from the catalog__.
> 7. To __assign a book__ to a member.
> 8. To __update the availability status__ of a book.
> 9. To __manage fine payments__.
> 10. To __clear dues__ when payments are made.
> 11. To __generate reports__ on the library's __inventory__.
> 11. To __generate reports__ on available books.
> 12. To __generate reports__ on checked-out books.
> 13. To __generate reports__ on borrowed books.
> 14. To __generate reports__ on overdue books.
> 15. To __generate reports__ on fines.
> 16. To __generate usage__ statistics on most borrowed books.
> 17. To __generate usage__ statistics on popular genres.
> 18. To __generate usage__ statistics on member borrowing trends.
> 19. To __oversee check-ins__ of books.
> 20. To __oversee check-outs__ of books.
> 21. To __manage fines__.

### C.2 Member

> The system should allow a Member:
>
> 1. To __search for books__, by title, author, genre or ISBN.
> 2. To __reserve an available book__.
> 3. To __register for a library account__.
> 4. To __view their profile__.
> 5. To __update their profile__.
> 6. To __access their borrowing history__.
> 7. To __access their current loans__.

---

## D. Objects / Data

### D.1 Book

> 1. Title
> 2. Author
> 3. ISBN
> 4. Genre
> 5. Availability Status
> 6. Publication Date
> 7. Publisher
> 8. Brief Description about the book.
> 9. Quantity

### D.2 Member

> 1. First Name
> 2. Middle Name
> 3. Last Name
> 4. House Number and Street Name
> 5. Suburb or Township
> 6. City or Town
> 7. Postal Code
> 8. Province
> 9. Phone Number
> 10. Email
> 11. Membership ID
> 12. User Role
> 13. Password

### D.3 Reserved Book

> 1. Date Reserved.
> 2. Due Date.
> 3. Books ISBN
> 4. Member ID

### D.4 Librarian

> 1. First Name
> 2. Middle Name
> 3. Last Name
> 4. House Number and Street Name
> 5. Suburb or Township
> 6. City or Town
> 7. Postal Code
> 8. Province
> 9. Phone Number
> 10. Email
> 11. Staff ID
> 11. User Role

### D.5 Overdue Book

> 1. Date Reserved.
> 2. Due Date.
> 3. Books ISBN
> 4. Member ID
> 5. Fine Amount  (everyday that passes after the due date, a member gets charged at least R50 per day)
> 6. Number of days past due return.

### D.7 Borrowed Books History

> 1. Date Reserved.
> 2. Books ISBN
> 3. Member ID

### D.8 Settled Book

> 1. Date Reserved.
> 2. Due Date.
> 3. Settled Date
> 3. Books ISBN
> 4. Member ID

---