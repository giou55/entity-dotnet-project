using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace entity_dotnet_project.Models
{
    public class LikeUserViewModel
    {
        public string SelectedSender { get; set; }

        [NotEqual("SelectedSender")]
        public string SelectedRecipient { get; set; }

        [ValidateNever]
        public List<SelectListItem> UsersList { get; set; }
    }

    public class NotEqualAttribute : ValidationAttribute
    {
        private string OtherProperty { get; set; }

        public NotEqualAttribute(string otherProperty)
        {
            OtherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // get other property value
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
            var otherValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance);

            // verify values
            if (value.ToString().Equals(otherValue.ToString()))
                //return new ValidationResult(string.Format("{0} should not be equal to {1}.", validationContext.MemberName, OtherProperty));
                return new ValidationResult("sender should not be equal to recipient");
            else
                return ValidationResult.Success;
        }
    }
}