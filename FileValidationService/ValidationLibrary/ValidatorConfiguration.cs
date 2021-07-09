using System.Collections.Generic;

namespace FormatValidator
{
   
    public class ValidatorConfiguration
    {
       
        public ValidatorConfiguration()
        {
            Columns = new Dictionary<int, ColumnValidatorConfiguration>();
        }

        public string ColumnSeperator { get; set; }

        public string RowSeperator { get; set; }

        public bool HasHeaderRow { get; set; }

        public Dictionary<int, ColumnValidatorConfiguration> Columns { get; set; }
    }
}
