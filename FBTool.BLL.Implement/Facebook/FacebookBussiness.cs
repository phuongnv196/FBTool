using FBTool.BLL.Interface.Facebook;
using FBTool.Domain.Constants;
using FBTool.Domain.Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FBTool.Domain.Extensions;

namespace FBTool.BLL.Implement.Facebook
{
    public class FacebookBussiness: IFacebookBussiness
    {
        private readonly IWebDriver _webDriver;

        public FacebookBussiness()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            _webDriver = new ChromeDriver(chromeDriverService, new ChromeOptions());
        }

        public void Close()
        {
            _webDriver.Quit();
        }

        public void Login(FacebookAccount facebookAccount)
        {
            _webDriver.Url = FacebookURL.LOGIN_URL;
            _webDriver.Wait(By.Id("input[name=email]"))?.SendKeys(facebookAccount.Username);
            _webDriver.Wait(By.CssSelector("input[name=pass]"))?.SendKeys(facebookAccount.Password);
            _webDriver.Wait(By.CssSelector("input[name=login]"))?.Click();
        }
    }
}
