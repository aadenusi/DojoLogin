using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestingGoogle.PageObjModel
{
    public class SearchResultPage
    {
        private readonly IWebDriver _driver;

        public SearchResultPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement GetResult()
        {
            IWebElement test = _driver.FindElement(By.XPath("//*[@id='rso']/div[1]/div/div[1]/div/div/div[1]/a/h3"));
            return test;
        }
        
    }
}
