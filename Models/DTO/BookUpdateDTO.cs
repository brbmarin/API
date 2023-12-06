using System.ComponentModel.DataAnnotations;

namespace newWebAPI.Models.DTOs
{
   public class BookUpdateDTO
   {
      [Required]
      public string? Title { get; set; }
      [Required]
      public string? Author { get; set; }
      [Required]
      public string? Genre { get; set; }
      [Range(0, 999)]
      public decimal Price { get; set; }
      public DateTime PublishDate { get; set; }
      public string? Description { get; set; }
      public string? Remarks { get; set; }
   }
}
