using Microsoft.VisualStudio.TestTools.UnitTesting;
using FormatValidator.Validators;
using System.Collections.Generic;

namespace FileValidationService.Test.ValidatorsTest
{
    [TestClass]
    public class ValidStringValidatorTest
    {
        private ValidStringValidator _validator;

        [TestInitialize]
        public void Setup()
        {
            List<string> lstValidValues = new List<string>() { "test1", "test2", "test3"};
            _validator = new ValidStringValidator(lstValidValues);
        }

        [TestMethod]
        [DataRow("test1")]
        [DataRow("test2")]
        public void ValidStringValidator_WhenValue_Isvalid(string INPUT)
        {
            const bool EXPECTED_RESULT = true;

            bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }

        [TestMethod]
        [DataRow("test4")]
        [DataRow("pradip")]
        public void ValidStringValidator_WhenValue_IsInvalid(string INPUT)
        {
            const bool EXPECTED_RESULT = false;

            bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }
    }
}
