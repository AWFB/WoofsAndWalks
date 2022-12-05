using API.Extensions;

namespace API.Models;

public class AppUser
{
    public int Id { get; set; }
    public string UserName { get; set; }

    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }

    public DateOnly DateOfBirth { get; set; }
    public string KnownAs { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime LastActive { get; set; }
    public string Gender { get; set; }
    public string Introduction { get; set; }
    public string DogBreed { get; set; }
    public string DogName { get; set; }
    public string City { get; set; }
    public string Country { get; set; }

    public List<Photo> Photos { get; set; } = new();
    
    // important that *Get* is used for automapper to map correctly
    // auto mapper needs to get the full model if left here which results in an expensive query
    // functionality moved to AutoMapperProfiles which uses the DateTimeExtension method
    
    // public int GetAge()
    // {
    //     return DateOfBirth.CalculateAge();
    // }
}