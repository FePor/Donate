using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyLocalSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase

    {
        ICompanyBL _companyBL;


        public CompanyController(ICompanyBL repository)
        {
            _companyBL = repository;
           // _companyBL.CreateReposit();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyItem>> Get(int id)
        {
            return await _companyBL.GetCompany(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyItem>>> Get()
        {
            return await _companyBL.GetAllCompanies();
            /* var companies = _companyBL.GetAllCompanies().Result;
                var list=   _ordersBL.GetAllCompanys().GetAwaiter().GetResult();
                limit = limit == 0 ? list.Count : limit;
                filterData = filterData == null ? "" : filterData;
                var result = list.AsEnumerable().Where(a=>a.Name.Contains(filterData) || a.Details.Contains(filterData)).Skip(offset).Take(limit).ToList();
                return new CompanyListTotal { Data=result, Total= list.Count } ;
            return Ok(companies);*/
        }

        [HttpPost]
        public async Task<ActionResult<CompanyItem>> Post([FromBody] CompanyItem company)
        {
            return await _companyBL.AddCompany(company);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyItem>> Put([FromBody] CompanyItem company)
        {
            return await _companyBL.EditCompany(company);
        }




    }
}
