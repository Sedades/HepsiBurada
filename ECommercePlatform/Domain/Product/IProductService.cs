using System;
using System.Collections.Generic;
using System.Text;


namespace EcommercePlatform.Domain.Product {
    public interface IProductService
    {
        void CreateProdut(string[] input);
        void GetProductInfo(string[] input);
        Product GetProduct(string productCode);
        bool HasStock(int quantity, string productCode);
    }
}
