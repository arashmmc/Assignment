using System.Threading.Tasks;

namespace DotNetEngineerAssignment.Application.SeedWork
{
    public interface ISeedDatabaseService
    {
        Task<string> Do();
    }
}
