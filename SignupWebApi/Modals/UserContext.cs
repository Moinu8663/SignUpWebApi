using Microsoft.EntityFrameworkCore;

namespace SignupWebApi.Modals
{
    public class UserContext : DbContext
    {
        public DbSet<UserModel> UserModels {get;set;}
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
    }
}
