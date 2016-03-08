using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

// ドライバの用意
IWebDriver driver = new InternetExplorerDriver();

public void if_drink()
{
    IWebElement element;
    // 暗黙的なウェイト
    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
    //明示的にウェイトをかけるために実体を作る
    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
    // webpegeを表示
    driver.Navigate().GoToUrl("http://www.infomart.co.jp/scripts/logon.asp");
    // ID入力欄取得＆入力
    element = driver.FindElement(By.CssSelector("input[name='UID']"));
    element.Clear();
    element.SendKeys("06-6990-1010");
    // pass入力
    element = driver.FindElement(By.CssSelector("input[id='ID_PWD']"));
    element.Clear();
    element.SendKeys("EZG2kpe4");
    // ログインボタンクリック
    //wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[name='Logon']")));
    element = driver.FindElement(By.CssSelector("input[name='Logon']"));
    element.Submit();
    // そのまま取引ダウンロードにいくと取引先グループに取引先が出ないため一回マイページをクリック
    element = driver.FindElement(By.CssSelector("#lnkPg"));
    element.Click();
    // 取引ダウンロードクリック
    element = driver.FindElement(By.LinkText("取引ダウンロード"));
    element.Click();
    // 日付入力チェックボックスにチェックを入れる
    if (driver.FindElement(By.Id("sel_date0_ptn1")).Selected)
    {
        driver.FindElement(By.Id("sel_date0_ptn1")).Click();
    }
    DateTime dtVar = DateTime.Today;
    dtVar = dtVar.AddDays(1);
    // ファースト
    element = driver.FindElement(By.Id("f_date"));
    element.Clear();
    element.SendKeys(dtVar.ToString("yyyy/MM/dd"));

    // ラスト
    element = driver.FindElement(By.Id("t_date"));
    element.Clear();
    element.SendKeys(dtVar.ToString("yyyy/MM/dd"));
    //取引先グループ選択
    driver.FindElement(By.XPath("//div[@id='downloadPattern1']/div[4]/table/tbody/tr[10]/td/div/span/span[2]/a/span")).Click();
    // フレームの切り替え
    wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("__modal"));
    //element = driver.FindElement(By.XPath("//div[2]/div/div/div[2]/div/form/table[1]/tbody/tr/td/div/span[1]/span/input"));
    element = driver.FindElement(By.CssSelector("#keyword"));
    element.Click();
    element.Clear();
    element.SendKeys("407400");
    element = driver.FindElement(By.CssSelector("span.bt-label"));
    element.SendKeys(Keys.Enter);
    element = driver.FindElement(By.CssSelector("#('407400', 'くら寿司'"));
    element.SendKeys(Keys.Enter);
    //driver.Quit();
}