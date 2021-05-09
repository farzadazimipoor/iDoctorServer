//using System;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using AN.DAL;
//using AN.Core.Resources.EntitiesResources;

//namespace AN.Web.App_Code.Validation
//{
//    public class UniqueMobileAttributeAttribute : ValidationAttribute
//    {
//        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//        {
//            try
//            {
//                using(var db = new BanobatDbContext())
//                {
//                    var mobile = value.ToString();
//                    var count = db.Users.Count(x => x.Mobile.Equals(mobile));
//                    if (count != 0)
//                        return new ValidationResult(Messages.UserWithThisMobileExist);
//                    return ValidationResult.Success;
//                }               
//            }
//            catch (ArgumentNullException)
//            {
//                return new ValidationResult(Messages.PleaseEnterMobile);
//            }
//            catch (Exception)
//            {
//                return new ValidationResult(Messages.MobileIsNotValid);
//            }

//        }
//    }
//}