using Microsoft.EntityFrameworkCore;
namespace newWebAPI.Models;
 
public class AppDbContext : DbContext
{  
   // Chemin de connection
   private const string ConnectionString=@"Server=localhost;Database=BookDb;Trusted_Connection=True;";
 
   public string DbPath { get; }
   public AppDbContext()
   {
      DbPath="DbBooks.db";
   }

   // Configuration du chemin
   protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
   {
      optionBuilder.UseSqlite($"Data Source = {DbPath}");
   }

   public DbSet<Book> Books { get; set; }   
}