using System;
using System.ComponentModel.DataAnnotations;

namespace AN.BLL.Core.Appointments.InProgress
{
    public class IPAModelValidation
    {
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDateTime { get; set; }

     
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDateTime { get; set; }


       
        [Required]
        [RegularExpression("([1-9][0-9]*)")]
        public int ServiceSupplyId { get; set; }

    }   
}
