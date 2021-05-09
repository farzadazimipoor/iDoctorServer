using AWRO.Helper.UIHelper.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Models
{
    public class JGrid2BaseViewModel
    {
        [DoNotShow]
        public int Id { get; set; }

        [AwroGridWidth(Value = "60px")]
        [Display(Name = "#")]
        public int RowIndex { get; set; }

        [DoNotShow]
        public bool IsDeleted { get; set; }

        [DoNotShow]
        public int NotChangedIndex { get; set; }
    }   
}