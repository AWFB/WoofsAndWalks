using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("Photos")] // tells EF what to call the table
public class Photo
{
    public int Id { get; set; }
    public string Url { get; set; }
    public bool IsMain { get; set; }
    public string PublicId { get; set; }
    
    // fully define relationship between user and photos 
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}