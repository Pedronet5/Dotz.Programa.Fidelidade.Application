using Dotz.Programa.Fidelidade.Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmailTests
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public void Email_ValidateEmail_ShouldBeValid()
        {
            //Arrange
            var email = "admin@gmail.com";

            //Act
            var result = ValidateEmailService.EmailEValido(email);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Email_ValidateEmail_ShouldBeInValid()
        {
            //Arrange
            var email = "admin.gmail.com";

            //Act
            var result = ValidateEmailService.EmailEValido(email);

            //Assert
            Assert.IsFalse(result);
        }
    }
}