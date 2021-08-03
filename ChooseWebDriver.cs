using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Web;
using OpenQA.Selenium.Support.UI;

namespace Shufersal
{
    public class ChooseWebDriver
    {
        public IWebDriver driver;
        private string browser;
        public  static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ChooseWebDriver(string BrowserName)
        {
            this.browser = BrowserName;
        }

        public IWebDriver GetDriver()
        {
                switch (this.browser.ToLower())
                {
                    case "chrome":
                    //C:\Alex\My_Projects\C#_Projects\Britanica\Shufewrsal\chromedriver_win32_92.0.4515.43\
                    driver = new ChromeDriver(@"C:/Alex/My_Projects/C#_Projects/Britanica/Shufewrsal/chromedriver_win32_92.0.4515.43/");
                        break;

                    default:
                        log.Info("No such Browser");
                        driver = null;
                        break;
                }
            driver.Manage().Window.Maximize();
            ITimeouts timeout = driver.Manage().Timeouts();
            timeout.ImplicitWait = TimeSpan.FromSeconds(50);            
            return driver;
        }

    }
}
