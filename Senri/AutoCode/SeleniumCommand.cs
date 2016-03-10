using System;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Senri.AutoCode
{
    class SeleniumCommand
    {
        /// <summary>
        /// CSS属性の検索
        /// </summary>
        /// <param name="element"></param>
        /// <param name="css"></param>
        /// <returns></returns>
        private static IWebElement FindElementsByCssSelector(IWebElement element, string css)
        {
            return element.FindElement(By.CssSelector(css));
        }
        private static IWebElement FineElementsByXpath(IWebElement element, string xpath)
        {
            return element.FindElement(By.XPath(xpath));
        }
        private static IWebElement FindElementsById(IWebElement element, string id)
        {
            return element.FindElement(By.Id(id));
        }
        private static IWebElement FineElementsByName(IWebElement element, string name)
        {
            return element.FindElement(By.Name(name));
        }
    }
}
