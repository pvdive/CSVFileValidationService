using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FormatValidator.Validators;

namespace FileValidationService.Test.ValidatorsTest
{
    [TestClass]
    public class NumberValidatorTests
    {
        private NumberValidator _validator;

        [TestInitialize]
        public void Setup()
        {
            _validator = new NumberValidator(2);
        }

        [TestMethod]
        public void NumberValidator_WhenNumeric_IsValid()
        {
            const string INPUT = "17";
            const bool EXPECTED_RESULT = true;

            bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }

        [TestMethod]
        public void NumberValidator_WhenTwoDecimalPoints_IsValid()
        {
            const string INPUT = "1234.67";
            const bool EXPECTED_RESULT = true;

            bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }

        [TestMethod]
        public void NumberValidator_WhenFourDecimalPoints_IsValid()
        {
            const string INPUT = "1234.6789";
            const bool EXPECTED_RESULT = true;
            _validator = new NumberValidator(4);
            bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }

        [TestMethod]
        public void NumberValidator_WhenNotNumeric_IsInvalid()
        {
            const string INPUT = "test";
            const bool EXPECTED_RESULT = false;

            bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }
    }
}
