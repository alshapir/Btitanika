using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Shufersal
{
    public class OpenHomePage
    {
      
       public string  browsername = String.Empty;
        public IWebDriver driver = null;
        public  static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public OpenHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebDriver NavigateToHomePage(string URL)
        {
            if (!String.IsNullOrEmpty(URL))
            {
                driver.Navigate().GoToUrl(URL);
                
            }
            else
            {
                log.Debug("The URL is Null Or Empty");
            }
            return driver;
        }
    }
}
