using NUnit.Framework;
using OpenQA.Selenium;
using Shufersal;
using OpenQA.Selenium.Chrome;
using System.Web;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections.Generic;

namespace Britanika_Shufersal
{
    public class Tests
    {
        public IWebDriver driver = null;
        public string btowser = "Chrome";
        public string URL = "https://www.shufersal.co.il/";
        public string ProductName = "חלב";
        float expectedlowertprice = 35.50f;
        [SetUp]
        public void Setup()
        {            
            ChooseWebDriver setdriver = new ChooseWebDriver(this.btowser);
            this.driver = setdriver.GetDriver();
            OpenHomePage homepage = new OpenHomePage(this.driver);
            this.driver = homepage.NavigateToHomePage(this.URL);
        }

        [Test]
        public void Test1()
        {
            SearchForProduct mysearch = new SearchForProduct(this.driver);
            IWebElement ShowBox = mysearch.ShowSearchBox();
            ShowBox.Click();
            IWebElement OpenSearch = mysearch.FindSearchBox();
            OpenSearch.Click();
            OpenSearch.SendKeys(this.ProductName);
            FindAllElements allelements = new FindAllElements(this.driver);
            Dictionary<int, List<string>> dataresult = allelements.FindAllProducts();
            FindTheChipestone cheep = new FindTheChipestone();
            List<string> chipest = cheep.FindChipestItem(dataresult);
            AddToChartLowest chart = new AddToChartLowest(this.driver);
            chart.AddToChart(chipest);

            GetFinalPrice final = new GetFinalPrice(this.driver);
            
            float finalprice = final.returnfinalprice();


            Assert.AreEqual(expectedlowertprice, finalprice,0.001,"The Price is not Equal");
        }
        [TearDown]
        public void TearDown()
        {
            this.driver.Close();
        }
    }
}