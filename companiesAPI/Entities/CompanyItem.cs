using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
  

    public class CompanyItem
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Amount")]
        [Required]
        public int Amount { get; set; }
        [Display(Name = "PolicyType")]
        [Required]
        public int PolicyType { get; set; }
        [Display(Name = "Details")]
        [Required]
        public string Details { get; set; }

        public string Conditions { get; set; }
        [Display(Name = "CurrencyType")]
        [Required]
        public int CurrencyType { get; set; }
        [Display(Name = "ConversionRate")]
        [Required]
        public int ConversionRate { get; set; }

    }

    public class CompaniesTotal { 
    public List<CompanyItem> Data { get; set; }
        public int Total { get; set; }

    }
}
