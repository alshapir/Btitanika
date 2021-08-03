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
    public class GetFinalPrice
    {
        IWebDriver driver;
        public GetFinalPrice(IWebDriver driver)
        {
            this.driver = driver;
        }

        public float returnfinalprice()
        {
            float final = 0.0f;
            Thread.Sleep(8000);
            By finalpricelocator = By.XPath("//*[@id='cartContainer']/div/div/footer/div[2]/div/div/div[1]/span");
            IWebElement finalprice = this.driver.FindElement(finalpricelocator);
            
            string strprice = finalprice.Text;
            char[] delemeter = { '\r', '\n', '₪' };
            string[] parseprice = strprice.Split(delemeter);
            string price = parseprice[parseprice.Length-1];
            float.TryParse(price, out final);
            return final;
        }
    }
}
