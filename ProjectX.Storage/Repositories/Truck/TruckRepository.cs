using Microsoft.EntityFrameworkCore;
using ProjectX.Storage.Database.Context;

namespace ProjectX.Storage.Repositories.Truck
{
    public class TruckRepository : RepositoryBase, ITruckRepository
    {
        public TruckRepository(IProjectXContext projectXContext) : base(projectXContext)
        {

        }

        public async Task<Entities.Truck.Truck> GetTruckByUidAsync(Guid companyUid, Guid truckUid)
        {
            var truck = await (from dbCompany in _projectXContext.Set<Entities.Company.Company>().Where(x => x.Uid == companyUid)
                                  join dbTruck in _projectXContext.Set<Entities.Truck.Truck>().Where(x => x.Uid == truckUid)
                                       on dbCompany.Id equals dbTruck.CompanyId
                                  select dbTruck).SingleOrDefaultAsync();

            if (truck == null)
            {
                throw new Exception($"Truck with Uid {truckUid} not found.");
            }

            return truck;
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
