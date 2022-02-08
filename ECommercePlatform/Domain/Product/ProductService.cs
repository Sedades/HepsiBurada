using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EcommercePlatform.Domain.Product {
    public class ProductService : IProductService {

        private readonly Dictionary<string, Product> Products = new Dictionary<string, Product>();

        public void CreateProdut(string[] input) {
            if (input.Length < 4) {
                Console.WriteLine("Unexcepted paramater! ");
            }
            var product = GetProduct(input[1]);
            if (product != null) {
                Console.Write("'{0}' This product is already exists! ", input[1]);
            }

            var newProduct = new Product() {
                ProductCode = input[1],
                Price = Convert.ToInt32(input[2]),
                BasePrice = Convert.ToInt32(input[2]),
                Stock = Convert.ToInt32(input[3])
            };

            Products.Add(input[1],newProduct);

            Console.WriteLine("Product created; Product Code {0}, Price {1}, Stock {2}", newProduct.ProductCode, newProduct.Price, newProduct.Stock);


        }

        public  void GetProductInfo(string[] input) {
            if (input.Length < 2) {
                Console.WriteLine("Unexcepted paramater! ");
            }

            var product = GetProduct(input[1]);
            if (product == null) {
                Console.Write("'{0}' product isn't exists! ", input[1]);
            }

            Console.WriteLine("Product {0} info; Price {1}, Stock {2}", product.ProductCode, product.Price, product.Stock);

        }
        public Product GetProduct(string productCode) {
            if (Products.ContainsKey(productCode)) {
                return Products[productCode];
            }
            
            else {
                return null;
            }
        }
        public bool HasStock(int quantity, string productCode) {
            var product = GetProduct(productCode);
            bool exist = product.Stock - quantity >= 0;
            if (!exist) {
                Console.WriteLine("Product stock is not enought for this quantity, current stock is {0}", product.Stock);
            }

            return exist;
        }
    }
}
