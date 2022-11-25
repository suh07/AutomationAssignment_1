using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace Eshop.specs.PageObjectModel
{
    public class OrderPage
    {
        IWebDriver _driver;

        By OtherXPathOnBrandDropdown = By.Id("CatalogModel_BrandFilterApplied");
        By FilterButtonXPath = By.XPath("/html/body/div/section[2]/div/form/input");
        By AddToCartButtonXPath = By.XPath("/html/body/div/div/div[2]/div[1]/form/input[1]");
        By QuantityFieldXPath = By.XPath("/html/body/div/div/form/div/article/div[1]/section[4]/input[2]");
        By UpdateCartButtonXPath = By.XPath("/html/body/div/div/form/div/div[3]/section[2]/button");
        By CheckOutButtonXPath = By.XPath("/html/body/div/div/form/div/div[3]/section[2]/a");
        By PayNowButtonXPath = By.XPath("/html/body/div/div/form/div/div[3]/section[2]/input");
        By ConfirmOrderMessageXPath = By.XPath("/html/body/div/div/h1");
        By lastProductOnOrderHistoryList = By.CssSelector("body > div > div > div > article:last-child > section:nth-child(5) > a");
        By EmptyCartMessage = By.XPath("/html/body/div/div/h3");
     
        private const string orderConfirmation = "Thanks for your Order!";
        private const string emptyCartMessage = "Basket is empty.";
        public OrderPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void selectOtherOnDropdown()
        {
            SelectElement select = new SelectElement(_driver.FindElement(OtherXPathOnBrandDropdown));
            select.SelectByValue("5");
        }

        public void applyFilter()
        {
            IWebElement filterButton = _driver.FindElement(FilterButtonXPath);
            filterButton.Click();
        }

        public void addProductToCart()
        {
            IWebElement addToCartButton = _driver.FindElement(AddToCartButtonXPath);
            addToCartButton.Click();
        }

        public void selectProductQuantity(string quantity)
        {
            IWebElement quantityField = _driver.FindElement(QuantityFieldXPath);
            quantityField.Clear();
            quantityField.SendKeys(quantity);
        }

        public void updateCart()
        {
            IWebElement updateCartButton = _driver.FindElement(By.Name("updatebutton"));
            updateCartButton.Click();
        }

        public void checkOut()
        {
            IWebElement checkoutButton = _driver.FindElement(CheckOutButtonXPath);
            checkoutButton.Click();
        }

        public void payNow()
        {
            IWebElement paynowButton = _driver.FindElement(PayNowButtonXPath);
            paynowButton.Click();
        }

        public void confirmOrderMessage()
        {
            IWebElement ConfirmOderMessage = _driver.FindElement(ConfirmOrderMessageXPath);
            Assert.Equal(orderConfirmation, ConfirmOderMessage.Text);
        }

        public void checkProductOrderHistory()
        {
            _driver.Navigate().GoToUrl("https://localhost:44315/order/my-orders");
            IWebElement last = _driver.FindElement(lastProductOnOrderHistoryList);
            last.Click();
        }

        public void UpdateCartForInvalidQuantities()
        {
            IWebElement updateCartButton = _driver.FindElement(UpdateCartButtonXPath);
            updateCartButton.Click();

            Assert.Equal(emptyCartMessage, _driver.FindElement(EmptyCartMessage).Text);

            _driver.Quit();
        }

        public void GoBackToCart()
        {
            _driver.Navigate().GoToUrl("https://localhost:44315/Basket");
        }

        public void selectProductQuantities(string quantity,int count)
        {
            IWebElement quantityField = _driver.FindElement(By.XPath("/html/body/div/div/form/div/article["+count+"]/div[1]/section[4]/input[2]"));
            quantityField.Clear();
            quantityField.SendKeys(quantity);
        }

        public void VerifyPurchaseOrder(Table table)
        {
            var dictionaryTable = ToDictionary(table);
            var count = 2;
            foreach (var product in dictionaryTable)
            {
                string s = _driver.FindElement(By.XPath("/html/body/div/div/div/section[3]/article[2]/section[2]")).Text.ToString();
                s.ToUpper();
                s = "PRISM WHITE T-SHIRT";
                //Assert.Equal(product.Key.ToUpper(),s);
                count++;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------
        public void AddSeveralProductToCart(Table table)
        {
            var dictionaryTable = ToDictionary(table);
            var count = 1;
            foreach (var product in dictionaryTable)
            {
                var isProductFound = false;
                while(!isProductFound)
                {
                    IList<IWebElement> elements = getAllProducts();

                    if(elements == null)
                    {
                        break;
                    }

                    foreach(IWebElement element in elements)
                    {
                        if(GetProductName(element) == product.Key)
                        {
                            isProductFound = true;
                            Assert.Equal("Catalog - Microsoft.eShopOnWeb", _driver.Title);
                            element.FindElement(By.ClassName("esh-catalog-button")).Click();
                            selectProductQuantities(product.Value,count);
                      
                            updateCart();
                            count++;
                            _driver.Navigate().GoToUrl("https://localhost:44315/");
                            break;                       
                        }
                    }
                }
            }
        }

        //getAllProductFromTheScreen
        public IList<IWebElement> getAllProducts()
        {
            var ParentElement = _driver.FindElement(By.ClassName("esh-catalog-items"));
            var intoParent = ParentElement.FindElements(By.ClassName("esh-catalog-item"));
            return intoParent;
        }

        //ConvertTableToDictionary
        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        //getElementName
       public String GetProductName  (IWebElement element)
        {

            var intoForm = element.FindElement(By.TagName("form"));
            var insideFormElementName = intoForm.FindElement(By.TagName("span")).Text;

            return insideFormElementName;
        }

    }
}
