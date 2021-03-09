using System.Threading.Tasks;

namespace FoJo.Business.Services.Abstractions
{
    public interface IDBMigrator
    {
        Task ExecuteAsync();
    }
}