using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using TechTalk.SpecFlow;

namespace Eshop.specs
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            _scenarioContext.ScenarioContainer.RegisterInstanceAs(driver);
        }

        [BeforeScenario("Chrome")]
        public void BeforeScenarioChrome()
        {
            driver.Quit();
            driver = new ChromeDriver();
            _scenarioContext.ScenarioContainer.RegisterInstanceAs(driver);
        }
        [BeforeScenario("Edge")]
        public void BeforeScenarioEdge()
        {
            driver.Quit();
            driver = new EdgeDriver();
            _scenarioContext.ScenarioContainer.RegisterInstanceAs(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
            driver.Dispose();
        }
}
}