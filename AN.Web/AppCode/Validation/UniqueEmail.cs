//using AN.Core.Resources.EntitiesResources;
//using AN.DAL;
//using System;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;

//namespace AN.Web.App_Code.Validation
//{
//    public class UniqueEmailAttribute : ValidationAttribute
//    {
//        private readonly BanobatDbContext _dbContext;
//        public UniqueEmailAttribute(BanobatDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//        {
//            try
//            {
//                var email = value.ToString();
//                var count = _dbContext.Users.Where(x => x.Email.Trim() == email.Trim()).ToList().Count();
//                if (count != 0)
//                    return new ValidationResult(Messages.UserWithThisEmailExistBefore);
//                return ValidationResult.Success;
//            }
//            catch (ArgumentNullException)
//            {
//                return new ValidationResult(Messages.PleaseEnterEmail);
//            }
//            catch (Exception)
//            {
//                return new ValidationResult(Messages.EmailIsNotValid);
//            }

//        }
//    }

//}