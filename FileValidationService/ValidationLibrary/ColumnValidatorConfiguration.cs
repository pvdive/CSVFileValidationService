using System.Collections.Generic;

namespace FormatValidator
{
    public class ColumnValidatorConfiguration
    {
        public string Name { get; set; }

        public string StringCase { get; set; }

        public string DateFormat { get; set; }

        public bool IsNumeric { get; set; }

        public int DecimalPlaces { get; set; }

        public bool IsInterger { get; set; }

        public bool IsRequired { get; set; }

        public bool IsBoolean { get; set; }

        public NumberRange NumberRange { get; set; }

        public List<string> ValidValues { get; set; }
    }

    public class NumberRange
    {
        public double From { get; set; }
        public double To { get; set; }
    }
}
