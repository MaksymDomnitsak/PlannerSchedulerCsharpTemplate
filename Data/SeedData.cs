using Microsoft.EntityFrameworkCore;

namespace PlannerScheduler.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StudentScheduleContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<StudentScheduleContext>>()))
            {
                if (context.Users.Any())
                {
                    return;
                }
                context.SaveChanges();
            }
        }
    }
}
