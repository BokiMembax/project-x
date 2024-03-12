namespace ProjectX.Storage.Repositories.Trailer
{
    public interface ITrailerRepository
    {
        Task<bool> DoesTrailerExistAsync(string vin);

        Task InsertTrailerAsync(Entities.Trailer.Trailer trailer);
    }
}
