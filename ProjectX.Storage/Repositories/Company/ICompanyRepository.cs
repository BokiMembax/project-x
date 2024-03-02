using ProjectX.Common.Company;

namespace ProjectX.Storage.Repositories.Company
{
    public interface ICompanyRepository
    {
        // dali treba Task<Entities.Company.Company?>
        Task<Entities.Company.Company> GetCompanyByUidAsync(Guid companyUid);

        // dali treba Task<Entities.Company.Company?>
        Task<Entities.Company.Company?> GetCompanyByEmbsOrNullAsync(string embs);

        Task<bool> DoesCompanyExistAsync(string embs, string email);

        // Task<Entities.Company.Company?> GetCompanyByEmbsOrNullAsync(string embs);

        // Task<Entities.Company.Company?> GetCompanyByEmbsAndEmailOrNullAsync(string embs, string email);

        Task InsertCompanyAsync(Entities.Company.Company company);

        // void DeleteCompany(Entities.Company.Company company);
    }
}
