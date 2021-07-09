using System.Linq;

namespace FormatValidator.Validators
{
    public class CaseValidator : ValidationEntry
    {
        private string _stringCase;
        public CaseValidator(string caseFormat)
        {
            _stringCase = caseFormat;
        }

        public override bool IsValid(string toCheck)
        {
            bool isValid = false;
            if (_stringCase.ToLower() == "upper")
            {
                isValid = !string.IsNullOrWhiteSpace(toCheck) && toCheck.All(char.IsLetter) && toCheck.All(char.IsUpper);
            }
            if (_stringCase.ToLower() == "lower")
            {
                isValid = !string.IsNullOrWhiteSpace(toCheck) && toCheck.All(char.IsLetter) && toCheck.All(char.IsLower);
            }
            if (!isValid)
            {
                base.Errors.Add(new ValidationError(0, string.Format("String '{0}' is not in {1} case.", toCheck, _stringCase)));
            }
            return isValid;
        }
    }
}
