using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using EcommercePlatform.Domain.Product;
using FluentAssertions;

namespace XunitTest.Product
{
    public class ProductServiceTests
    {

        [Fact]
        public void CreateProdut_WhenCalled_ShouldNotThrowException() {

            //Arrange
            IProductService productService = new ProductService();
            var command = "create_product P1 100 1000";
            var inputProduct = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //Act
            Action act = () => productService.CreateProdut(inputProduct);

            //Assert
            act.Should().NotThrow<Exception>();
        }
        [Fact]
        public void GetProduct_WhenCalled_ShouldNotThrowException()
        {

            //Arrange
            IProductService productService = new ProductService();
            var command = "create_product P1 100 1000";
            var inputProduct = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //Act

            productService.CreateProdut(inputProduct);
            Action act = () => productService.GetProduct("P1");

            //Assert
            act.Should().NotThrow<Exception>();
        }
        [Fact]
        public void GetProductInfo_WhenCalled_ShouldNotThrowException() {

            //Arrange
            IProductService productService = new ProductService();
            var command = "create_product P1 100 1000";
            var inputProduct = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var commandProductInfo = "get_product_info P1";
            var inputProductInfo = commandProductInfo.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //Act

            productService.CreateProdut(inputProduct);
            Action act = () => productService.GetProductInfo(inputProductInfo);

            //Assert
            act.Should().NotThrow<Exception>();
        }
        [Theory]
        [InlineData(3,"P1")]
        public void CreateCampaign_ReturnSuccess(int quantity ,string productCode) {

            //Arrange
        IProductService productService = new ProductService();
            var command = "create_product P1 100 1000";
            var inputProduct = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //Act

            productService.CreateProdut(inputProduct);
            var result= productService.HasStock(quantity,  productCode);

            //Assert
            Assert.True(result);
        }

    }
}
