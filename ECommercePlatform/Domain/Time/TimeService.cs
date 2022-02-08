using System;
using System.Collections.Generic;
using System.Text;
using EcommercePlatform.Domain.Campaign;



namespace EcommercePlatform.Domain.Time {
    public class TimeService :ITimeService{
        public  int CurrentTime { get; set; }
        private readonly ICampaignService campaignService;
        public TimeService(ICampaignService campaignService) {
            this.campaignService = campaignService;
        }
        public void IncreaseTime(string[] input) {
            if (input.Length < 2) {
                Console.Write("Unexcepted paramater! ");
            }
            int hour = Convert.ToInt32(input[1]);
            if (CurrentTime + Convert.ToInt32(input[1]) == 24) {
                CurrentTime = 0;
                Console.WriteLine("Time is {0}:00", CurrentTime);
            }

            CurrentTime = CurrentTime + Convert.ToInt32(input[1]);
            Console.WriteLine("Time is {0}:00", CurrentTime);
            campaignService.BuildManipulation(hour);

        }

    }
}
