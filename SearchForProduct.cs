using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Web;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Shufersal
{
    public class SearchForProduct
    {
        public IWebDriver driver = null;
        public string ProductName = String.Empty;
        public string OpenSearchlocator = String.Empty;
        public SearchForProduct(IWebDriver driver)
        {
            if (driver != null)
            {
                this.driver = driver;
            }
        }
        public IWebElement ShowSearchBox()
        {
            //By ShowSearchBoxlocator = By.XPath("//figure[@class='imgWrapper']");
            //By ShowSearchBoxlocator = By.XPath("//*[@id='slick-slide81']/figure/a/img[1]");
            By ShowSearchBoxlocator = By.XPath("//*[@id='slick-slide83']/figure/a");
            IWebElement SearchBox = this.driver.FindElement(ShowSearchBoxlocator);
            return SearchBox;
        }
        public IWebElement FindSearchElement()
        {
            By OpenSearchlocator = By.XPath("//*[@id='slick-slide70']");
            IWebElement OpenSearchelement = null;
            OpenSearchelement  = this.driver.FindElement(OpenSearchlocator);
            return OpenSearchelement;
        }

        public IWebElement FindSearchBox()
        {
            //By searchboxlocator = By.XPath("//*[@id='js-site-search-input']");
            By searchboxlocator = By.XPath("//input[@class='textHolder js-typeahead-suggestions tt-input']");
            IWebElement searchboxelement = null;
            searchboxelement = this.driver.FindElement(searchboxlocator);
            return searchboxelement;
        }
        public IWebElement PressSubmit()
        {
            By submitbuttonlocator = By.XPath("//*[@id='formSearchSubmit']/fieldset/div/button");
            IWebElement searchbuttonlement = null;
            searchbuttonlement = this.driver.FindElement(submitbuttonlocator);
            return searchbuttonlement;
        }
    }
}
