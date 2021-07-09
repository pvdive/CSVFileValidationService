using System;

namespace FormatValidator.Validators
{
    public class NumberValidator : ValidationEntry
    {
        private int DecimalPlaces = 0;

        public NumberValidator(int _decimalPlaces)
        {
            DecimalPlaces = _decimalPlaces;
        }
        public override bool IsValid(string toCheck)
        {
            double parsed = 0;
            bool isValid = double.TryParse(toCheck, out parsed) && DecimalPlaces >= GetDecimalPlaces(parsed);

            if (!isValid)
            {
                base.Errors.Add(new ValidationError(0, string.Format("'{0}' is not a valid number upto '{1}' decimal places.", toCheck, DecimalPlaces)));
            }

            return isValid;
        }

        //Considered . as a decimal pointer
        private static int GetDecimalPlaces(double n)
        {
            string number = Convert.ToString(n);
            var decimalPlaces = number.Substring(number.IndexOf(".") + 1).Length;
            return decimalPlaces;
        }
    }
}
