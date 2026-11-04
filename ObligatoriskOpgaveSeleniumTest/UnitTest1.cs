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

            IWebElement usernameInput = driver.FindElement(By.Id("username"));
            usernameInput.SendKeys("admin");
            IWebElement passwordInput = driver.FindElement(By.Id("password"));
            passwordInput.SendKeys("1234");
            IWebElement loginButton = driver.FindElement(By.Id("loginButton"));
            loginButton.Click();
            System.Threading.Thread.Sleep(1000); // Wait for 1 second

            Assert.Equal("Records", driver.Title);

            IWebElement getAllButton = driver.FindElement(By.Id("getAllButton"));
            getAllButton.Click();
            System.Threading.Thread.Sleep(2000); // Wait for 2 seconds

            IWebElement table = driver.FindElement(By.Id("table"));
            Assert.NotNull(table);
            Assert.Equal(6, table.FindElements(By.TagName("tr")).Count); // 6 rows: header, and 5 data rows

        }

        [Fact]
        public void GetByIdTest_TitleFilter()
        {
            //Arrange
            //IWebDriver driver = new ChromeDriver(driverPath);
            IWebDriver driver = new EdgeDriver(driverPath);
            driver.Navigate().GoToUrl(url);

            IWebElement usernameInput = driver.FindElement(By.Id("username"));
            usernameInput.SendKeys("admin");
            IWebElement passwordInput = driver.FindElement(By.Id("password"));
            passwordInput.SendKeys("1234");
            IWebElement loginButton = driver.FindElement(By.Id("loginButton"));
            loginButton.Click();
            System.Threading.Thread.Sleep(1000); // Wait for 1 second

            //Act

            //Assert
            Assert.Equal("Records", driver.Title);

            //Act
            IWebElement filterInput = driver.FindElement(By.Id("filterInput"));
            filterInput.SendKeys("Song 1");
            IWebElement filterByTitleButton = driver.FindElement(By.Id("filterByTitleButton"));
            filterByTitleButton.Click();
            System.Threading.Thread.Sleep(2000); // Wait for 2 seconds

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

            driver.Navigate().GoToUrl(url);

            //Act          
            IWebElement usernameInput = driver.FindElement(By.Id("username"));
            usernameInput.SendKeys("admin");
            IWebElement passwordInput = driver.FindElement(By.Id("password"));
            passwordInput.SendKeys("1234");
            IWebElement loginButton = driver.FindElement(By.Id("loginButton"));
            loginButton.Click();
            System.Threading.Thread.Sleep(1000); // Wait for 1 second

            //Assert
            Assert.Equal("Records", driver.Title);
            //Act
            IWebElement filterInput = driver.FindElement(By.Id("filterInput"));
            filterInput.SendKeys("Artist 1");
            IWebElement filterByArtistButton = driver.FindElement(By.Id("filterByArtistButton"));
            filterByArtistButton.Click();
            System.Threading.Thread.Sleep(2000); // Wait for 2 seconds
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

            driver.Navigate().GoToUrl(url);

            //Act
            IWebElement usernameInput = driver.FindElement(By.Id("username"));
            usernameInput.SendKeys("admin");
            IWebElement passwordInput = driver.FindElement(By.Id("password"));
            passwordInput.SendKeys("1234");
            IWebElement loginButton = driver.FindElement(By.Id("loginButton"));
            loginButton.Click();
            System.Threading.Thread.Sleep(1000); // Wait for 1 second

            //Assert
            Assert.Equal("Records", driver.Title);
            //Act
            IWebElement filterInput = driver.FindElement(By.Id("filterInput"));
            filterInput.SendKeys("200");
            IWebElement FilterByDurationButton = driver.FindElement(By.Id("filterByDurationButton"));
            FilterByDurationButton.Click();
            System.Threading.Thread.Sleep(2000); // Wait for 2 seconds
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

            driver.Navigate().GoToUrl(url);

            //Act
            IWebElement usernameInput = driver.FindElement(By.Id("username"));
            usernameInput.SendKeys("admin");
            IWebElement passwordInput = driver.FindElement(By.Id("password"));
            passwordInput.SendKeys("1234");
            IWebElement loginButton = driver.FindElement(By.Id("loginButton"));
            loginButton.Click();
            System.Threading.Thread.Sleep(1000); // Wait for 1 second



            //Assert
            Assert.Equal("Records", driver.Title);
            //Act
            IWebElement filterInput = driver.FindElement(By.Id("filterInput"));
            filterInput.SendKeys("2020");
            IWebElement FilterByPublicationYear = driver.FindElement(By.Id("filterByPublicationYearButton"));
            FilterByPublicationYear.Click();
            System.Threading.Thread.Sleep(2000); // Wait for 2 seconds
            //Assert
            IWebElement table = driver.FindElement(By.Id("table"));
            Assert.NotNull(table);
            Assert.Equal(2, table.FindElements(By.TagName("tr")).Count); // 2 rows: header and 1 data row
            Assert.Contains("2020", table.Text);
        }

        [Fact]
        public void LoginTest()
        {
            //Arrange
            //IWebDriver driver = new ChromeDriver(driverPath);
            IWebDriver driver = new EdgeDriver(driverPath);
            //Act
            driver.Navigate().GoToUrl(url);
            //Assert
            Assert.Equal("Records", driver.Title);
            //Act
            IWebElement usernameInput = driver.FindElement(By.Id("username"));
            usernameInput.SendKeys("admin");
            IWebElement passwordInput = driver.FindElement(By.Id("password"));
            passwordInput.SendKeys("1234");
            IWebElement loginButton = driver.FindElement(By.Id("loginButton"));
            loginButton.Click();
            //Assert
            System.Threading.Thread.Sleep(2000); // Wait for 2 seconds
            IWebElement welcomeMessage = driver.FindElement(By.Id("welcomeMessage"));
            Assert.NotNull(welcomeMessage);
            Assert.Contains("Welcome, admin you are logged in!", welcomeMessage.Text);
        }

        [Fact]
        public void AddRecordTest()
        {
            //Arrange
            //IWebDriver driver = new ChromeDriver(driverPath);
            IWebDriver driver = new EdgeDriver(driverPath);
            //Act
            driver.Navigate().GoToUrl(url);
            //Assert
            Assert.Equal("Records", driver.Title);
            //Act
            IWebElement usernameInput = driver.FindElement(By.Id("username"));
            usernameInput.SendKeys("admin");
            IWebElement passwordInput = driver.FindElement(By.Id("password"));
            passwordInput.SendKeys("1234");
            IWebElement loginButton = driver.FindElement(By.Id("loginButton"));
            loginButton.Click();
            System.Threading.Thread.Sleep(2000); // Wait for 2 seconds

            IWebElement titleInput = driver.FindElement(By.Id("titleInput"));
            titleInput.SendKeys("New Song");
            IWebElement artistInput = driver.FindElement(By.Id("artistInput"));
            artistInput.SendKeys("New Artist");
            IWebElement durationInput = driver.FindElement(By.Id("durationInput"));
            durationInput.SendKeys("300");
            IWebElement yearInput = driver.FindElement(By.Id("publicationYearInput"));
            yearInput.SendKeys("2023");

            IWebElement addButton = driver.FindElement(By.Id("addButton"));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("window.scrollIntoView({block:'center'});", addButton);

            addButton.Click();
            System.Threading.Thread.Sleep(2000); // Wait for 2 seconds

            IWebElement table = driver.FindElement(By.Id("table"));
            Assert.Contains("New Song", table.Text);
            Assert.Contains("New Artist", table.Text);
            Assert.Contains("300", table.Text);
            Assert.Contains("2023", table.Text);
            Assert.Equal(6, table.FindElements(By.TagName("tr")).Count); // 5 rows: header and 4 data rows
        }
    }
}
