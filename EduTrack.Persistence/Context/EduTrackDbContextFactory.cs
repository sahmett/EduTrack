using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EduTrack.Persistence.Contexts
{
    public class EduTrackDbContextFactory : IDesignTimeDbContextFactory<EduTrackContext>
    {
        public EduTrackContext CreateDbContext(string[] args)
        {
            // Projenizin kök dizinine göre doğru yolu ayarlayın
            var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "EduTrack.API"));
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<EduTrackContext>();
            var connectionString = configuration.GetConnectionString("PostgreSQLDB");
            optionsBuilder.UseNpgsql(connectionString);

            return new EduTrackContext(optionsBuilder.Options);
        }
    }
}
