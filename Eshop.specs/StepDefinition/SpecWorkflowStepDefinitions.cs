using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Xunit;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;
using System.Threading;
using Eshop.specs.PageObjectModel;

namespace Eshop.specs
{
    [Binding]
    public class SpecWorkflowStepDefinitions
    {
        private LoginPage _LoginPage;
        private HomePage _HomePage;
        public IWebDriver driver = new ChromeDriver();

        public SpecWorkflowStepDefinitions()
        {
            _LoginPage = new LoginPage(driver);
            _HomePage = new HomePage(driver);
        }
        

        [Given(@"User navigates to the HomePage")]
        public void GivenIAmOnTheHomePage()
        {
            _HomePage.goToHomePage();
        }

        [When(@"User navigates to the login page")]
        public void WhenINavigateToTheLoginPage()
        {
            _LoginPage.goToLoginPage();
        }

        [When(@"User enters a valid credentials,with input email ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenIEnterEmailAndPassword(string email, string password)
        {
            _LoginPage.enterLoginCredentials( email, password);
        }

        [When(@"User clicks on login")]
        public void WhenIClickOnLogin()
        {
            _LoginPage.clickOnLogin();
        }

        [Then(@"User is redirected to HomePage where the user's email ""([^""]*)"" will appear on the Navbar")]
        public void ThenIAmRedirectedToHomePageWhereTheUsersEmailWillAppearOnTheNavbar(string emailNav)
        {
            _HomePage.verifyIfLoginIsSuccessful(emailNav);
        }

        [When(@"User enters an invalid password,with input email ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenIEnterAnInvalidPasswordEmailAndPassword(string email, string password)
        {
            _LoginPage.enterLoginCredentials(email, password);
        }

        [When(@"User enters an invalid emailAddress,with input email ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenIEnterAnInvalidEmailAndPassword(string email, string password)
        {
            _LoginPage.enterLoginCredentials(email, password);
        }

        [Then(@"An error message will be displayed")]
        public void ThenAErrorMessageWillBeDisplayed()
        {
            _LoginPage.checkIfLoginIsUnsuccessful();
        }
    }
}
