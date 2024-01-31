using Microsoft.EntityFrameworkCore;
using PaginationSampleNet8.Model.Users;
using PaginationSampleNet8.Model.Cars;

namespace PaginationSampleNet8.Domain.Data
{
    public class WebApiDbContext: DbContext
    {

        public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars => Set<Car>();
        public DbSet<User> Users => Set<User>();

    }
}
