namespace AN.Web.Areas.Public.Models
{

    public class ActionsResultModel
    {
        public string ReturnedData { get; set; }

        public string Result { get; set; }
                
        public string Message { get; set; }        
    }


    public enum MyIActionResult
    {
        Success,
        Failure
    }
}