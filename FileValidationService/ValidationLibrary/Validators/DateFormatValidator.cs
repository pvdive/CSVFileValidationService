using System;
using System.Globalization;

namespace FormatValidator.Validators
{
    public class DateFormatValidator : ValidationEntry
    {
        private string _dateFormat;

        public DateFormatValidator(string dateFormat)
        {
            _dateFormat = dateFormat;
        }

        public override bool IsValid(string toCheck)
        {
            DateTime dt;
            bool isValid = DateTime.TryParseExact(toCheck, _dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
            if (!isValid)
            {
                base.Errors.Add(new ValidationError(0, string.Format("String '{0}' is not in correct date with format {1}.", toCheck, _dateFormat)));
            }
            return isValid;
        }
    }
}
