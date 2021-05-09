using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using AN.Core.Resources.EntitiesResources;

namespace AN.Web.App_Code.Validation
{
    public class ValidVersionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var pattern = @"\d+\.\d+\.\d+";
                var regEx = new Regex(pattern, RegexOptions.IgnoreCase);

                var version = value.ToString();
                var versionMatch = regEx.IsMatch(version);
                if (!versionMatch)
                {
                    return new ValidationResult(Messages.VersionPatternIsNotValid);
                }
                return ValidationResult.Success;
            }
            catch (Exception)
            {
                return new ValidationResult(Messages.ErrorOccuredWhenCheckVersionPattern);
            }

        }
    }
}