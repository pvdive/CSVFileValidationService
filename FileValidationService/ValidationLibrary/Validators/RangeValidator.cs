namespace FormatValidator.Validators
{
    public class RangeValidator : ValidationEntry
    {
        private double _fromValue;
        private double _toValue;
        public RangeValidator(double fromValue,double toValue)
        {
            _fromValue = fromValue;
            _toValue = toValue;
        }

        public override bool IsValid(string toCheck)
        {
            double parsed = 0;
            bool isValid = double.TryParse(toCheck, out parsed) && parsed >= _fromValue && parsed <= _toValue;

            if (!isValid)
            {
                base.Errors.Add(new ValidationError(0, string.Format("'{0}' is not in given range of '{1} to {2}'", toCheck, _fromValue, _toValue)));
            }

            return isValid;
        }
    }
}
