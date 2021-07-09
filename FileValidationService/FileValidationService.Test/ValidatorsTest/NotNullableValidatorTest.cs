﻿using FormatValidator.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FileValidationService.Test.ValidatorsTest
{
    [TestClass]
    public class NotNullableValidatorTests
    {
        private NotNullableValidator _validator;

        [TestInitialize]
        public void Setup()
        {
            _validator = new NotNullableValidator();
        }

        [TestMethod]
        public void NotNullableValidator_WhenEmptyString_IsInvalid()
        {
            const string INPUT = "";
            const bool EXPECTED_RESULT = false;

            bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }

        [TestMethod]
        public void NotNullableValidator_WhenNullString_IsInvalid()
        {
            const string INPUT = null;
            const bool EXPECTED_RESULT = false;

            bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }

        [TestMethod]
        public void NotNullableValidator_WhenNotNull_IsValid()
        {
            const string INPUT = "pradip";
            const bool EXPECTED_RESULT = true;

            bool result = _validator.IsValid(INPUT);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }
    }
}
