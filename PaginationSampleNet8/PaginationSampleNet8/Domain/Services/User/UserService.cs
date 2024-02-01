using Bogus;
using Microsoft.EntityFrameworkCore;
using PaginationSampleNet8.Domain.Helper.Cache;
using PaginationSampleNet8.Domain.Data;
using PaginationSampleNet8.Model.Users;

namespace PaginationSampleNet8.Repository.Users
{
    public class UserService
    {
        protected readonly WebApiDbContext _webApiDbContext;
        protected readonly CacheHelper _userCache;
        private const string CacheUserGetAllKey = "CacheUserGetAllKey";
        public UserService(WebApiDbContext webApiDbContext, CacheHelper userCache)
        {
            _webApiDbContext = webApiDbContext;
            _userCache = userCache;
        }

        public void GenerateSampleData()
        {
            DbSet<User> dbSet = _webApiDbContext.Set<User>();
            if (dbSet.Any())
            {
                dbSet.RemoveRange(dbSet.ToList());
                _webApiDbContext.SaveChanges();
            }

            int userId = 0;
            var fakeCars = new Faker<User>()
                .RuleFor(c => c.Id, f => ++userId)
                .RuleFor(c => c.FirstName, f => "FirstName_" + userId)
                .RuleFor(c => c.LastName, f => "LastName_" + userId)
                .RuleFor(c => c.Age, f => ++userId)
                .RuleFor(c => c.Phone, f => "Phone_" + userId)
                .RuleFor(c => c.Email, f => "Email_" + userId);

            var data = fakeCars.Generate(5000).AsQueryable();
            _webApiDbContext.Users.AddRange(data);
            _webApiDbContext.SaveChanges();

        }

        public IQueryable<User> Get(User user)
        {
            return _webApiDbContext.Users.Where(x => x.Id == user.Id).AsQueryable();

        }

        public IQueryable<User> GetAll()
        {
            IQueryable<User>? users = _userCache.GetValue<IQueryable<User>?>(CacheUserGetAllKey);

            if (users == null) {
                users = _webApiDbContext.Users.AsQueryable();
                _userCache.SetValue<IQueryable<User>?>(CacheUserGetAllKey, users);
            }
            return users;
        }
        public void Insert(User user)
        {
            _webApiDbContext.Users.Add(user);
            _webApiDbContext.SaveChanges();
        }

        public void Delete(User user)
        {
            _webApiDbContext.Users.Remove(user);
            _webApiDbContext.SaveChanges();

        }
    }
}
