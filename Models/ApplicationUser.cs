using Microsoft.AspNetCore.Identity;

namespace BCOAT.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}