namespace FormatValidator.Validators
{
   public class IntegerValidator : ValidationEntry
    {
        public override bool IsValid(string toCheck)
        {
            int parsed = 0;
            bool isValid =  int.TryParse(toCheck, out parsed);

            if (!isValid)
            {
                base.Errors.Add(new ValidationError(0, string.Format("'{0}' is not a integer.", toCheck)));
            }

            return isValid;
        }
    }
}
