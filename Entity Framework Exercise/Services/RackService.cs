using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services;

public class RackService(LibraryDbContext context)
{
    private readonly LibraryDbContext _context = context;

    public async Task<List<Rack>> GetAllRacksAsync()
    {
        var racks = await _context.Racks.ToListAsync();
        return racks;
    }
}