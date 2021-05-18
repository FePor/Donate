using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace BL
{
    public interface ICompanyBL
    {
        Task<CompanyItem> AddCompany(CompanyItem Company);
        Task<CompanyItem> EditCompany(CompanyItem Company);
        Task<CompanyItem> GetCompany(int id);
        Task<List<CompanyItem>> GetAllCompanies();
        Task<bool> CreateReposit(List<CompanyItem> Companys =null);
    }
}