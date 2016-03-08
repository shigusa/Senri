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
            SeveFileDialog();
            driver.Quit();
        }
        private static readonly int DEFAULT_WAIT_TIME = 1000;
        public void SeveFileDialog()
        {
            AutomationElement root = AutomationElement.RootElement;
            AutomationElement IE = root.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "受注照会 - Windows Internet Explorer"));
            if (IE != null)
            {
                Thread.Sleep(DEFAULT_WAIT_TIME);
                // 名前を付けて保存をクリック
                var SeveAsClick = FindElementsByAccKey(IE, "Alt+A").First().GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                SeveAsClick.Invoke();
                Thread.Sleep(DEFAULT_WAIT_TIME);
                // 保存場所の変更
                var NameKeyN = FindEditByName(IE, "ファイル名:").First().GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                NameKeyN.SetValue(@"\\tosk01\EOS\情熱ホルモン炭.csv");
                // 保存ボタンのクリック
                var SeveButtonClick = FindElementsByAccKey(IE, "Alt+S").First().GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                SeveButtonClick.Invoke();
                Thread.Sleep(DEFAULT_WAIT_TIME);
                var SeveOverW = FindElementsByName(IE, "名前を付けて保存の確認").First();
                if (SeveOverW != null)
                {
                    var OverWYes = FindElementsByAccKey(IE, "Alt+Y").First().GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                    OverWYes.Invoke();
                }
            }
        }
        // 指定したName属性に一致するAutomationElementをすべて返します
        private static IEnumerable<AutomationElement> FindElementsByName(AutomationElement rootElement, string name)
        {
            return rootElement.FindAll(
                TreeScope.Element | TreeScope.Descendants,
                new PropertyCondition(AutomationElement.NameProperty, name))
                .Cast<AutomationElement>();
        }
        // 指定したName属性に一致するボタン要素をすべて返します
        private static IEnumerable<AutomationElement> FindButtonsByName(AutomationElement rootElement, string name)
        {
            const string BUTTON_CLASS_NAME = "Button";
            return from x in FindElementsByName(rootElement, name)
                   where x.Current.ClassName == BUTTON_CLASS_NAME
                   select x;
        }
        /// <summary>
        /// 指定したName属性に一致するエディットテキスト要素を全て返します
        /// </summary>
        /// <param name="rootElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private static IEnumerable<AutomationElement> FindEditByName(AutomationElement rootElement, string name)
        {
            const string EDIT_CLASS_NAME = "Edit";
            return from x in FindElementsByName(rootElement, name)
                   where x.Current.ClassName == EDIT_CLASS_NAME
                   select x;
        }
        /// <summary>
        /// 指定したID属性に一致するAutomationElementを返します
        /// </summary>
        /// <param name="rootElement"></param>
        /// <param name="automationId"></param>
        /// <returns></returns>
        private static AutomationElement FindElementById(AutomationElement rootElement, string automationId)
        {
            return rootElement.FindFirst(
                TreeScope.Element | TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, automationId));
        }
        /// <summary>
        /// 指定したAccessKey属性に一致するAutomationElementを返します
        /// </summary>
        /// <param name="rootElement"></param>
        /// <param name="acckey"></param>
        /// <returns></returns>
        private static IEnumerable<AutomationElement> FindElementsByAccKey(AutomationElement rootElement, string acckey)
        {
            return rootElement.FindAll(
                TreeScope.Element | TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AccessKeyProperty, acckey))
                .Cast<AutomationElement>();
        }
    }
}
