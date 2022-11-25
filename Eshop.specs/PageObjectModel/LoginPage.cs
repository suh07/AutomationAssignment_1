using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Eshop.specs.PageObjectModel
{
    public class LoginPage
    {
       IWebDriver _driver;

        By loginButtonXPathOnHomePage = By.XPath("/html/body/div/header/div/article/section[2]/div/section/div/a");
        By loginButtonXPathOnloginPage = By.XPath("/html/body/div/div/div/div/section/form/div[5]/button");
        By loginErrorMessageXPathOnloginPage = By.XPath("/html/body/div/div/div/div/section/form/div[1]/ul/li");
        By emailFieldId = By.Id("Input_Email");
        By passwordFieldId = By.Id("Input_Password");

        private const string passwordErrorMsg = "Invalid login attempt.";

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void goToLoginPage()
        {
            IWebElement loginButton = _driver.FindElement(loginButtonXPathOnHomePage);
            loginButton.Click();
        }

        public void enterLoginCredentials(string email,string password)
        {
            IWebElement emailField = _driver.FindElement(emailFieldId);
            emailField.SendKeys(email);
            IWebElement passwordField = _driver.FindElement(passwordFieldId);
            passwordField.SendKeys(password);
        }

        public void clickOnLogin()
        {
            IWebElement loginButton = _driver.FindElement(loginButtonXPathOnloginPage);
            loginButton.Click();
        }

        public void checkIfLoginIsUnsuccessful()
        {
            IWebElement InvalidPasswordMsg = _driver.FindElement(loginErrorMessageXPathOnloginPage);
            Assert.Equal(passwordErrorMsg, InvalidPasswordMsg.Text);
            _driver.Quit();
        }

    }
}
