using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newWebAPI.Models;
namespace newWebAPI.Controllers;

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

   // Mauvaise Pratique
   public async Task<IEnumerable<Book>> Get()
   {
      return await _context.Books.ToListAsync();
   }

   // GET: api/Book/[id]
   [HttpGet("{id}", Name = nameof(GetBook))]
   public async Task<ActionResult<Book>> GetBook(int id)
   {
      var book = await _context.Books.FindAsync(id);
      if (book == null)
      {
         return NotFound();
      }
      return book;
   }

   // POST: api/Book
   // BODY: Book (JSON)
   [HttpPost]
   [ProducesResponseType(201, Type = typeof(Book))]
   [ProducesResponseType(400)]
   public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
   {
      // we check if the parameter is null
      if (book == null)
      {
         return BadRequest();
      }
      // we check if the book already exists
      Book? addedBook = await _context.Books.FirstOrDefaultAsync(b => b.Title == book.Title);
      if (addedBook != null)
      {
         return BadRequest("Book already exists");
      }
      else
      {
         // we add the book to the database
         await _context.Books.AddAsync(book);
         await _context.SaveChangesAsync();

         // we return the book
         return CreatedAtRoute(
            routeName: nameof(GetBook),
            routeValues: new { id = book.Id },
            value: book);

      }
   }
}