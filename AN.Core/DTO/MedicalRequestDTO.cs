using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace AN.Core.DTO
{
    public class MedicalRequestBaseFormDTO
    {
        public DateTime Date { get; set; } = DateTime.Now;

        public string Note { get; set; }

        public int CountryId { get; set; }
    }

    public class MedicalRequestDTO : MedicalRequestBaseFormDTO
    { 
        public List<IFormFile> Files { get; set; }
    }
}
