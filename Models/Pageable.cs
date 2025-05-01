
namespace PlannerScheduler.Models
{
	public class Pageable
	{
		const int maxPageSize = 50;
		public int PageNumber { get; set; } = 1; // can to rewrite without standard values
		
		private int _pageSize = 10;
		public int PageSize
		{
			get
			{
				return _pageSize;
			}
			set
			{
				_pageSize = (value > maxPageSize) ? maxPageSize : value;
			}
		}
	}
}