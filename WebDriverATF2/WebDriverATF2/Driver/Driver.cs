using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverATF2.Driver
{
    class Driver
    {
        private static IWebDriver driver;
        private static WebDriverWait wait;

        private Driver() { }
        
        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = new OpenQA.Selenium.Chrome.ChromeDriver();
                driver.Manage().Window.Size = new System.Drawing.Size(driver.Manage().Window.Size.Width / 2, driver.Manage().Window.Size.Height);
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
            }
            return driver;
        }

        public static WebDriverWait GetWait()
        {
            return wait;
        }

        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
    }
}
