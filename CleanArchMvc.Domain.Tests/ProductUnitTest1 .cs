using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;

using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
public class ProductUnitTest1
{
    [Fact(DisplayName = "Create product with valid state")]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Name", "Description", 3.10m, 5, "image");
        action.Should()
        .NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create product with invalid id")]
    public void CreateProcuct_WithInvalidId_DomainExceptionInvalid()
    {
        Action action = () => new Product(-1, "Name", "Description", 3.10m, 5, "image");
        action.Should()
        .Throw<DomainExceptionValidation>()
        .WithMessage("Invalid id value");
    }
    
    [Fact(DisplayName = "Create Procuct with too short name")]
    public void CreateProcuct_WithTooShortName_DomainExceptionInvalid()
    {
        Action action = () => new Product(1, "Na", "Description", 3.10m, 5, "image");
        action.Should()
        .Throw<DomainExceptionValidation>()
        .WithMessage("Invalid name. Minimum characters is 3");
    }
    
    [Fact(DisplayName = "Create Procuct with missing description")]
    public void CreateProcuct_WithMissingDescription_DomainExceptionInvalid()
    {
        Action action = () => new Product(1, "Name", "", 3.10m, 5, "image");
        action.Should()
        .Throw<DomainExceptionValidation>()
        .WithMessage("Invalid description. Description is required");
    }

    [Fact(DisplayName = "Create Procuct with invalid price")]
    public void CreateProcuct_WithInvalidPrice_DomainExceptionInvalid()
    {
        Action action = () => new Product(1, "Name", "Description", -1m, 5, "image");
        action.Should()
        .Throw<DomainExceptionValidation>()
        .WithMessage("Invalid price value.");
    }

    [Fact(DisplayName = "Create Procuct with invalid stock")]
    public void CreateProcuct_WithInvalidStock_DomainExceptionInvalid()
    {
        Action action = () => new Product(1, "Name", "Description", 10m, -5, "image");
        action.Should()
        .Throw<DomainExceptionValidation>()
        .WithMessage("Invalid stock value.");
    }
}
}

