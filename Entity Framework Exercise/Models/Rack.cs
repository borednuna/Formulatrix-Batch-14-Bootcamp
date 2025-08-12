namespace Models;

public class Rack
{
    public int Id { get; set; }
    public string Name { get; set; }
    public static string BookSlot { get; set; }
    public DateTime? DeletedAt { get; set; }
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}