namespace ProjectX.Storage.Repositories.Truck
{
    public interface ITruckRepository
    {
        Task<bool> DoesTruckExistAsync(string vin);

        Task InsertTruckAsync(Entities.Truck.Truck truck);
    }
}
