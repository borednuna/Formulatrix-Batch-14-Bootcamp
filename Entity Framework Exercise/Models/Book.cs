using System.ComponentModel.DataAnnotations;
using Enums;

namespace Models;

public class Book
{
    public Book(string title)
    {
        Title = title;
        Status = Status.AVAILABLE;
    }

    public int Id { get; set; }
    [MaxLength(100)]
    public string Title { get; set; }
    public Status Status { get; set; }
    public DateTime? DeletedAt { get; set; }
    public int? RackId { get; set; }
    public virtual Rack Rack { get; set; } = null!;
}