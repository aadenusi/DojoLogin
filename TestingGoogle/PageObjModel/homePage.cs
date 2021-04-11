using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Internal.Commands;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestingGoogle.Steps
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private int width_;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            driver.Manage().Window.Size = new System.Drawing.Size(width_, 800);
        }

        public void OpenNavigate(string page)
        {
            var config = TestingAppSettings.GetTestSettings();

            var url = config["TestSettings:bbcBaseUrl"];
            var relativeUrl = url + page;

            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(relativeUrl);
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
        }

        public void OpenNavigateDojo(string login)
       {
           var config = TestingAppSettings.GetTestSettings();

           var url = config["TestSettings:DojoBaseUrl"];
           var relativeUrl = url + login;

           _driver.Navigate().GoToUrl(relativeUrl);
           _driver.SwitchTo().Window(_driver.WindowHandles.Last());
       }

        public void enterloginUserName(string username, string password)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor) _driver;

            _driver.FindElement(By.CssSelector("input#login-field.mdc-text-field__input")).SendKeys(username);
            _driver.FindElement(By.CssSelector("input#password-field.mdc-text-field__input")).SendKeys(password);
        }

        public void loginButton()
        {
            _driver.FindElement(By.CssSelector("button.mdc-button")).Click();
        }

        public void SearchTerm(string searchTerm)
        {
            _driver.FindElement(By.Id("ls-c-search__input-label")).SendKeys(searchTerm + Keys.Return);
            Thread.Sleep(1000);
            _driver.FindElements(By.CssSelector(".ls-o-location")).First().Click();

        }

        internal void displayscorrectvalue(string town)
        {
            var validTown = _driver.FindElement(By.Id("wr-location-name-id")).Text;
            Assert.AreEqual(town, validTown);
        }

        private void ClickLoginButton(By locator)
        {
           var loginButton = _driver.FindElement(By.CssSelector("button.mdc-button"));
           if (loginButton.Displayed)
           {
               loginButton.Click();
           }

           _driver.FindElement(locator).Click();
        }

        public void resetPassword()
        {
            _driver.FindElement(By.CssSelector("#resetPasswordButton")).Click();
        }

        public void resetEmailAddress(string email)
        {
            _driver.FindElement(By.CssSelector("input#emailInput")).SendKeys(email);
        }
    }
}