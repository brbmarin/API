using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newWebAPI.Models;
namespace newWebAPI.Controllers;

#nullable disable

// Indique que cette classe est un controlleur d'API
[ApiController]

[Route("api/[controller]")]
public class Bookcontroller: ControllerBase
{
   // Les variables privé ont un "_" en prefix
   private readonly AppDbContext _context;

   public Bookcontroller(AppDbContext context)
   {
      _context = context;
   }

   [HttpGet]
   public async Task<IEnumerable<Book>> Get()
   {
      return await _context.Books.ToListAsync();
   }


}