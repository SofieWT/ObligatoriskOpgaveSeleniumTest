using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace ObligatoriskOpgaveSeleniumTest
{
    public class UnitTest1
    {
        private static readonly string driverPath = "C:\\WebDrivers";
        //string url = "https://localhost:7171/index.html";
        //string url = "http://localhost:5197/Index.html";
        string url = "http://127.0.0.1:5501/Index.html";

        [Fact]
        public void GetAllTest()
        {
            //IWebDriver driver = new ChromeDriver(driverPath);
            IWebDriver driver = new EdgeDriver(driverPath);

            driver.Navigate().GoToUrl(url);

            Assert.Equal("Records", driver.Title);

            IWebElement getAllButton = driver.FindElement(By.Id("getAllButton"));
            getAllButton.Click();

            IWebElement table = driver.FindElement(By.Id("table"));
            Assert.NotNull(table);
            Assert.Equal(3, table.FindElements(By.TagName("tr")).Count); // 3 rows: header, and 2 data rows

        }
    }
}
