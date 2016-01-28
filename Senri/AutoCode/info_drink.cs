using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Senri.AutoCode
{
    class info_drink
    {
        public void if_drink()
        {
            //ドライバの用意
            IWebDriver driver = new InternetExplorerDriver();
            //webpegeを表示
            driver.Navigate().GoToUrl("http://www.infomart.co.jp/scripts/logon.asp");
            driver.Quit();
        }
    }
}
