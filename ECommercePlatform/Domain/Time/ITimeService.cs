using System;
using System.Collections.Generic;
using System.Text;

namespace EcommercePlatform.Domain.Time {
    public interface ITimeService {
        void IncreaseTime(string[] input);
    }
}
