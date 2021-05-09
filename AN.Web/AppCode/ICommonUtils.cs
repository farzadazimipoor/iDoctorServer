using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AN.Web.App_Code
{
    public interface ICommonUtils
    {
        IEnumerable<SelectListItem> PopulateProvincesList();

        IEnumerable<SelectListItem> PopulateCitiesList();

        IEnumerable<SelectListItem> PopulateExpertiseCategoriesList();

        IEnumerable<SelectListItem> PopulateExpertisesList();

        IEnumerable<SelectListItem> PopulateExpertisesList(int categoryId);

        IEnumerable<SelectListItem> PopulateServiceSuppliesList(int policlinicId);

        IEnumerable<SelectListItem> PopulateDaysOfWeekList();

        IEnumerable<SelectListItem> PopulateDaysOfWeekListForUsualPlan();

        IEnumerable<SelectListItem> PopulatePrerequisiteTypes();

        IEnumerable<SelectListItem> PopulateAppointmentStatuses();

        IEnumerable<SelectListItem> PopulatePaymentStatuses();

        IEnumerable<SelectListItem> PopulateReservationRangeStartPoints();

        IEnumerable<SelectListItem> PopulateReservationRangeEndPoints();
    }
}
