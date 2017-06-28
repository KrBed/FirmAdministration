using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FirmAdministartion.Data.DataAccess;
using FirmAdministartion.Data.Identity;
using FirmAdministartion.Data.Identity.Config;
using FirmAdministartion.Data.Services.Abstraction;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FirmAdministartion.Data.Services
{
    public class UserRepository : IUserRepository<ApplicationUser>
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(ApplicationUser entity)
        {
            ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_context));

            ApplicationUser user = new ApplicationUser()
            {
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
            };
            string password = Convert.ToString(Guid.NewGuid());

            var createdUser = userManager.Create(user, password);

            if (createdUser == IdentityResult.Success)
            {
                _context.Users.Add(user);
            }
            _context.SaveChanges();


        }

        public void Delete(ApplicationUser entity)
        {
          var user =  _context.Users.SingleOrDefault(x => x.Id == entity.Id);
            if (user != null)
            {
                _context.Users.Remove(user);
                return;
            }
            throw new ApplicationException("User wasn't deleted, something was wrong");
        }

        public void Edit(ApplicationUser entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<ApplicationUser> FindBy(Expression<Func<ApplicationUser, bool>> predicate)
        {
           IEnumerable<ApplicationUser> users = _context.Set<ApplicationUser>().Where(predicate);
            return users;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public ApplicationUser GetSingle(string Id)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == Id);
            return user;
        }
    }
}
