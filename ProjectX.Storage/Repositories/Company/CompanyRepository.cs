using Microsoft.EntityFrameworkCore;
using ProjectX.Storage.Database.Context;

namespace ProjectX.Storage.Repositories.Company
{
    public class CompanyRepository : RepositoryBase, ICompanyRepository
    {
        public CompanyRepository(IProjectXContext projectXContext) : base(projectXContext)
        {

        }

        public async Task<Entities.Company.Company> GetCompanyByUidAsync(Guid companyUid)
        {
            var dbCompany = await All<Entities.Company.Company>().SingleOrDefaultAsync(x => x.Uid == companyUid);

            if (dbCompany == null)
            {
                throw new Exception($"Company with Uid {companyUid} not found.");
            }

            return dbCompany;
        }

        public async Task<Entities.Company.Company?> GetCompanyByEmbsOrNullAsync(string embs)
        {
            return await All<Entities.Company.Company>().SingleOrDefaultAsync(x => x.Embs == embs);
        }

        public async Task<bool> DoesCompanyExistAsync(string embs, string email)
        {
            return await All<Entities.Company.Company>().AnyAsync(x => x.Embs == embs || x.Email == email);
        }

        public async Task InsertCompanyAsync(Entities.Company.Company company)
        {
            await InsertAsync(company);
        }
    }
}
