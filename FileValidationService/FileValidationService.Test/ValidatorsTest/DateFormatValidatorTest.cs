using Microsoft.VisualStudio.TestTools.UnitTesting;
using FormatValidator.Validators;

namespace FileValidationService.Test.ValidatorsTest
{
    [TestClass]
    public class DateFormatValidatorTest
    {
        private DateFormatValidator _validator;

        [TestMethod]
        [DataRow("dd/mm/yyyy","30/06/2021")]
        [DataRow("dd-mm-yyyy", "30-06-2021")]
        [DataRow("dd-MMM-yyyy", "30-JUN-2021")]
        public void DateFormatValidator_WhenDateValue_Isvalid(string DateFormat,string INPUT)
        {
            _validator = new DateFormatValidator(DateFormat);
             const bool EXPECTED_RESULT = true;

             bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }

        [TestMethod]
        [DataRow("dd/mm/yyyy", "2021/06/30")]
        [DataRow("dd-mm-yyyy", "2021-03-30")]
        [DataRow("dd-MMM-yyyy", "30-JUNE-2021")]
        public void DateFormatValidator_WhenDateValue_IsInvalid(string DateFormat, string INPUT)
        {
            _validator = new DateFormatValidator(DateFormat);
            const bool EXPECTED_RESULT = false;

            bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }

    }
}
