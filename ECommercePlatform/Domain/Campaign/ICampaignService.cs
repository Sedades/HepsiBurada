using System;
using System.Collections.Generic;
using System.Text;

namespace EcommercePlatform.Domain.Campaign {
    public interface ICampaignService {
        bool CreateCampaign(string[] input);
        bool GetCampaignInfo(string[] input);
        Campaign GetCampaignOfProduct(string productCode);
        void BuildManipulation( int hour);
    }
}
