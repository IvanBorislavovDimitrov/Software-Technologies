using BookLibraryFinal.Controllers;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BookLibraryFinal.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<BookLibraryFinal.Controllers.Book> Books { get; set; }
    }
}