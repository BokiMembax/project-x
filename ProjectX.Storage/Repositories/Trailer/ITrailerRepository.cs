namespace ProjectX.Storage.Repositories.Trailer
{
    public interface ITrailerRepository
    {
        /// <summary>
        /// Return the trailer with this Uid from the database
        /// </summary>
        Task<Entities.Trailer.Trailer> GetTrailerByUidAsync(Guid companyUid, Guid trailerUid);

        /// <summary>
        /// Check if a trailer with this VIN exists in the database
        /// </summary>
        Task<bool> DoesTrailerExistAsync(string vin);

        /// <summary>
        /// Insert this trailer in the database
        /// </summary>
        Task InsertTrailerAsync(Entities.Trailer.Trailer trailer);
    }
}
