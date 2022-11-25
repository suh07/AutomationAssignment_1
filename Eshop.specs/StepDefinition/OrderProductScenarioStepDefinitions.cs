using Eshop.specs.PageObjectModel;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using OpenQA.Selenium.Edge;

namespace Eshop.specs
{
    [Binding]
    public class OrderProductScenarioStepDefinitions
    {
       
        private HomePage _HomePage;
        private LoginPage _LoginPage;
        private OrderPage _OrderPage;

        //public IWebDriver driver = new ChromeDriver();
        // public IWebDriver driver = new EdgeDriver();
        public IWebDriver driver;
        public OrderProductScenarioStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            _HomePage = new HomePage(driver);
            _LoginPage = new LoginPage(driver);
            _OrderPage = new OrderPage(driver);
        }

        [Given(@"Users navigate to the HomePage")]
        public void GivenUserNavigatesOnTheHomePage()
        {
            _HomePage.goToHomePage();
        }

        [When(@"Users navigate to the login page")]
        public void WhenINavigateToTheLoginPage()
        {
            _LoginPage.goToLoginPage();
        }

        [When(@"Users enters a valid credentials,with input email ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenIEnterEmailAndPassword(string email, string password)
        {
            _LoginPage.enterLoginCredentials(email, password);
        }

        [When(@"Users clicks on login")]
        public void WhenIClickOnLogin()
        {
            _LoginPage.clickOnLogin();
        }

        [When(@"Users is redirected to HomePage where the user's email ""([^""]*)"" will appear on the Navbar")]
        public void ThenIAmRedirectedToHomePageWhereTheUsersEmailWillAppearOnTheNavbar(string emailNav)
        {
            _HomePage.verifyIfLoginIsSuccessfulWithContinousFlow(emailNav);
        }

        [When(@"User select other from the brand dropdown")]
        public void WhenUserSelectOtherFromTheBrandDropdown()
        {
            _OrderPage.selectOtherOnDropdown();
        }

        [When(@"User click on apply the filter button")]
        public void WhenUserClickOnApplyTheFilterButton()
        {
            _OrderPage.applyFilter();
        }

        [Then(@"User adds a product to cart")]
        public void ThenUserAddsAProductToCart()
        {
            _OrderPage.addProductToCart();
        }

        [Then(@"User select ""([^""]*)"" as quantity")]
        public void ThenUserSelectAsQuantity(string quantity)
        {
            _OrderPage.selectProductQuantity(quantity);
        }

        [Then(@"User updates click on the update cart button")]
        public void ThenUserUpdatesClickOnTheUpdateCartButton()
        {
            _OrderPage.updateCart();
        }

        [Then(@"User clicks on the checkout button")]
        public void ThenUserClickOnTheCheckoutButton()
        {
            _OrderPage.checkOut();
        }

        [Then(@"User clicks on paynow button")]
        public void ThenUserClicksOnPaynowButton()
        {
            _OrderPage.payNow();
        }

        [Then(@"User view the confirmation message")]
        public void ThenUserViewTheConfirmationMessage()
        {
            _OrderPage.confirmOrderMessage();
        }

        [Then(@"User navigates to the orders page and view the order details")]
        public void ThenUserNavigatesToTheOrdersPageAndViewTheOrderDetails()
        {
            _OrderPage.checkProductOrderHistory();
        }

        [Then(@"User click on update cart \(with assert\)")]
        public void ThenUserClickOnUpdateCartWithAssert()
        {
            _OrderPage.UpdateCartForInvalidQuantities();
        }


        [Then(@"Users Add product to cart")]
        public void ThenUsersAddProductToCart(Table table)
        {
            _OrderPage.AddSeveralProductToCart(table);       
        }

        [Then(@"go back to cart to proceed to checkout")]
        public void ThenGoBackToCartToProceedToCheckout()
        {
            _OrderPage.GoBackToCart();
        }

        [Then(@"verify purchase")]
        public void ThenVerifyPurchase(Table table)
        {
            _OrderPage.VerifyPurchaseOrder(table);
        }


    }
}
