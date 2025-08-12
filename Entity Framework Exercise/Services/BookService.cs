using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services;

public class BookService
{
    private readonly LibraryDbContext _context;

    public BookService(LibraryDbContext libraryDbContext)
    {
        _context = libraryDbContext;
    }

    public async Task<Book> CreateBookAsync(Book book)
    {
        if (book.Title.Length < 1)
        {
            throw new ArgumentException("Book title is required");
        }

        var existBook = await _context.Books.FirstOrDefaultAsync(b => b.Title == book.Title);
        if (existBook != null)
        {
            throw new InvalidOperationException("Book already exist");
        }

        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return book;
    }

    public async Task<List<Book>> GetBooksByRackIdAsync(int rackId)
    {
        var booksByRackId = await _context.Books.Where(b => b.RackId == rackId).ToListAsync();
        return booksByRackId;
    }
}