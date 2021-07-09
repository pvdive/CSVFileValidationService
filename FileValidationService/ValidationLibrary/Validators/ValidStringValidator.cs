using System;
using System.Collections.Generic;
using System.Linq;

namespace FormatValidator.Validators
{

    public class ValidStringValidator : ValidationEntry
    {
        private List<string> _validValues;

        public ValidStringValidator(List<string> lstValidValues)
        {
            _validValues = lstValidValues;
        }

        public override bool IsValid(string toCheck)
        {
            bool isValid = true;


            if (!_validValues.Any(s => s.Equals(toCheck, StringComparison.Ordinal)))
            {
                base.Errors.Add(new ValidationError(0, string.Format("invalid value '{0}' found.", toCheck)));
                isValid = false;
            }


            return isValid;
        }

    }
}
