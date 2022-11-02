using System.ComponentModel.DataAnnotations;

namespace Api_Assignment.CustomOps.CustomValidators
{
    public class ProductNameNoSpecialCharAttribute : ValidationAttribute
    {
        public override bool IsValid(object? ProductName)
        {
            string abc = (string)ProductName;
            if (abc.Contains("@") || abc.Contains("#"))
                return false;
            else
                return true;
        }
    }
}
