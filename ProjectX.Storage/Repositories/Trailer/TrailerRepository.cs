using Microsoft.EntityFrameworkCore;
using ProjectX.Storage.Database.Context;

namespace ProjectX.Storage.Repositories.Trailer
{
    public class TrailerRepository : RepositoryBase, ITrailerRepository
    {
        public TrailerRepository(IProjectXContext projectXContext) : base(projectXContext)
        {

        }

        public async Task<bool> DoesTrailerExistAsync(string vin)
        {
            return await All<Entities.Trailer.Trailer>().AnyAsync(x => x.Vin == vin);
        }

        public async Task InsertTrailerAsync(Entities.Trailer.Trailer trailer)
        {
            await InsertAsync(trailer);
        }
    }
}
