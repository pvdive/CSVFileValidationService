using Microsoft.VisualStudio.TestTools.UnitTesting;
using FormatValidator.Validators;

namespace FileValidationService.Test.ValidatorsTest
{
    [TestClass]
    public class BooleanValueValidatorTest
    {
        private BooleanValueValidator _validator;

        [TestInitialize]
        public void Setup()
        {
            _validator = new BooleanValueValidator();
        }

        [TestMethod]
        public void BooleanValueValidator_WhenBooleanValue_Isvalid()
        {
            const string INPUT = "true";
            const bool EXPECTED_RESULT = true;

            bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }

        [TestMethod]
        public void BooleanValueValidator_WhenBooleanValue_IsInvalid()
        {
            const string INPUT = "test";
            const bool EXPECTED_RESULT = false;

            bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }
    }
}
