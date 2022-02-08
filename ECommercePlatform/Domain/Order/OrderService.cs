using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EcommercePlatform.Domain.Product;
using EcommercePlatform.Domain.Campaign;


namespace EcommercePlatform.Domain.Order {
    public class OrderService :IOrderService {

        private readonly IProductService productService;
        private readonly ICampaignService campaignService;

        private List<Order> Orders = new List<Order>();

        public OrderService(IProductService productService, ICampaignService campaignService) {
            if (Orders == null)
                Orders = new List<Order>();
            this.productService = productService;
            this.campaignService = campaignService;
        }
        public void CreateOrder(string[] input) {

            if (input.Length < 3) {
                Console.Write("Invalid parameter lenght! ");
            }

            var product = productService.GetProduct(input[1]);
            if (product == null) {
                Console.Write("'{0}' product isn't exists! ", input[1]);
            }
            var quantity = Convert.ToInt32(input[2]);
            var productCode = input[1];
            if (productService.HasStock(quantity,productCode)) {
                var campaign = campaignService.GetCampaignOfProduct(product.ProductCode);
                if (campaign != null) {
                    campaign.TotalSalesCount += Convert.ToInt32(input[2]);
                    campaign.Turnover += product.Price * Convert.ToInt32(input[2]);
                }
                product.Stock = product.Stock - Convert.ToInt32(input[2]);
                var newOrder = new Order() {
                    ProductCode = input[1],
                    Quantity = Convert.ToInt32(input[2])
                };

                Orders.Add(newOrder);

                Console.WriteLine("Order created; product {0}, quantity {1}", newOrder.ProductCode, newOrder.Quantity);
            }
        }
       

    }
}
