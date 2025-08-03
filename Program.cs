using LibraryEFApp.Data;
using LibraryEFApp.Models;

var context = new LibraryContext();
int choice;

do
{
    Console.Clear();
    Console.WriteLine("\n--- Library Management System ---");
    Console.WriteLine("1. List all books");
    Console.WriteLine("2. Add new book");
    Console.WriteLine("3. Update book");
    Console.WriteLine("4. Delete book");
    Console.WriteLine("0. Exit");
    Console.Write("Choice: ");
    choice = Console.ReadKey(true).KeyChar - '0';
    Console.WriteLine();

    switch (choice)
    {
        case 1:
            Console.Clear();
            ListBooks();

            Console.Write("Press any key to return to menu...");
            Console.ReadKey();
            break;
        case 2:
            Console.Clear();
            AddBook();

            Console.Write("Press any key to return to menu...");
            Console.ReadKey();
            break;
        case 3:
            Console.Clear();
            UpdateBook();

            Console.Write("Press any key to return to menu...");
            Console.ReadKey();
            break;
        case 4:
            Console.Clear();
            DeleteBook();

            Console.Write("Press any key to return to menu...");
            Console.ReadKey();
            break;
        case 0:
            Console.WriteLine("Goodbye...");
            break;
        default:
            Console.WriteLine("Invalid choice!");

            Console.Write("Press any key to selection...");
            Console.ReadKey();
            break;
    }
} while (choice != 0);

void ListBooks()
{
    var books = context.Books.ToList();
    Console.WriteLine("\n--- Book List ---");
    foreach (var book in books)
    {
        Console.WriteLine($"{book.Id}: {book.Author} - {book.Title} ({book.Year})");
    }
}

void AddBook()
{
    Console.Write("Title: ");
    String title = Console.ReadLine();

    Console.Write("Author: ");
    String author = Console.ReadLine();

    Console.Write("Year: ");
    int.TryParse(Console.ReadLine(), out int year);

    var book = new Book
    {
        Title = title,
        Author = author,
        Year = year
    };
    context.Books.Add( book );
    context.SaveChanges();
    Console.WriteLine("Book has been added");
}

void UpdateBook()
{
    ListBooks();
    Console.Write("Choose a book to update: ");
    int id = Console.ReadKey(true).KeyChar - '0';
    Console.WriteLine();

    var book = context.Books.Find(id);
    if (book == null)
    {
        Console.WriteLine("Invalid choice!");
        return;
    }

    Console.WriteLine("\n--- Update Options ---\n1: Title\n2: Author\n3: Year");
    Console.Write("Choose one to update: ");
    int option = Console.ReadKey(true).KeyChar - '0';
    Console.WriteLine();

    switch(option)
    {
        case 1:
            Console.Write("New Title: ");
            book.Title = Console.ReadLine();

            context.SaveChanges();
            Console.WriteLine("Book has been updated.");
            break;
        case 2:
            Console.Write("New Author: ");
            book.Author = Console.ReadLine();

            context.SaveChanges();
            Console.WriteLine("Book has been updated.");
            break;
        case 3:
            Console.Write("New Year: ");
            int.TryParse(Console.ReadLine(), out int year);
            book.Year = year;

            context.SaveChanges();
            Console.WriteLine("Book has been updated.");
            break;
        default:
            Console.WriteLine("Invalid choice!");
            break;
    }
}

void DeleteBook()
{
    ListBooks();
    Console.Write("Choose a book to delete: ");
    int id = Console.ReadKey(true).KeyChar - '0';
    Console.WriteLine();

    var book = context.Books.Find(id);
    if (book == null)
    {
        Console.WriteLine("Invalid choice!");
        return;
    }

    context.Books.Remove(book);
    context.SaveChanges();
    Console.WriteLine("Book has been deleted");
}