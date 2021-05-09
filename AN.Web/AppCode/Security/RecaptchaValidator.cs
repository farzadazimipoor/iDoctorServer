//using System;
//using System.IO;
//using System.Net;
//using System.Web.Configuration;
//using System.Web.Script.Serialization;

//namespace AN.Web.App_Code.Security
//{
//    public class RecaptchaValidator
//    {
//        public static bool Check(string response)
//        {
//            //string Response = HttpContext.Current.Request.QueryString["g-recaptcha-response"];//Getting Response String Append to Post Method
//            var Valid = false;
//            //Request to Google Server
//            var req = (HttpWebRequest)WebRequest.Create(" https://www.google.com/recaptcha/api/siteverify?secret=" + WebConfigurationManager.AppSettings["RecaptchaSecretKey"] + "&response=" + response);
//            try
//            {
//                //Google recaptcha Response
//                using (var wResponse = req.GetResponse())
//                {

//                    using (var readStream = new StreamReader(wResponse.GetResponseStream()))
//                    {
//                        var jsonResponse = readStream.ReadToEnd();

//                        var js = new JavaScriptSerializer();
//                        var data = js.Deserialize<MyObject>(jsonResponse);// Deserialize Json

//                        Valid = Convert.ToBoolean(data.success);
//                    }
//                }

//                return Valid;
//            }
//            catch (WebException ex)
//            {
//                throw ex;
//            }
//        }
//    }

//    public class MyObject
//    {
//        public string success { get; set; }
//    }

//}