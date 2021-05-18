using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using MimeKit;
using MailKit.Net.Smtp;

namespace BL
{
    public class CompanyBL : ICompanyBL
    {
        public ICompanyDL _companyDl;
        public IMailSender _mailSend;
        public ILogger<CompanyBL> _logger;
        public MyLocalSite.NotificationMetadata _notificationMetadata;
        public CompanyBL(
            ICompanyDL companyDl,  ILogger<CompanyBL> logger , MyLocalSite.NotificationMetadata noti, IMailSender mailSe
            )
        {
            _companyDl = companyDl;
            _logger = logger;
            _notificationMetadata = noti;
            _mailSend = mailSe;
        }

        private bool AmountCheckAndSend(CompanyItem c) {
            if (c.Amount > 10000)
            {
                return _mailSend.SendEmail();
            }
            return true;
        }
        public async Task<CompanyItem> AddCompany(CompanyItem company)
        {
            AmountCheckAndSend(company);
            return await _companyDl.AddCompany(company);
        }

        public async Task<CompanyItem> GetCompany(int id)
        {
            CompanyItem tmp;
            tmp = await _companyDl.GetCompany(id);
            return tmp;
        }



        public async Task<bool> CreateReposit(List<CompanyItem> companys = null)
        {
            //List<CompanyItem> tmp = new List<CompanyItem>();
            //tmp.Add(new CompanyItem() { Id = 1, Name = "Test javascript" });
            //var a = new CompanyItem() {  Name = "Test javascript" };0586744707
            //await _companyDl.AddCompany(a);
            return true;

        }

        public Task<CompanyItem> EditCompany(CompanyItem company)
        {
            AmountCheckAndSend(company);
            return _companyDl.EditCompany(company);
        }

        public async Task<List<CompanyItem>> GetAllCompanies()
        {
            return await _companyDl.GetAllCompanies();
        }

    }
}
