using MarsFramework.Config;
using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace MarsFramework.Pages
{
    public class ShareSkillPage : PageBase
    {
        public ShareSkillPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select Hourly Basis service
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")]
        private IWebElement HourBasisOption { get; set; }

        //Select location type as online

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")]
        private IWebElement OnlineLocationType { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }


        //Sunday 
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[1]/div/input")]
        private IWebElement Sunday { get; set; }

        // Sunday Start time
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[2]/input")]
        private IWebElement SundayStartTime { get; set; }


        //Monday
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input")]
        private IWebElement Monday { get; set; }


        //Sunday End time
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[3]/input")]
        private IWebElement SundayEndTime { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //Select credit for skill exchange 
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")]
        private IWebElement Credit { get; set; }

        //Skill Exchange button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")]
        private IWebElement SkillTradeExchange { get; set; }


        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        internal void EnterSkillDetails()
        {
            InitializeExcelData();

            Click(ShareSkillButton);

            EnterText(Title, GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            EnterText(Description, GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            SelectByTextFromDropDown(CategoryDropDown, GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            SelectByTextFromDropDown(SubCategoryDropDown, GlobalDefinitions.ExcelLib.ReadData(2, "SelectSubCategory"));

            EnterText(Tags, GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));

            PressEnterKey(Tags);

            SelectRadioButton(HourBasisOption);

            SelectRadioButton(OnlineLocationType);

            EnterText(StartDateDropDown, GlobalDefinitions.ExcelLib.ReadData(2, "StartDate"));
            EnterText(EndDateDropDown, GlobalDefinitions.ExcelLib.ReadData(2, "EndDate"));

            for (int i = 2; i < 4; i++)
            {
                SelectWeekDayAndTime(GlobalDefinitions.ExcelLib.ReadData(i, "SelectDay"), GlobalDefinitions.ExcelLib.ReadData(i, "StartTime"), GlobalDefinitions.ExcelLib.ReadData(i, "EndTime"));
            }

            SelectRadioButton(SkillTradeExchange);

            EnterText(SkillExchange, GlobalDefinitions.ExcelLib.ReadData(2, "SkillExchange"));
            PressEnterKey(SkillExchange);

            Click(ActiveOption);

            Click(Save);

        }

        private void SelectWeekDayAndTime(string dayToSelect, string startTime, string endTime)
        {

            for (int i = 0; i < 6; i++)
            {
                IList<IWebElement> AvailabilityElements = _driver.FindElements(By.CssSelector($"input[index='{i}']"));

                foreach (var availability in AvailabilityElements)
                {
                    var elementAttribute = availability.GetAttribute("Name");
                    if (elementAttribute.Equals("Available") && !availability.Selected)
                    {
                        availability.Click();
                    }
                    if (elementAttribute.Equals("StartTime"))
                    {
                        availability.SendKeys(startTime);

                    }
                    if (elementAttribute.Equals("EndTime"))
                    {
                        availability.SendKeys(endTime);
                        break;
                    }
                }
                i++;
            }
        }









        internal void EditShareSkill()
        {

        }


        public void InitializeExcelData()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(MarsResource.ExcelPath, "ShareSkill");
        }
    }
}
