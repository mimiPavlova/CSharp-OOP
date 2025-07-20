using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace NetTraderSystem.Tests
{
    public class Tests
    {
        private Product product;
        private string productName = "PRODUCT";
        private string category = "CATEGORY";
        private double prise = 100;
        private TradingPlatform tradingPlatform;
        private int limit = 1;

        [SetUp]
        public void Setup()
        {
            product=new Product(productName, category, prise);
            tradingPlatform=new TradingPlatform(limit);

        }

        [Test]
        public void ProductConstructor_Check()
        {
            Assert.AreEqual(product.Name, productName);
            Assert.AreEqual(product.Category, category);
            Assert.AreEqual(product.Price, prise);

            Assert.AreEqual("Name: PRODUCT, Category: CATEGORY - $100.00", product.ToString());
        }

        [Test]
        public void AddProduct()
        {
            string result = tradingPlatform.AddProduct(product);
            Assert.AreEqual(tradingPlatform.Products.Count, 1);
            Assert.AreEqual("Product PRODUCT added successfully", result);
        }
        [Test]
        public void AddProduct_FullInventory()
        {
            tradingPlatform.AddProduct(product);
            string result = tradingPlatform.AddProduct(product);
            Assert.AreEqual("Inventory is full", result);
        }
        [Test]
        public void RemoveProduct()
        {
            tradingPlatform.AddProduct(product);
            Assert.AreEqual(true, tradingPlatform.RemoveProduct(product));
            Assert.AreEqual(false, tradingPlatform.RemoveProduct(product));
        }
        [Test]
        public void SellProduct()
        {
            tradingPlatform.AddProduct(product);
            Assert.AreEqual(tradingPlatform.SellProduct(product), product);
            Assert.AreEqual(null, tradingPlatform.SellProduct(product));
        }
        [Test]
        public void ReportTest()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inventory Report:");
            sb.AppendLine($"Available Products: 1");
            sb.AppendLine("Name: PRODUCT, Category: CATEGORY - $100.00");
            string result=sb.ToString().Trim();
            
            tradingPlatform.AddProduct(product);
            Assert.AreEqual(result, tradingPlatform.InventoryReport());
        }
    }
}