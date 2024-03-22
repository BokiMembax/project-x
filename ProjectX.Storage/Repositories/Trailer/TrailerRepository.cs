using Microsoft.EntityFrameworkCore;
using ProjectX.Storage.Database.Context;

namespace ProjectX.Storage.Repositories.Trailer
{
    public class TrailerRepository : RepositoryBase, ITrailerRepository
    {
        public TrailerRepository(IProjectXContext projectXContext) : base(projectXContext)
        {

        }

        public async Task<Entities.Trailer.Trailer> GetTrailerByUidAsync(Guid companyUid, Guid trailerUid)
        {
            var trailer = await (from dbCompany in _projectXContext.Set<Entities.Company.Company>().Where(x => x.Uid == companyUid)
                                    join dbTrailer in _projectXContext.Set<Entities.Trailer.Trailer>().Where(x => x.Uid == trailerUid)
                                         on dbCompany.Id equals dbTrailer.CompanyId
                                    select dbTrailer).SingleOrDefaultAsync();

            if (trailer == null)
            {
                throw new Exception($"Trailer with Uid {trailerUid} not found.");
            }

            return trailer;
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
