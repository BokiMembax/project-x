namespace ProjectX.Storage.Repositories.Truck
{
    public interface ITruckRepository
    {
        /// <summary>
        /// Return the truck with this Uid from the database
        /// </summary>
        Task<Entities.Truck.Truck> GetTruckByUidAsync(Guid truckUid);

        /// <summary>
        /// Check if a truck with this VIN exists in the database
        /// </summary>
        Task<bool> DoesTruckExistAsync(string vin);

        /// <summary>
        /// Insert this truck in the database
        /// </summary>
        Task InsertTruckAsync(Entities.Truck.Truck truck);
    }
}
