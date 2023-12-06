namespace newWebAPI.Models;

public class BaseModel 
{
   public DateTime CreadtedAt { get; set; }
   public DateTime UpdatedAt { get; set; }
   public DateTime DeletedAt { get; set; }
   public string CreateBy { get; set; } = String.Empty;
   public string UpdateBy { get; set; } = String.Empty;
}