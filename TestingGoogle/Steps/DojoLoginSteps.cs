using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using TestingGoogle.PageObjModel;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestingGoogle.Steps
{
    [Binding]
    [TestFixture (800)]
    class DojoLoginSteps
    {
        private readonly SearchResultPage _searchResultPage;
        private FirefoxDriver _driver;
        private HomePage _homePage;
        
        public DojoLoginSteps()
        {
            _driver = new FirefoxDriver(".");
            _homePage = new HomePage(_driver);
            _searchResultPage = new SearchResultPage(_driver);
        }

      
        [Given(@"I am on the (.*) page")]
        public void GivenIAmOnTheLoginPage(string login)
        {
            _homePage.OpenNavigateDojo(login);
        }

        [When(@"I enter a invalid (.*) with (.*)")]
        public void WhenIEnterAInValid(string username, string password)
        {
            _homePage.enterloginUserName(username, password);
        }

        [When(@"I click on the Loginbutton")]
        public void WhenIClickOnTheLoginbutton()
        {
            _homePage.loginButton();
        }

        [When(@"I click on the forgot your password link")]
        public void WhenIClickOnTheForgotYourPasswordLink()
        {
            _homePage.resetPassword(); ;
        }

        [When(@"I enter a valid (.*)")]
        public void WhenIEnterAValid(string email)
        {
            _homePage.resetEmailAddress(email);
        }

        [When(@"click on the email reset link")]
        public void WhenClickOnTheEmailResetLink()
        {
            _driver.FindElement(By.Id("emailPasswordResetLinkBtn")).Click();
        }

        [Then(@"the errorvalidation message (.*) is displayed")]
        public void ThenTheErrorValidationMessageEmailAndPasswordCombinationNotRecognisedIsDisplayed(string errorMessage)
        {
            var errorValidationMessage = _driver.FindElement(By.CssSelector("span.login-error")).Text;
            Assert.AreEqual(errorValidationMessage,errorMessage);
        }

        [Then(@"the emailerrorvalidation message (.*) is displayed")]
        public void ThenTheEmailerrorvalidationMessageEmailRequiredIsDisplayed(string emailerrorMessage)
        {
            var errorValidationMessage = _driver.FindElement(By.CssSelector(".mdc-text-field-helper-line")).Text;
            Assert.AreEqual(errorValidationMessage, emailerrorMessage);
        }

        [Then(@"a (.*) text is displayed")]
        public void ThenATextIsDisplayed(string resetConfirmation)
        {
            var passwordRestMessage = _driver.FindElement(By.ClassName("info")).Text;
            Assert.AreEqual(passwordRestMessage,resetConfirmation);
           
        }

        [Then(@"the email (.*) is displayed")]
        public void ThenTheEmailErrorvalidationMessageEmailRequiredIsDisplayed(string emailerrorMessage)
        {
            var errorValidationMessage = _driver.FindElement(By.CssSelector("span._ngcontent-gur-c3")).Text;
            Assert.AreEqual(errorValidationMessage, emailerrorMessage);
        }
    
        [When(@"I search for (.*)")]
        public void WhenISearchForExecuteAutomation(string searchTerm)
        {
            _homePage.SearchTerm(searchTerm);
        }


        [Then(@"I should see the result for keyword (.*)")]
        public void ThenIShouldSeeTheResultForKeyword(string Search)
        {
           var SearchResultPage = _searchResultPage.GetResult();
            var resultText = SearchResultPage.Text;
            Assert.AreEqual(Search, resultText);
        }

        [Given(@"I am on the bbc (.*)")]
        public void GivenIAmOnTheBbcHomepage(string relativePath)
        {
            _homePage.OpenNavigate(relativePath);
        }

        [When(@"I do a search for the term (.*)")]
        public void WhenIDoASearchForTheTermLondon(string town)
        {
           _homePage.SearchTerm(town);
        }

        [Then(@"the page is displayed with current (.*)")]
        public void ThenThePageIsDisplayedWithCurrentWeather(string town)
        {
            _homePage.displayscorrectvalue(town);
           
        }

        [After]
        public void tearDown()
        {
            _driver.Quit();

        }

    }
}
