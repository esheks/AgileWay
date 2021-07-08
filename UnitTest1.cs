using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TraveAgileWay
{
    [TestClass]
    public class TravelAgileWayAutomation
    {
        IWebDriver driver;
       // Regression Test case 1: Book Return Flight - P1
        
        [TestMethod]
        public void SignInTravelAgileWay()
        {
            driver = new ChromeDriver(@"D:\Desktop\CHROME");
            // Step 1:Open travel.agileway.net
            driver.Manage().Window.Maximize();
            driver.Url = "https://travel.agileway.net";
            
            // Step 2: enter user id
            driver.FindElement(By.Id("username")).SendKeys("agileway");

            // Step 3: enter password
            driver.FindElement(By.Id("password")).SendKeys("testwise");

            // Step 4: Click login button
            driver.FindElement(By.Name("commit")).Click();

         
            string ExpectedUrl = "https://travel.agileway.net/flights/start";

            if (driver.Url.Contains(ExpectedUrl))
            {
                Console.WriteLine("travel agileway open successfully");

            }
            else
            {
                Console.WriteLine("travel agileway did not open successfully");

                Assert.Fail("travel agileway did not successfully; Error Page");
            }
            
           
            
            
            // Step 5: Click on origin
            var origin = driver.FindElement(By.Name("fromPort"));

            var SelectOrigin = new SelectElement(origin);
            SelectOrigin.SelectByText("New York");

            // Step 6: Destination

            var destination = driver.FindElement(By.Name("toPort"));

            var Selectdestination = new SelectElement(destination);
            Selectdestination.SelectByText("Sydney");

            //Step 7: departing day
            var day= driver.FindElement(By.Id("departDay"));

            var Selectday = new SelectElement(day);
            Selectday.SelectByIndex(04);

            //step 8: departing month
            var month = driver.FindElement(By.Id("departMonth"));

            var Selectmonth = new SelectElement(month);
            Selectmonth.SelectByValue("032016");

            //step 9 returning day
            
            var Returnday = driver.FindElement(By.Id("returnDay"));

            var SelectReturnday = new SelectElement(Returnday);
            SelectReturnday.SelectByIndex(03);

            //10 return month
            var returnMonth = driver.FindElement(By.Id("returnMonth"));

            var SelectReturnmonth = new SelectElement(returnMonth);
            SelectReturnmonth.SelectByValue("092016");

            // 11 continue
            driver.FindElement(By.XPath("//*[@id='container']/form/input")).Click();

            string Url = "https://travel.agileway.net/flights/select_date?tripType=return&fromPort=New+York&toPort=Sydney&departDay=05&departMonth=032016&returnDay=04&returnMonth=092016";

            if (driver.Url.Contains(Url))
            {
                Console.WriteLine("passenger details open successfully");

            }
            else
            {
                Console.WriteLine("passenger details did not open successfully");

                Assert.Fail("passenger details did not successfully; Error Page");
            }

            
            
            
            // step 12 enter passenger details

            driver.FindElement(By.Name("passengerFirstName")).SendKeys("vincent");

            driver.FindElement(By.Name("passengerLastName")).SendKeys("jerry");

            // step 13 click next

            driver.FindElement(By.XPath("//*[@id='container']/form/input[3]")).Click();

            string UrlLink = "https://travel.agileway.net/flights/passenger";

            if (driver.Url.Contains(UrlLink))
            {
                Console.WriteLine("payment open successfully");

            }
            else
            {
                Console.WriteLine("payment did not open successfully");

                Assert.Fail("payment did not successfully; Error Page");
            }

            // Step: 14 click card type
            driver.FindElement(By.XPath("//input[contains(@value,'master')]")).Click();

            // step:15 click card number
            driver.FindElement(By.Name("card_number")).SendKeys("234567890");

            
            // step: 16 click on expiry date
            var ExpiryMonth = driver.FindElement(By.Name("expiry_month"));
            var SelectExpiryMonth = new SelectElement(ExpiryMonth);
            SelectExpiryMonth.SelectByValue("06");


            
            // step: 17 click on expiry date
            var ExpiryYear = driver.FindElement(By.Name("expiry_year"));
            var SelectExpiryyear = new SelectElement(ExpiryYear);
            SelectExpiryyear.SelectByValue("2018");


            // step 18: click paynow
            driver.FindElement(By.XPath("//input[contains(@value,'Pay now')]")).Click();

        }
    }
}
