using MVCTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTest.Helper
{
    public class ProductsHelper
    {
        static List<ProductsModel> ProductsList = new List<ProductsModel>();


        public static List<ProductsModel> GetProductsfromMemory()
        {
            if (SessionHelper.GetSession("Products").ToString() == string.Empty)
            {
                SetDefaultProducts();
            }
            return (SessionHelper.GetSession("Products") as List<ProductsModel>);
        }

        private static void SetDefaultProducts()
        {
            if (ProductsList.Where(a => a.ProductId == 1).ToList().Count <= 0)
            {
                ProductsList.Add(new ProductsModel { ProductId = 1, ProductName = "Product A", Price = 100, Description = "Sample product 1" });
                ProductsList.Add(new ProductsModel { ProductId = 2, ProductName = "Product B", Price = 200, Description = "Sample product 2" });
                ProductsList.Add(new ProductsModel { ProductId = 3, ProductName = "Product C", Price = 300, Description = "Sample product 3" });
                ProductsList.Add(new ProductsModel { ProductId = 4, ProductName = "Product D", Price = 400, Description = "Sample product 4" });
            }
            SessionHelper.SetSession("Products", ProductsList);
        }
        public static void CreateProducts(ProductsModel entity)
        {
            // List<ProductsModel> modellst = new List<ProductsModel>();
            var productId = ProductsList.Max(a => a.ProductId) + 1;
            ProductsList.Add(new ProductsModel { ProductId = productId, ProductName = entity.ProductName, Price = entity.Price, Description = entity.Description });
            SessionHelper.SetSession("Products", ProductsList);
        }

        public static ProductsModel GetProduct(int productId)
        {
            var productslst = SessionHelper.GetSession("Products") as List<ProductsModel>;
            return productslst.Where(a => a.ProductId == productId).SingleOrDefault();
        }



    }
}