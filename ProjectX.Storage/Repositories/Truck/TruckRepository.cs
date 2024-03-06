using Microsoft.EntityFrameworkCore;
using ProjectX.Storage.Database.Context;

namespace ProjectX.Storage.Repositories.Truck
{
    public class TruckRepository : RepositoryBase, ITruckRepository
    {
        public TruckRepository(IProjectXContext projectXContext) : base(projectXContext)
        {

        }

        public async Task<bool> DoesTruckExistAsync(string vin)
        {
            return await All<Entities.Truck.Truck>().AnyAsync(x => x.Vin == vin);
        }

        public async Task InsertTruckAsync(Entities.Truck.Truck truck)
        {
            await InsertAsync(truck);
        }
    }
}
