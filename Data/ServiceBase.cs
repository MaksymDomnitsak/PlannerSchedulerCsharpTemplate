using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace PlannerScheduler.Data
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : class
    {
        protected StudentScheduleContext _context { get; set; }
        public ServiceBase(StudentScheduleContext context)
        {
            _context = context;
        }
        public IQueryable<T> FindAll()
        {
            return _context.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>()
                .Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
