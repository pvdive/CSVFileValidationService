using System.Collections.Generic;

namespace FormatValidator.Validators
{
    
    internal interface IValidator
    {
        bool IsValid(string toCheck);

        IList<ValidationError> GetErrors();

        void ClearErrors();
    }
}
