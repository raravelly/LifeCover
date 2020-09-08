using System;
using FluentAssertions;
using LifeCover.Api.Models;
using LifeCover.Api.Validators;
using NUnit.Framework;

namespace LifeCover.Api.UnitTests
{
    public class LifePremiumModelValidatorTests
    {
        private LifePremiumModelValidator sut;

        [SetUp]
        public void Setup()
        {
            sut = new LifePremiumModelValidator();
        }

        [Test]
        public void Should_Return_Validation_Errors()
        {
            // Act

            var result = sut.Validate(new LifePremiumModel());
            // Assert
            result.Should().NotBeNull();
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == nameof(LifePremiumModel.Occupation));
            result.Errors.Should().Contain(x => x.PropertyName == nameof(LifePremiumModel.Name));
            result.Errors.Should().Contain(x => x.PropertyName == nameof(LifePremiumModel.SumInsured));
            result.Errors.Should().Contain(x => x.PropertyName == nameof(LifePremiumModel.DateOfBirth));
        }

        [Test]
        public void Should_Pass_Validation()
        {
            // Arrange
            var model = new LifePremiumModel
            {
                DateOfBirth = DateTime.Now,
                Name = "some name",
                Occupation = "Doctor",
                SumInsured = 1
            };

            // Act
            var result = sut.Validate(model);
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }
    }
}