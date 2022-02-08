using EcommercePlatform.Domain.Product;
using EcommercePlatform.Domain.Order;
using EcommercePlatform.Domain.Campaign;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XunitTest.Campaign
{
    public class CampaignServiceTests
    {
        [Fact]
        public void CreateCampaign_ReturnSuccess() {

            //Arrange
            IProductService productService = new ProductService();
            ICampaignService campaignService = new CampaignService(productService);
            var commandProduct = "create_product P1 100 1000";
            var inputProduct = commandProduct.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            productService.CreateProdut(inputProduct);
            var command = "create_campaign C1 P1 10 20 100";
            var inputCampaign = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //Act

            var result =campaignService.CreateCampaign(inputCampaign);
            

            //Assert
            Assert.True(result);
        }
        [Fact]
        public void GetCampaignInfo_ReturnSuccess()
        {

            //Arrange
            IProductService productService = new ProductService();
            ICampaignService campaignService = new CampaignService(productService);
            var commandProduct = "create_product P1 100 1000";
            var inputProduct = commandProduct.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            productService.CreateProdut(inputProduct);
            var command = "create_campaign C1 P1 10 20 100";
            var inputCampaign = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var commandCampaignInfo = "get_campaign_info C1";
            var inputCampaignInfo = commandCampaignInfo.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //Act

            campaignService.CreateCampaign(inputCampaign);
            var result =  campaignService.GetCampaignInfo(inputCampaignInfo);

            //Assert
            Assert.True(result);
        }


        
    }
}
