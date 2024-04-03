namespace ProjectX.Storage.Repositories.Company
{
    public interface ICompanyRepository
    {
        /// <summary>
        /// Return the company with this Uid from the database
        /// </summary>
        Task<Entities.Company.Company> GetCompanyByUidAsync(Guid companyUid);

        /// <summary>
        /// Return either the company with this embs from the database or null
        /// </summary>
        Task<Entities.Company.Company?> GetCompanyByEmbsOrNullAsync(string embs);

        /// <summary>
        /// Check if a company with this embs or email exists in the database
        /// </summary>
        Task<bool> DoesCompanyExistAsync(string embs, string email);

        /// <summary>
        /// Insert this company in the database
        /// </summary>
        Task InsertCompanyAsync(Entities.Company.Company company);
    }
}
