using System;
using System.Collections.Generic;
using System.Text;

namespace EcommercePlatform.Domain.Order {
    public interface IOrderService {
        void CreateOrder(string[] input);
    }
}
