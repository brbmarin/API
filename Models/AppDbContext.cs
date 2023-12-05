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
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      var currentDir = Directory.GetCurrentDirectory();
      var dbPath = Path.Combine(currentDir, "Books.db");
      Console.WriteLine($"using db at {dbPath}");
      optionsBuilder.UseSqlite($"Filename={dbPath}");
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.Entity<Book>().HasData(
         new Book
         {
            Id = 1,
            Title = "Professional C# 6 and .NET Core 1.0",
            Author = "Christian Nagel",
            Description = "A true masterclass in C# and .NET programming",
            Genre = "Software",
            Price = 50,
            PublishDate = new DateTime(2016, 05, 09)
         },
         new Book
         {
            Id = 2,
            Title = "Professional C# 7 and .NET Core 2.0",
            Author = "Christian Nagel",
            Description = "A true masterclass in C# and .NET programming",
            Genre = "Software",
            Price = 50,
            PublishDate = new DateTime(2018, 04, 18)
         },
         new Book
         {
            Id = 3,
            Title = "Professional C# 8 and .NET Core 3.0",
            Author = "Christian Nagel",
            Description = "A true masterclass in C# and .NET programming",
            Genre = "Software",
            Price = 50,
            PublishDate = new DateTime(2019, 10, 30)
         },
         new Book
         {
            Id = 4,
            Title = "Professional C# 9 and .NET 5",
            Author = "Christian Nagel",
            Description = "A true masterclass in C# and .NET programming",
            Genre = "Software",
            Price = 50,
            PublishDate = new DateTime(2021, 01, 01)
         },
         new Book
         {
            Id = 5,
            Title = "Beginning Visual C# 2019",
            Author = "Perkins, Reid, and Hammer",
            Description = "The perfect guide to Visual C#",
            Genre = "Software",
            Price = 45,
            PublishDate = new DateTime(2020, 09, 23)
         },
         new Book
         {
            Id = 6,
            Title = "Pro C# 7",
            Author = "Andrew Troelsen",
            Description = "The ultimate C# resource",
            Genre = "Software",
            Price = 50,
            PublishDate = new DateTime(2017, 10, 01)
         }
      );
   }
   public DbSet<Book> Books { get; set; }   
}