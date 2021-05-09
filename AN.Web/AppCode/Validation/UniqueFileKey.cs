using AN.Core.Enums;
using AN.Core.Resources.EntitiesResources;
using AN.DAL;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AN.Web.App_Code.Validation
{
    public class UniqueFileKeyAttribute : ValidationAttribute
    {
        private readonly BanobatDbContext _dbContext;
        public UniqueFileKeyAttribute(BanobatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var key = (ResourceKey)value;
                var count = _dbContext.Resources.Count(x => x.Key == key);
                if (count != 0)
                    return new ValidationResult(Messages.FileExistWithThisKey);
                return ValidationResult.Success;
            }
            catch (ArgumentNullException)
            {
                return new ValidationResult(Messages.PleaseEnterFileKey);
            }
            catch (Exception)
            {
                return new ValidationResult("Unknown Error occured");
            }
        }
    }
}