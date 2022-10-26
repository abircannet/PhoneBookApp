using Microsoft.EntityFrameworkCore;

namespace Cdr.ReportMicroservice.Persistence.Postgre
{
    public class ReportDbContextSeed
    {
        public static async Task SeedAsync(ReportDbContext context, int retry = 0)
        {
            var retryForAvailability = retry;
            try
            { 
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
