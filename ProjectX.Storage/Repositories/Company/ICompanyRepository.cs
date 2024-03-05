using ProjectX.Common.Company;

namespace ProjectX.Storage.Repositories.Company
{
    public interface ICompanyRepository
    {
        Task<Entities.Company.Company> GetCompanyByUidAsync(Guid companyUid);

        Task<Entities.Company.Company?> GetCompanyByEmbsOrNullAsync(string embs);

        Task<bool> DoesCompanyExistAsync(string embs, string email);

        Task InsertCompanyAsync(Entities.Company.Company company);
    }
}
