using FormatValidator.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FileValidationService.Test.ValidatorsTest
{
    [TestClass]
    public class IntegerValidatorTest
    {
        private IntegerValidator _validator;

        [TestInitialize]
        public void Setup()
        {
            _validator = new IntegerValidator();
        }

        [TestMethod]
        [DataRow("4")]
        [DataRow("1003")]
        public void IntegerValidator_WhenValue_Isvalid(string INPUT)
        {
            const bool EXPECTED_RESULT = true;

            bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }

        [TestMethod]
        [DataRow("4.5")]
        [DataRow("1003.30")]
        [DataRow("test")]
        public void IntegerValidator_WhenValue_IsInvalid(string INPUT)
        {
            const bool EXPECTED_RESULT = false;

            bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }
    }
}
