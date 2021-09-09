using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    public class PageBase
    {
        public IWebDriver _driver;

        protected PageBase(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Click(IWebElement element)
        {
            WaitAndFindElement(element);
            element.Click();
        }

        public void SelectRadioButton(IWebElement element)
        {
            element.Click();
        }

        public void EnterText(IWebElement element, string text)
        {
            WaitAndFindElement(element);
            element.Click();
            element.Clear();
            element.SendKeys(text);
        }
        public void PressEnterKey(IWebElement element)
        {
            element.SendKeys(Keys.Enter);
        }

        public string GetText(IWebElement element)
        {
            return WaitAndFindElement(element).Text;
        }

        public void SelectByTextFromDropDown(IWebElement element, string textToSelect)
        {
            WaitAndFindElement(element);
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(textToSelect);

        }

        public IWebElement WaitAndFindElement(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            return wait.Until(ExpectedConditions.ElementToBeClickable(element));

        }

    }
}
