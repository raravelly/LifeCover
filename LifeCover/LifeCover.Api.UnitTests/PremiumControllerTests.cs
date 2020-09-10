using FluentValidation;
using LifeCover.Api.Controllers;
using LifeCover.Api.Models;
using LifeCover.Api.Validators;
using LifeCover.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace LifeCover.Api.UnitTests
{
    [TestFixture]
    public class PremiumControllerTests
    {
        private PremiumController sut;
        private IPremiumCalculationService service;
        private IValidator<LifePremiumModel> validator;

        [SetUp]
        public void SetUp()
        {
            service = Substitute.For<IPremiumCalculationService>();
            validator = Substitute.For<IValidator<LifePremiumModel>>();
            sut = new PremiumController(service, validator);
        }

        [Test]
        public void Should_Return_Bad_Request()
        {
            // Arrange
            
            validator.Validate(Arg.Any<LifePremiumModel>()).Returns(new LifePremiumModelValidator().Validate(new LifePremiumModel()));

            // Act
            var actionResult = sut.CalculatePremium(new LifePremiumModel());

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsInstanceOf<BadRequestObjectResult>(actionResult.Result);
        }
    }
}
