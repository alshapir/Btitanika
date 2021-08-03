using System;
using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Web;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Interactions;
//using Nest;

namespace Shufersal
{
    public class RepresentData
        {
        public string key
        {
            get { return key; }
            set { this.key = key; }
        }
         
        public string Quantity
        {
            get { return Quantity; }
            set { this.Quantity = Quantity; }
        }
        public string price
        {
            get { return price; }
            set { this.price = price; }
        }
        public string ID
        {
            get { return ID; }
            set { this.ID = ID; }
        }
        public string X
        {
            get { return X; }
            set { this.X = X; }
        }
        public string Y
        {
            get { return Y; }
            set { this.Y = Y; }
        }
    }

    public class FindAllElements
    {
        public IReadOnlyCollection<IWebElement> ProductDatatlist = null;
        public IReadOnlyCollection<IWebElement> AddToChartlist = null;
        public Dictionary<int, List<string>> CombinedData = new Dictionary<int, List<string>>();
        public IWebDriver driver = null;
        public FindAllElements(IWebDriver driver)
        {
            if(driver != null)
            {
                this.driver = driver;
            }
        }

        public Dictionary<int, List<string>> FindAllProducts()
        {   
            By contentlocator = By.XPath("//div[@class='tile row miglog-prod miglog-sellingmethod-by_unit tt-suggestion tt-selectable']");
            IReadOnlyCollection <IWebElement> content = this.driver.FindElements(contentlocator);
            
            
            By addtochartlocator = By.XPath("//form[@class='addToCart touchSpinContainer col-xs-12 col-lg-4 js-add-to-cart-form initialized']");
            AddToChartlist = this.driver.FindElements(addtochartlocator);

          
            List<string> Content = new List<string>();
            List<string> AddToChar = new List<string>();

            int icount = content.Count;
            foreach (IWebElement Cont in content)
            {
                
                string text = Cont.Text;
                string[] selectprice = null;
                string key = String.Empty;
               
               if (icount == content.Count/2)
                {
                    By outputlocator = By.XPath("//*[@id='js-site-search-input']");
                    IWebElement output = this.driver.FindElement(outputlocator);
                    for(int i = 1; i < 4; i++)
                    {
                        output.SendKeys(Keys.ArrowDown);
                    }
                }
                if (!String.IsNullOrEmpty(text))
                  {
                    char[] delemeter = { '\r', '\n', };
                    string[] parcecontt = text.Split(delemeter);
                    if (parcecontt.Length < 11)
                    {
                        selectprice = parcecontt[4].Split(' ');
                        
                    }
                    else
                    {
                        selectprice = parcecontt[8].Split(' ');
                       
                    }
                    string total = parcecontt[0].ToString()+ " " + parcecontt[4].ToString() + " " + selectprice[0].ToString();
                    Content.Add(total);
                   
                  }
                icount--;
            }

            foreach (IWebElement chart in AddToChartlist)
            {
                System.Drawing.Point chartpoint = chart.Location;
                char[] delemeter3 = { '{', '=', '}', ',' };
                string strpoint = chartpoint.ToString();
                string[] parsepoint = strpoint.Split(delemeter3);

                char[] delemeter2 = { '(', '=', ')' };
                string partsechart = chart.ToString();
                string[] parsechart = partsechart.Split(delemeter2);
                string id = parsechart[2];
                string t1 = parsepoint[1].ToString() + ": " + parsepoint[2].ToString() + " " + parsepoint[3].ToString() + ": " + parsepoint[4].ToString();
                string total = "id: " + id.ToString() + " " + t1;
                AddToChar.Add(total);
            }
            for(int i = 0; i < Content.Count; i++)
            {
                //RepresentData mydata = new RepresentData();
                List<string> mydata = new List<string>();
                string[] position = AddToChar[i].Split(' ');
                string[] parsecontent = Content[i].Split(' ');
                string key = parsecontent[0].ToString() + " " + parsecontent[1].ToString() + " " + parsecontent[2].ToString() + " " + parsecontent[3].ToString() + " " + parsecontent[4].ToString() + " " + parsecontent[5].ToString();
                mydata.Add(key);
                string Quantity = parsecontent[3].ToString() + " " + parsecontent[4].ToString() + " " + parsecontent[5].ToString();
                mydata.Add(Quantity);
                string price = parsecontent[parsecontent.Length - 1].ToString();
                mydata.Add(price);
                string ID = position[2].ToString();
                mydata.Add(ID);
                string X = position[4].ToString();
                mydata.Add(X);
                string Y = position[6].ToString();
                mydata.Add(Y);
                CombinedData[i] = mydata;
            }
            return this.CombinedData;
        }

    }
}
