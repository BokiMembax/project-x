namespace ProjectX.Storage.Repositories.Truck
{
    public interface ITruckRepository
    {
        /// <summary>
        /// 
        /// </summary>
        Task<bool> DoesTruckExistAsync(string vin);

        Task InsertTruckAsync(Entities.Truck.Truck truck);
    }
}
