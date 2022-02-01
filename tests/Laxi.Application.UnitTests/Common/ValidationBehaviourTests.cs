using Dail.Application.Common.Exceptions;
using FluentAssertions;
using FluentValidation.Results;
using NUnit.Framework;

namespace Laxi.Application.UnitTests.Common;
internal class ValidationBehaviourTests
{
    [Test]
    public void NewException_WhenCalledWithoutArguments_ReturnEmptyArray()
    {
        //Arrange
        var result = new ValidationException();

        //Act
        var errors = result.Errors;

        //Assert
        errors.Keys.Should().BeEquivalentTo(Array.Empty<string>());
        Assert.That(errors.Count, Is.Zero);
    }

    [Test]
    public void NewException_WithValidationFailure_ReturnKeyWithMessage()
    {
        //Arrange
        var failures = new List<ValidationFailure>
        {
            new ("CredentialError", "Invalid username or password"),
        };

        //Act
        var result = new ValidationException(failures);
        var errors = result.Errors;

        //Assert
        Assert.That(errors.First(), Is.EqualTo("CredentialError"));
        Assert.IsNotNull(errors.First().Value);
        Assert.IsNotEmpty(errors.First().Value);
    }

    [Test]
    public void NewValidation_WithMultipleFailureErrors_ReturnsException()
    {
        //Arrange
        var failures = new List<ValidationFailure>
        {
            new ("FirstName", "Is required"),
            new ("LastName", "Required at least 1 characters"),
        };

        //Act
        var result = new ValidationException(failures);
        var errors = result.Errors;

        //Assert
        Assert.That(errors.Count == 2);
    }

    [Test]
    public void NewValidation_WithIdentityErrors_ReturnsException()
    {
        //Arrange
        var failures = new List<ValidationFailure>
        {
            new ("FirstName", "Is required"),
            new ("LastName", "Required at least 1 characters"),
        };

        //Act
        var result = new ValidationException(failures);
        var errors = result.Errors;

        //Assert
        Assert.That(errors.Count == 2);
    }
}