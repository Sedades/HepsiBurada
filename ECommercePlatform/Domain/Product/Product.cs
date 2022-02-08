using System;
using System.Collections.Generic;
using System.Text;

namespace EcommercePlatform.Domain.Product {

    public class Product {
        public string ProductCode { get; set; }
        public double BasePrice { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }


}
