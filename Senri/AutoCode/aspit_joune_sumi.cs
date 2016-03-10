using System;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Windows.Automation;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Senri.AutoCode
{
    class aspit_joune_sumi
    {
        // ドライバの用意
        IWebDriver driver = new InternetExplorerDriver();
        public void sumi()
        {
            IWebElement element;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // webpegeを表示
            driver.Navigate().GoToUrl("https://www.f-aspit.com/aspit/portal/login.asp");
            driver.FindElement(By.Name("KigyoCD")).SendKeys("99990005");
            driver.FindElement(By.Name("UserID")).SendKeys("goen9995");
            driver.FindElement(By.Name("Password")).SendKeys("354959");
            driver.FindElement(By.CssSelector("img[id='img01']")).Click();

            driver.SwitchTo().Frame("fraNews");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("btnMenu0")));
            element = driver.FindElement(By.Name("btnMenu0"));
            element.SendKeys(Keys.Enter);
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Name("btnMenu0")));
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("main"));
            element = driver.FindElement(By.LinkText("受注照会"));
            element.SendKeys(Keys.Enter);
            driver.FindElement(By.Name("selFromDay")).Click();
            driver.FindElement(By.XPath("//span[@id='idTargetKikanArea_From_Day']/select//option[1]")).Click();
            driver.FindElement(By.Id("imgDownload")).Click();
            //ここにダウンロード処理を入れる
            driver.Quit();
        }
    }
}
