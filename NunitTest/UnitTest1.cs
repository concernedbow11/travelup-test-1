using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FrontEndTests
{
    public class FrontEndTests
    {
        private IWebDriver _driver;
        private string _baseUrl = "https://localhost:7297"; // Set your base URL

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(); // Use ChromeDriver for testing
            _driver.Manage().Window.Maximize(); // Maximize the browser window
        }
        

        [Test]
        public void EditItem_SuccessfullyEditsItem()
        {
            // Arrange
            _driver.Navigate().GoToUrl(_baseUrl + "/Item/Edit");
            var itemNameInput = _driver.FindElement(By.Id("itemName"));
            itemNameInput.Clear();
            itemNameInput.SendKeys("Edited Item");
            var itemPriceInput = _driver.FindElement(By.Id("itemPrice"));
            itemPriceInput.Clear();
            itemPriceInput.SendKeys("25.00");
            var editButton = _driver.FindElement(By.CssSelector("button[type='submit']"));

            // Act
            editButton.Click();

            // Assert
            var itemsLink = _driver.FindElement(By.LinkText("Items"));
            itemsLink.Click();
            var editedItemLink = _driver.FindElement(By.LinkText("Edited Item"));
            Assert.IsNotNull(editedItemLink);
        }

        [Test]
        public void DeleteItem_SuccessfullyDeletesItem()
        {
            // Arrange
            _driver.Navigate().GoToUrl(_baseUrl + "/Item/Delete");
            var deleteButton = _driver.FindElement(By.CssSelector("button[type='submit']"));

            // Act
            deleteButton.Click();

            // Assert
            var itemsLink = _driver.FindElement(By.LinkText("Items"));
            itemsLink.Click();
            var deletedItemLink = _driver.FindElements(By.LinkText("Edited Item"));
            Assert.IsEmpty(deletedItemLink);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit(); // Close the browser after each test`
            _driver.Dispose();
        }
    }
}
