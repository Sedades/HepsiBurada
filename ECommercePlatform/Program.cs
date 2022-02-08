using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EcommercePlatform.Domain.Campaign;
using EcommercePlatform.Domain.Order;
using EcommercePlatform.Domain.Product;
using EcommercePlatform.Domain.Time;
using Microsoft.Extensions.DependencyInjection;

namespace EcommercePlatform
{
    public class Program
    {

        public static void Main(string[] args)
        {

            IProductService productService = new ProductService();
            ICampaignService campaignService = new CampaignService(productService);
            IOrderService orderService = new OrderService(productService, campaignService);
            ITimeService timeService = new TimeService(campaignService);


            do
            {
                Console.Write("enter the command: ");
                var command = Console.ReadLine();
                if (string.IsNullOrEmpty(command))
                {
                    return;
                }
                var input = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var method = input[0];
                try
                {

                    switch (method)
                    {
                        case "create_product":
                            productService.CreateProdut(input);
                            break;
                        case "get_product_info":
                            productService.GetProductInfo(input);
                            break;
                        case "create_order":
                            orderService.CreateOrder(input);
                            break;
                        case "create_campaign":
                            campaignService.CreateCampaign(input);
                            break;
                        case "get_campaign_info":
                            campaignService.GetCampaignInfo(input);
                            break;
                        case "increase_time":
                            timeService.IncreaseTime(input);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);
        }


    }



}