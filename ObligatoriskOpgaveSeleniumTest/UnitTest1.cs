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

        [Fact]
        public void GetByIdTest_TitleFilter()
        {
            //Arrange
            //IWebDriver driver = new ChromeDriver(driverPath);
            IWebDriver driver = new EdgeDriver(driverPath);

            //Act
            driver.Navigate().GoToUrl(url);
            //Assert
            Assert.Equal("Records", driver.Title);

            //Act
            IWebElement filterInput = driver.FindElement(By.Id("filterInput"));
            filterInput.SendKeys("Song 1");
            IWebElement filterByTitleButton = driver.FindElement(By.Id("filterByTitleButton"));
            filterByTitleButton.Click();

            //Assert
            IWebElement table = driver.FindElement(By.Id("table"));
            Assert.NotNull(table);
            Assert.Equal(2, table.FindElements(By.TagName("tr")).Count); // 2 rows: header and 1 data row
            Assert.Contains("Song 1", table.Text);
        }
        [Fact]
        public void GetAllRecords_ArtistFilter()
        {
            //Arrange
            //IWebDriver driver = new ChromeDriver(driverPath);
            IWebDriver driver = new EdgeDriver(driverPath);
            //Act
            driver.Navigate().GoToUrl(url);
            //Assert
            Assert.Equal("Records", driver.Title);
            //Act
            IWebElement filterInput = driver.FindElement(By.Id("filterInput"));
            filterInput.SendKeys("Artist 1");
            IWebElement filterByArtistButton = driver.FindElement(By.Id("filterByArtistButton"));
            filterByArtistButton.Click();
            //Assert
            IWebElement table = driver.FindElement(By.Id("table"));
            Assert.NotNull(table);
            Assert.Equal(2, table.FindElements(By.TagName("tr")).Count); // 2 rows: header and 1 data row
            Assert.Contains("Artist 1", table.Text);
        }

        [Fact]
        public void GetAllRecords_DurationFilter()
        {
            //Arrange
            //IWebDriver driver = new ChromeDriver(driverPath);
            IWebDriver driver = new EdgeDriver(driverPath);
            //Act
            driver.Navigate().GoToUrl(url);
            //Assert
            Assert.Equal("Records", driver.Title);
            //Act
            IWebElement filterInput = driver.FindElement(By.Id("filterInput"));
            filterInput.SendKeys("200");
            IWebElement FilterByDurationButton = driver.FindElement(By.Id("filterByDurationButton"));
            FilterByDurationButton.Click();
            //Assert
            IWebElement table = driver.FindElement(By.Id("table"));
            Assert.NotNull(table);
            Assert.Equal(2, table.FindElements(By.TagName("tr")).Count); // 2 rows: header and 1 data row
            Assert.Contains("200", table.Text);
        }


        [Fact]
        public void GetAllRecords_YearFilter()
        {
            //Arrange
            //IWebDriver driver = new ChromeDriver(driverPath);
            IWebDriver driver = new EdgeDriver(driverPath);
            //Act
            driver.Navigate().GoToUrl(url);
            //Assert
            Assert.Equal("Records", driver.Title);
            //Act
            IWebElement filterInput = driver.FindElement(By.Id("filterInput"));
            filterInput.SendKeys("2020");
            IWebElement FilterByPublicationYear = driver.FindElement(By.Id("filterByPublicationYearButton"));
            FilterByPublicationYear.Click();
            //Assert
            IWebElement table = driver.FindElement(By.Id("table"));
            Assert.NotNull(table);
            Assert.Equal(2, table.FindElements(By.TagName("tr")).Count); // 2 rows: header and 1 data row
            Assert.Contains("2020", table.Text);
        }


    }
}
