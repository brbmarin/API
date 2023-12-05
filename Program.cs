
using newWebAPI.Models;

namespace api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<AppDbContext>();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}


// using System.Linq;
// using newWebAPI.models;

// using var db = new AppDbContext();

// // Demande que la base de donnée soit créé avant l'exécution du programme 
// Console.WriteLine($"Database path: {db.DbPath}.");

// // Créer un nouveau livre
// Console.WriteLine("Insérer un nouveau libre");
// db.Add(new Book { Title = "Les Misérables"});
// //db.SaveChanges();

// // Lire le livre
// Console.WriteLine("Rechercher un livre");
// var Book = db.Books
//     .OrderBy(b => b.BookId);

// // Modifier un livre
// Console.WriteLine("Modifier un livre");
// Book.Title = "Les misérables (modifié)";