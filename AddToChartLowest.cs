using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Web;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace Shufersal
{
    public class AddToChartLowest
    {
        public IWebDriver driver;
        public AddToChartLowest(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void AddToChart(List<string> lowest)
        {
            string X = lowest[4];
            string Y = lowest[5];
            int x = 0;
            int y = 0;
            Int32.TryParse(X, out x);
            Int32.TryParse(Y, out y);
            By buttonlocator = By.XPath("//*[@id='mCSB_3_container']/div[2]/div[8]/div/form/button[2]");
            IWebElement button = this.driver.FindElement(buttonlocator);
            button.Click();
            //Actions action = new Actions(this.driver);
            //action.MoveToElement(this.driver.FindElement(By.XPath("//*[@id='mCSB_3_container']/div[2]/div[3]/div/form/button[2]")), 0, 0);
            //action.MoveByOffset(x, y).Click().Build().Perform();
            By cancellocator = By.XPath("//*[@id='assortmentModal']/div/div[1]/button");
            IWebElement cancel = this.driver.FindElement(cancellocator);
            cancel.Click();
            //Actions act = new Actions(this.driver);
            //act.MoveToElement(button).MoveByOffset(x, y).Click().Perform();

        }
    }
}
