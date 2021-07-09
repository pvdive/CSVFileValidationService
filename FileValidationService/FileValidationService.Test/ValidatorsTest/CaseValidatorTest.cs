using Microsoft.VisualStudio.TestTools.UnitTesting;
using FormatValidator.Validators;

namespace FileValidationService.Test.ValidatorsTest
{
    [TestClass]
    public class CaseValidatorTest
    {
        private CaseValidator _validator;

        [TestMethod]
        public void CaseValidator_WhenUppercaseValue_Isvalid()
        {
            _validator = new CaseValidator("upper");
            const string INPUT = "PRADIP";
            const bool EXPECTED_RESULT = true;

            bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }

        [TestMethod]
        public void CaseValidator_WhenUppecaseValue_IsInvalid()
        {
            _validator = new CaseValidator("upper");
            const string INPUT = "PRADip";
            const bool EXPECTED_RESULT = false;

            bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }

        [TestMethod]
        public void CaseValidator_WhenLowercaseValue_Isvalid()
        {
            _validator = new CaseValidator("lower");
            const string INPUT = "pradip";
            const bool EXPECTED_RESULT = true;

            bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }

        [TestMethod]
        public void CaseValidator_WhenLowercaseValue_IsInvalid()
        {
            _validator = new CaseValidator("lower");
            const string INPUT = "pradipIp";
            const bool EXPECTED_RESULT = false;

            bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }
    }
}
