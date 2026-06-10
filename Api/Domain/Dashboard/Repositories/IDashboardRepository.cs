using Api.Domain.Dashboard.Entities;
using Api.Domain.Dashboard.ValueObjects;

namespace Api.Domain.Dashboard.Repositories
{
    public interface IDashboardRepository
    {
        Task<Dashboard?> GetByIdAsync(DashboardId id);
        Task<IEnumerable<Dashboard>> GetAllAsync();
        Task<Dashboard> AddAsync(Dashboard dashboard);
        Task<Dashboard> UpdateAsync(Dashboard dashboard);
        Task DeleteAsync(DashboardId id);
    }
}
