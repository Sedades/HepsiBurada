using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using EcommercePlatform.Domain.Time;
using EcommercePlatform.Domain.Product;
using EcommercePlatform.Domain.Campaign;
using FluentAssertions;

namespace XunitTest.Time
{
    public class TimeServiceTests {
       
        
        [Fact]
        public void IncreaseTime_WhenCalled_ShouldNotThrowException()
        {

            //Arrange
            IProductService productService = new ProductService();
            ICampaignService campaignService = new CampaignService(productService);
            ITimeService timeService = new TimeService(campaignService);
            var command = "increase_time 1";
            var inputTime = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //Act
            Action act = () => timeService.IncreaseTime(inputTime);

            //Assert
            act.Should().NotThrow<Exception>();
        }


        
    }
}
