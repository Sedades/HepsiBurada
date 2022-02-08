using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EcommercePlatform.Domain.Product;

namespace EcommercePlatform.Domain.Campaign {
    public class CampaignService : ICampaignService {
        private readonly IProductService productService;


        public List<Campaign> Campaigns { get; set; }

        public CampaignService(IProductService productService) {
            if (Campaigns == null)
                Campaigns = new List<Campaign>();
            this.productService = productService;
        }
        public bool CreateCampaign(string[] input) {
            if (input.Length < 6) {
                Console.Write("Invalid parameter lenght! ");
                return false;
            }

            var campaign = Campaigns.FirstOrDefault(x => x.Name == input[1]);
            if (campaign != null) {
                Console.Write("'{0}' campaign name is already exists! ", input[1]);
                return false;
            }
            var product = productService.GetProduct(input[2]);
            if (product == null) {
                Console.Write("'{0}' product isn't exists! ", input[2]);
                return false;
            }

            var newCampaign = new Campaign() {
                Name = input[1],
                ProductCode = input[2],
                Duration = Convert.ToInt32(input[3]),
                BaseDuration= Convert.ToInt32(input[3]),
                PriceManipulationLimit = Convert.ToInt32(input[4]),
                TargetSalesCount = Convert.ToInt32(input[5]),
                Status = true
            };

            Campaigns.Add(newCampaign);

            Console.WriteLine("Campaign created; name {0}, product {1}, duration {2}, limit {3}, target sales count {4}",
                newCampaign.Name, newCampaign.ProductCode, newCampaign.Duration, newCampaign.PriceManipulationLimit, newCampaign.TargetSalesCount);

            return true;
        }

        public bool GetCampaignInfo(string[] input) {


            if (input.Length < 2) {
                Console.Write("Unexcepted paramater");
                return false;
            }

            var campaign = Campaigns.FirstOrDefault(x => x.Name == input[1]);
            if (campaign == null) {
                Console.Write("'{0}' campaign isn't exists! ", input[1]);
                return false;
            }

            var product = productService.GetProduct(campaign.ProductCode);

            var avarageItemPrice = campaign.TotalCampaignPrice / campaign.TotalSalesCount;
            if (campaign.Duration > 0) {
                campaign.Status = true;
            }
            else if (campaign.Duration <= 0) {
                campaign.Status = false;
            }
            var status = campaign.Status ? "Active" : "Ended";
            Console.WriteLine("Campaign {0} info; Status {1}, Target Sales {2},Total sales {3}, Turnover {4}, Average Item Price {5}",
                campaign.Name, status, campaign.TargetSalesCount, campaign.TotalSalesCount, campaign.Turnover, avarageItemPrice);

            return true;
        }
        public Campaign GetCampaignOfProduct(string productCode) {
            return Campaigns.FirstOrDefault(c => c.ProductCode == productCode);
        }

        public void BuildManipulation(int hour) {
            foreach (var campaign in Campaigns) {
                if (campaign.Duration > 0) {
                    var product = productService.GetProduct(campaign.ProductCode);
                    double limitPrice = product.BasePrice - (product.BasePrice * campaign.PriceManipulationLimit / 100);
                    double diff = product.BasePrice - limitPrice;
                    double newdiffPrice = diff / (campaign.BaseDuration - 1);

                    product.Price -= newdiffPrice;
                    campaign.TotalCampaignPrice += product.Price;
                    if (product.Price < product.BasePrice - campaign.PriceManipulationLimit) {
                        product.Price = product.BasePrice;
                    }
                    campaign.Duration -= hour;
                }
                

            }
        }
    }
}
