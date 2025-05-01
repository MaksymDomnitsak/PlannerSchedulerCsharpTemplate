using PlannerScheduler.Models;

namespace PlannerScheduler.Data
{
    public interface IUserService : IServiceBase<User>
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<PagedList<User>> GetUsersInPage(Pageable pageable);
        Task<User> GetUserById(int id);
        //Task<User> GetUserWithDetails(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        bool UserExists(int id);
    }
}
