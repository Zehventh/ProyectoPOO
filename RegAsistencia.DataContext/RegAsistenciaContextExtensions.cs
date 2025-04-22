using Microsoft.EntityFrameworkCore; 
using Microsoft.Extensions.DependencyInjection; 

namespace RegAsistencia.EntityModels;

public static class RegAsistenciaContextExtensions
{
  /// <summary>
  /// Adds RegAsistenciaContext to the specified IServiceCollection. Uses the Sqlite database provider.
  /// </summary>
  /// <param name="services">The service collection.</param>
  /// <param name="relativePath">Default is ".."</param>
  /// <param name="databaseName">Default is "RegAsistencia.db"</param>
  /// <returns>An IServiceCollection that can be used to add more services.</returns>
  public static IServiceCollection AddRegAsistenciaContext(
    this IServiceCollection services, 
    string relativePath = "..",
    string databaseName = "RegAsistencia.db")
  {
    string path = Path.Combine(relativePath, databaseName);
    path = Path.GetFullPath(path);
    RegAsistenciaContextLogger.WriteLine($"Database path: {path}");

    if (!File.Exists(path))
    {
      throw new FileNotFoundException(
        message: $"{path} not found.", fileName: path);
    }

    services.AddDbContext<RegAsistenciaContext>(options =>
    {

      options.UseSqlite($"Data Source={path}");

      options.LogTo(RegAsistenciaContextLogger.WriteLine,
        new[] { Microsoft.EntityFrameworkCore
          .Diagnostics.RelationalEventId.CommandExecuting });
    },

    contextLifetime: ServiceLifetime.Transient,   
    optionsLifetime: ServiceLifetime.Transient);

    return services;
  }
}