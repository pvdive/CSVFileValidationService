using Microsoft.VisualStudio.TestTools.UnitTesting;
using FormatValidator.Validators;

namespace FileValidationService.Test.ValidatorsTest
{
    [TestClass]
    public class RangeValidatorTest
    {
        private RangeValidator _validator;

        
        [TestMethod]
        [DataRow("4",1,100)]
        [DataRow("1003.6",100.5,1005.5)]
        public void RangeValidator_WhenValueInRange_Isvalid(string INPUT, double fromValue, double toValue)
        {
            _validator = new RangeValidator(fromValue, toValue);
            const bool EXPECTED_RESULT = true;

            bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }

        [TestMethod]
        [DataRow("200", 1, 100)]
        [DataRow("1013.6", 100.5, 1005.5)]
        public void RangeValidator_WhenValueInRange_IsInvalid(string INPUT, double fromValue, double toValue)
        {
            _validator = new RangeValidator(fromValue, toValue);
            const bool EXPECTED_RESULT = false;

            bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }
    }
}
