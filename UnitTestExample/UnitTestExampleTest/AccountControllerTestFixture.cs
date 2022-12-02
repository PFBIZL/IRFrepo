using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExampleTest
{
    public class AccountControllerTestFixture
    {
        [
            Test,
            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-corvinus.hu", false),
            TestCase("irf@uni-corvinus.hu", true),

        ]
        public void TestValidateEmail(string email, bool expectedResult)
        {

            // Arrange
            var accountController = new AccountController();
            // Act
            var actualResult = accountController.ValidateEmail(email);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [
             Test,
             TestCase("Abcdefgh", false),
             TestCase("ABCDEFGH1", false),
             TestCase("abcdefgh1", false),
             TestCase("Abc1", false),
             TestCase("Abcdefgh1", true)
        ]
        public void PasswordValidation(string password, bool expectedResult)
        {
            var accountController = new AccountController();
            var actualResult = accountController.ValidatePassword(password);
            Assert.AreEqual(expectedResult, actualResult);

        }




    }
}
