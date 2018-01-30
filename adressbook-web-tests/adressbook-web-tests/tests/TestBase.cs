using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class TestBase
    {
        //protected IWebDriver driver;
        //private StringBuilder verificationErrors;
        //protected string baseURL;

        //protected LoginHelper loginHelper;
        //protected NavigationHelper navigator;
        //protected GroupHelper groupHelper;
        //protected ContactHelper contactHelper;

        protected ApplicationManager app;


        [SetUp]
        public void SetupTest()
        {



            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();

            app = new ApplicationManager();

            //loginHelper = new LoginHelper(driver);
            //navigator = new NavigationHelper(driver, baseURL);
            //groupHelper = new GroupHelper(driver);
            //contactHelper = new ContactHelper(driver);
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();

        }        
    }
}
