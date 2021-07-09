using FormatValidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FileValidationService.Test
{
    [TestClass]
    public class FunctionalTests
    {
       
        const string CONFIG = @"data\configuration\testfile-configuration.json";


        [TestMethod]
        public void Functional_ValidTestDataFile()
        {
            const int EXPECTED_ERRORCOUNT = 0;
            const string FILE = @"data\ValidTestData.csv";
            Validator validator = Validator.FromJson(System.IO.File.ReadAllText(CONFIG));
            FileSourceReader source = new FileSourceReader(FILE);

            List<RowValidationError> errors = new List<RowValidationError>(validator.Validate(source));

            Assert.AreEqual(EXPECTED_ERRORCOUNT, errors.Count);
        }

        [TestMethod]
        [Description("Test for CaseValidator and RangeValidator")]
        public void Functional_InValidTestDataFile_WithTwoErrors()
        {
            const int EXPECTED_ERRORCOUNT = 2;
            const string FILE = @"data\ValidTestDataWithTwoErrors.csv";
            Validator validator = Validator.FromJson(System.IO.File.ReadAllText(CONFIG));
            FileSourceReader source = new FileSourceReader(FILE);

            List<RowValidationError> errors = new List<RowValidationError>(validator.Validate(source));

            Assert.AreEqual(EXPECTED_ERRORCOUNT, errors.Count);
        }

        [TestMethod]
        [Description("Test for All Eight validators failed")]
        public void Functional_InValidTestDataFile_WithEightErrors()
        {
            const int EXPECTED_ERRORCOUNT = 8;
            const string FILE = @"data\ValidTestDataWithEightErrors.csv";
            Validator validator = Validator.FromJson(System.IO.File.ReadAllText(CONFIG));
            FileSourceReader source = new FileSourceReader(FILE);

            List<RowValidationError> errors = new List<RowValidationError>(validator.Validate(source));

            Assert.AreEqual(EXPECTED_ERRORCOUNT, errors.Count);
        }
    }
}
