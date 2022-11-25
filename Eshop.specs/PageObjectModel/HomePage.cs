using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Eshop.specs.PageObjectModel
{
    public class HomePage
    {
        By emailOnNavbarXPathOnHomePage = By.XPath("//*[@id=\"logoutForm\"]/section[1]/div");
        IWebDriver _driver;

        public static string HomePageURL = "https://localhost:44315/";
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void goToHomePage()
        {
            _driver.Navigate().GoToUrl(HomePageURL);
        }

        public void verifyIfLoginIsSuccessful(string emailOnNavbar)
        {
            IWebElement loginNavEmail = _driver.FindElement(emailOnNavbarXPathOnHomePage);
            Assert.Equal(emailOnNavbar, loginNavEmail.Text);
            _driver.Quit();
        }

        public void verifyIfLoginIsSuccessfulWithContinousFlow(string emailOnNavbar)
        {
            IWebElement loginNavEmail = _driver.FindElement(emailOnNavbarXPathOnHomePage);
            Assert.Equal(emailOnNavbar, loginNavEmail.Text);
        }

    }
}
