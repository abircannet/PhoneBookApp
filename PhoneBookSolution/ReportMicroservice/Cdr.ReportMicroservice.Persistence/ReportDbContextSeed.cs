using Microsoft.EntityFrameworkCore;

namespace Cdr.ReportMicroservice.Persistence
{
    public class ReportDbContextSeed
    {
        public static async Task SeedAsync(ReportDbContext context, int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                if (context.Database.IsSqlServer())
                {
                    context.Database.Migrate();
                }
                context.Database.Migrate();



            }
            catch (Exception)
            {

                if (retryForAvailability >= 10) throw;
                retryForAvailability++;

                await SeedAsync(context, retryForAvailability);
                throw;
            }
        }
    }
}
