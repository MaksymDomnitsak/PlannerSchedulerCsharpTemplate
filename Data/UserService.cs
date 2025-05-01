using Microsoft.EntityFrameworkCore;
using PlannerScheduler.Models;

namespace PlannerScheduler.Data
{
  public class UserService : ServiceBase<User>, IUserService
  {

    public UserService(StudentScheduleContext context) : base(context)
    {
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
      return await FindAll().ToListAsync();
    }

    public async Task<PagedList<User>> GetUsersInPage(Pageable pageable)
    {
      return await PagedList<User>.ToPagedList(_context.Users.AsQueryable(), pageable.PageNumber, pageable.PageSize);
    }

    public async Task<User> GetUserById(int id)
    {
      return await FindByCondition(user => user.Id.Equals(id)).FirstOrDefaultAsync();
    }

    public void CreateUser(User user)
    {
      Create(user);

      _context.SaveChangesAsync();
    }

    public void UpdateUser(User user)
    {
      Update(user);

      _context.SaveChangesAsync();
    }

    public void DeleteUser(User user)
    {
      Delete(user);

      _context.SaveChangesAsync();
    }

    public bool UserExists(int id)
    {
      return _context.Users.Any(e => e.Id == id);
    }
  }
}
