using Data;
using Models;
using Services;

class Program
{
    static async Task Main(string[] args)
    {
        bool isAppRunning = true;
        string userInput;
        int parsedUserInput;

        using var context = new LibraryDbContext();

        var bookService = new BookService(context);
        var rackService = new RackService(context);

        while (isAppRunning)
        {
            Console.Clear();
            Console.WriteLine("Library Console App");
            Console.WriteLine("1. Insert New Book");
            Console.WriteLine("2. Get Books by RackId");
            Console.WriteLine("3. Exit");
            Console.Write("Choose option:");

            userInput = Console.ReadLine() ?? "";
            if (int.TryParse(userInput, out parsedUserInput))
            {
                //
            }
            else
            {
                Console.WriteLine("Failed to parse");
                continue;
            }

            switch (parsedUserInput)
            {
                case 1:
                    Console.WriteLine("Insert New Book selected.");
                    await CreateNewBook();
                    break;
                case 2:
                    Console.WriteLine("Get Books By Rack");
                    await GetBooksByRackId();
                    break;
                case 3:
                    isAppRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        async Task CreateNewBook()
        {
            string title;

            Console.Write("Title: ");
            title = Console.ReadLine() ?? "";

            Book newBook = new(title);
            newBook = await bookService.CreateBookAsync(newBook);

            if (newBook != null)
            {
                Console.WriteLine("Book created successfully");
                Console.ReadLine();
            }
        }

        async Task GetBooksByRackId()
        {
            List<Rack> racks = await rackService.GetAllRacksAsync();

            Console.WriteLine("List of available racks:");
            foreach (Rack rack in racks)
            {
                Console.WriteLine($"{rack.Id}. {rack.Name}");
            }
            Console.Write("Choose Rack Id:");

            string input;
            int parsedInput;

            input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out parsedInput))
            {
                List<Book> booksByRackId = await bookService.GetBooksByRackIdAsync(parsedInput);
                foreach (Book book in booksByRackId)
                {
                    Console.WriteLine($"{book.Id}. {book.Title} [{book.Status}]");
                }
                Console.Write("Press any key to continue");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid input");
                await GetBooksByRackId();
            }
        }
    }
}