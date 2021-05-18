using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DL
{
    public class CompanyDL : ICompanyDL
    {
        CompanyContext _mySiteDBContext;
        public CompanyDL(CompanyContext mySiteDBContext)
        {
            _mySiteDBContext = mySiteDBContext;
        }
     

        public async Task<CompanyItem> AddCompany(CompanyItem company)
        {
            _mySiteDBContext.CompanyItems.Add(company);
            await _mySiteDBContext.SaveChangesAsync();
            return company;
        }

        public async Task<CompanyItem> GetCompany(int id)
        {
            return await _mySiteDBContext.CompanyItems.FindAsync(id);

        }

        public Task<CompanyItem> EditCompany(CompanyItem company)
        {
            _mySiteDBContext.Update(company);
            _mySiteDBContext.SaveChangesAsync();
            return _mySiteDBContext.CompanyItems.FindAsync(company.Id).AsTask();
        }

        public Task<List<CompanyItem>> GetAllCompanies()
        {
            return  _mySiteDBContext.CompanyItems.ToListAsync();
        }
    }
}
