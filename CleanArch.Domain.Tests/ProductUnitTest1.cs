using CleanArch.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArch.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product with Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description",
                9.99m, 99, "product image");
            action.Should().NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }


        [Fact(DisplayName = "Create Product with Missing Name Value")]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "", "Product Description",
                9.99m, 99, "product image");
            action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required!");
        }

        //[Fact(DisplayName = "Create Product with Null Name Value")]
        //public void CreateProduct_WithNullNameValue_DomainExceptionInvalidName()
        //{
        //    Action action = () => new Product(1, null, "Product Description",
        //        9.99m, 99, "product image");
        //    action.Should().NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        //}

        //[Fact(DisplayName = "Create Product with Null Description Value")]
        //public void CreateProduct_WithNullDescriptionValue_DomainExceptionInvalidDescription()
        //{
        //    Action action = () => new Product(1, "Product Name", null,
        //        9.99m, 99, "product image");
        //    action.Should().NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        //}



        [Fact(DisplayName = "Create Product with Negative Id Value")]
        public void CreateProduct_NegativeIdValue_DomainExcepctionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description",
                9.99m, 99, "product image");
            action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value!");
        }





        [Fact(DisplayName = "Create Product with Short Name Value")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description",
                9.99m, 99, "product image");
            action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name too short,minimum 3 characters!");
        }




        [Fact(DisplayName = "Create Product with Missing Description Value")]
        public void CreateProduct_MissingDescriptionValue_DomainExceptionRequiredDescription()
        {
            Action action = () => new Product(1, "Product Name", "",
                9.99m, 99, "product image");
            action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required!");
        }





        [Fact(DisplayName = "Create Product with Short Description Value")]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionShortDescription()
        {
            Action action = () => new Product(1, "Product Name", "Prod",
                9.99m, 99, "product image");
            action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description too short,minimum 5 characters!");
        }




        [Fact(DisplayName = "Create Product with Long Image Name")]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description",
                9.99m, 99, "product image toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong");
            action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long! Maximum 250 characters!");
        }

         


        [Fact(DisplayName = "Create Product with Null Image Name")]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new  Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product with Null Image Name")]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<NullReferenceException>();
        }


        [Fact(DisplayName = "Create Product with Empty Image Name")]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should().NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }




        [Fact(DisplayName = "Create Product with Invalid Price Value")]
        public void CreateProduct_WithInvalidPriceValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -9.99m, 99, "product image");
            action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value!");
        }



        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Pro", "Product Description", 9.99m, value, "product image");
            action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value!");
        }




        
    }
}
