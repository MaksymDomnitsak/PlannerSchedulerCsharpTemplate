using PlannerScheduler.Models;

namespace PlannerScheduler.Data;

public interface IGeneralOperationsService<T>
{
  Task<IEnumerable<T>> GetObjects();
  Task<PagedList<T>> GetObjects(Pageable pageable);
  Task DeleteObject(int id);
}

