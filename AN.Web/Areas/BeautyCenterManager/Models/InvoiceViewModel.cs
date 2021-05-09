using AN.Core.Resources.Global;
using AN.Web.Models;
using AWRO.Helper.UIHelper.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.BeautyCenterManager.Models
{
    public class InvoiceViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "VisitDate", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string VisitDate { get; set; }      

        [Display(Name = "Description", ResourceType = typeof(Global))]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength1000")]
        public string Description { get; set; }

        public int? PatientId { get; set; }

        public int? AppointmentId { get; set; } = null;
    }

    public class InvoiceItemsGridViewModel : JGrid2BaseViewModel
    {
        [JsonProperty(PropertyName = "shiftCenterServiceId")]
        [AwroGridWidth(Value = "30%")]
        [AwroGridOrder(Value = 0)]
        [DropDownList(DataSource = "getServicesList")]
        [Display(Name = "Service", ResourceType = typeof(Global))]
        public int? ShiftCenterServiceId { get; set; }

        [JsonProperty(PropertyName = "customServiceName")]
        [AwroGridWidth(Value = "20%")]
        [AwroGridOrder(Value = 1)]
        [Display(Name = "ServiceName", ResourceType = typeof(Global))]
        public string CustomServiceName { get; set; }

        [JsonProperty(PropertyName = "price")]
        [AwroGridWidth(Value = "9%")]
        [AwroGridOrder(Value = 2)]
        [JGridRenderer(Name = "renderPriceForServicesGridView")]
        [Display(Name = "Price", ResourceType = typeof(Global))]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "note")]
        [AwroGridWidth(Value = "35%")]
        [AwroGridOrder(Value = 2)]
        [Display(Name = "Description", ResourceType = typeof(Global))]
        [MaxLength(500)]
        public string Note { get; set; }

        [JsonProperty(PropertyName = "customDelete")]
        [Display(Name = "")]
        [JGridRenderer(Name = "renderInvoiceItemCustomDelete")]
        public string CustomDelete { get; set; }
    }
}
