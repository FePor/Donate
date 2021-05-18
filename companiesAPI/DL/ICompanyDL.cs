using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace DL
{
    public interface ICompanyDL
    {
        Task<CompanyItem> AddCompany(CompanyItem company);
        Task<CompanyItem> EditCompany(CompanyItem company);
        Task<CompanyItem> GetCompany(int id);
        Task<List<CompanyItem>> GetAllCompanies();
    }
}