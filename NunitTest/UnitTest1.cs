using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;


namespace NunitTest.IntegrationTests
{
    public class FrontEndTests
    {
        private IWebDriver _driver;
        private string _baseUrl = "https://localhost:7297"; // Update with your base URL

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(); // Use the appropriate driver for your browser
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void Test_IndexPage()
        {
            // Arrange
            _driver.Navigate().GoToUrl(_baseUrl + "/Item/Index");

            // Assert
            Assert.IsTrue(_driver.PageSource.Contains("<h2>Items</h2>"));
            
        }

        [Test]
        public void Test_CreatePage()
        {
            // Arrange
            _driver.Navigate().GoToUrl(_baseUrl + "/Item/Create");

            // Assert
            Assert.IsTrue(_driver.PageSource.Contains("<form asp-action=\"Create\">"));
            
        }

        [Test]
        public void Test_DeletePage()
        {
            // Arrange
            _driver.Navigate().GoToUrl(_baseUrl + "/Item/Delete");

            // Assert
            Assert.IsTrue(_driver.PageSource.Contains("<h2>Delete Item</h2>"));
            // Add more assertions as needed
        }
    }
}
