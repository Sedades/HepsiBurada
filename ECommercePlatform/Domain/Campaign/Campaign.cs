using System;
using System.Collections.Generic;
using System.Text;

namespace EcommercePlatform.Domain.Campaign {
    public class Campaign {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public int BaseDuration { get; set; }
        public int PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
        public bool Status { get; set; }
        public int TotalSalesCount { get;  set; }
        public double Turnover { get; set; }
        public double TotalCampaignPrice { get; set; }
    }
}
