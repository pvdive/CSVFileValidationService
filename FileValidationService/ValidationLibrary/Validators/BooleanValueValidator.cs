namespace FormatValidator.Validators
{
    public class BooleanValueValidator : ValidationEntry
    {
        public override bool IsValid(string toCheck)
        {
            bool parsed ;
            bool isValid = bool.TryParse(toCheck, out parsed);

            if (!isValid)
            {
                base.Errors.Add(new ValidationError(0, string.Format("'{0}' is not a boolean value.", toCheck)));
            }

            return isValid;
        }
    }
}
