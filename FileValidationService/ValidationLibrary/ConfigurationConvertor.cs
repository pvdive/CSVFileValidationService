using System.Collections.Generic;
using FormatValidator.Validators;

namespace FormatValidator
{

    internal class ConfigurationConvertor
    {
        private ConvertedValidators _converted;
        private ValidatorConfiguration _fromConfig;

        public ConfigurationConvertor(ValidatorConfiguration fromConfig)
        {
            _fromConfig = fromConfig;
            _converted = new ConvertedValidators();
        }

        public ConvertedValidators Convert()
        {
            _converted = new ConvertedValidators();

            ConvertProperties();
            ConvertColumns();

            return _converted;
        }

        private void ConvertProperties()
        {
            _converted.RowSeperator = UnescapeString(_fromConfig.RowSeperator);
            _converted.ColumnSeperator = UnescapeString(_fromConfig.ColumnSeperator);
            _converted.HasHeaderRow = _fromConfig.HasHeaderRow;
        }

        private void ConvertColumns()
        {
            if (ConfigHasColumns())
            {
                foreach (KeyValuePair<int, ColumnValidatorConfiguration> columnConfig in _fromConfig.Columns)
                {
                    List<IValidator> group = new List<IValidator>();

                    if (!string.IsNullOrWhiteSpace(columnConfig.Value.StringCase)) group.Add(new CaseValidator(columnConfig.Value.StringCase));
                    if (columnConfig.Value.NumberRange != null && columnConfig.Value.NumberRange.From<= columnConfig.Value.NumberRange.To) group.Add(new RangeValidator(columnConfig.Value.NumberRange.From, columnConfig.Value.NumberRange.To));
                    if (!string.IsNullOrWhiteSpace(columnConfig.Value.DateFormat)) group.Add(new DateFormatValidator(columnConfig.Value.DateFormat));
                    if (columnConfig.Value.IsNumeric && columnConfig.Value.DecimalPlaces>0) group.Add(new NumberValidator(columnConfig.Value.DecimalPlaces));
                    if (columnConfig.Value.IsInterger) group.Add(new IntegerValidator());
                    if (columnConfig.Value.IsRequired) group.Add(new NotNullableValidator());
                    if (columnConfig.Value.IsBoolean) group.Add(new BooleanValueValidator());
                    if (columnConfig.Value.ValidValues!= null && columnConfig.Value.ValidValues.Count>0) group.Add(new ValidStringValidator(columnConfig.Value.ValidValues));

                    _converted.Columns.Add(columnConfig.Key, group);
                }
            }
        }

        private string UnescapeString(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            return System.Text.RegularExpressions.Regex.Unescape(input);
        }

        private bool ConfigHasColumns()
        {
            return _fromConfig.Columns != null && _fromConfig.Columns.Count > 0;
        }
    }
}
