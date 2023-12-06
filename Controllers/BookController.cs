using System.Net;
using AutoMapper;
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
      // On vérifie si les paramètres sont vide
      if (book == null)
      {
         return BadRequest();
      }

      // On vérifie si le livre existe déjà
      Book addedBook = await _context.Books.FirstOrDefaultAsync(b => b.Title == book.Title);
      
      if (addedBook != null)
      {
         return BadRequest("Book already exists");
      }
      else
      {
         // On ajoute le livre à la base de donnée
         await _context.Books.AddAsync(book);
         await _context.SaveChangesAsync();

         // On retourne le livre
         return CreatedAtRoute(
            routeName: nameof(GetBook),
            routeValues: new { id = book.Id },
            value: book);
      }
   }

   // PUT: api/Book/[id]
   [HttpPut("{id}")]
   public async Task<ActionResult<Book>> PutBook(int id, [FromBody] BookUpdate updatedBook)
   {
      if (updatedBook == null)
      {
         return BadRequest("Invalid book data");
      }
 
      var existingBook = await _context.Books.FindAsync(id);
 
      if (existingBook == null)
      {
         return NotFound("Book not found");
      }
 
      existingBook.Price = updatedBook.Price;
      existingBook.Description = updatedBook.Description;
      existingBook.Remarks = updatedBook.Remarks;
 
      try
      {
         await _context.SaveChangesAsync();
         return Ok(existingBook);
      }
      catch (DbUpdateConcurrencyException)
      {
         return StatusCode(500, "Concurrency conflict occurred");
      }
   }

   // DELETE: api/Book/[id]
   [HttpDelete("{id}")]
   public async Task<IActionResult> DeleteBook(int id)
   {
      var book = await _context.Books.FindAsync(id);
      if (book == null)
      {
         return NotFound();
      }

      _context.Books.Remove(book);
      await _context.SaveChangesAsync();

      return NoContent();
   }

   // TODO: utilisez des annotations pour valider les donnees entrantes avec ModelState

   // TODO: utilisez le package AutoMapper pour mapper les donnees de BookUpdateDTO vers Book
   private readonly IMapper _mapper;
   public Bookcontroller(IMapper mapper) => _mapper = mapper;
}

public class BookUpdate
{
   public decimal Price { get; internal set; }
   public string Description { get; internal set; }
   public string Remarks { get; internal set; }
}



