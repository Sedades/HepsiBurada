using EcommercePlatform.Domain.Product;
using EcommercePlatform.Domain.Order;
using EcommercePlatform.Domain.Campaign;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace XunitTest.Order
{
    public class OrderServiceTests
    {
        
        [Fact]
        public void OrderService_Should_AddNewOrder()
        {

            //Arrange
            IProductService productService = new ProductService();
            ICampaignService campaignService = new CampaignService(productService);
            IOrderService orderService = new OrderService(productService, campaignService);
            var commandProduct = "create_product P1 100 1000";
            var inputProduct = commandProduct.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            productService.CreateProdut(inputProduct);
            var command = "create_order P1 3";
            var inputOrder = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //Act

            orderService.CreateOrder(inputOrder);
            Action act = () => orderService.CreateOrder(inputOrder);


            //Assert
            act.Should().NotThrow<Exception>();
        }


    }
}
