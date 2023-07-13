using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;

using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create category with valid state")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "CategoryName");
        action.Should()
        .NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create category with invalid id")]
    public void CreateCategory_WithInvalidId_DomainExceptionInvalid()
    {
        Action action = () => new Category(-1, "CategoryName");
        action.Should()
        .Throw<DomainExceptionValidation>()
        .WithMessage("Invalid id value");
    }
    
    [Fact(DisplayName = "Create category with too short name")]
    public void CreateCategory_WithTooShortName_DomainExceptionInvalid()
    {
        Action action = () => new Category(1, "Ca");
        action.Should()
        .Throw<DomainExceptionValidation>()
        .WithMessage("Invalid name, too short, minimum 3 characters is required");
    }
    
    [Fact(DisplayName = "Create category with missing name")]
    public void CreateCategory_WithMissingName_DomainExceptionInvalid()
    {
        Action action = () => new Category(1, "");
        action.Should()
        .Throw<DomainExceptionValidation>()
        .WithMessage("Invalid name.Name is required");
    }
}
}

