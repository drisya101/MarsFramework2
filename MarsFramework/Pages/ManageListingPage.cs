using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace MarsFramework.Pages
{
    internal class ManageListingsPage : PageBase
    {
        public ManageListingsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement ManageListings { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement View { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]")]
        private IWebElement Delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement Edit { get; set; }

        //Edit Title
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement EditTitle { get; set; }

        //Edit Description
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement EditDescription { get; set; }




        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        //Alter Box

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div")]
        private IWebElement AlertBox { get; set; }




        [FindsBy(How = How.Name, Using = "isActive")]
        private IWebElement ActiveCheckbox { get; set; }


        //Click Yes
        //[FindsBy(How = How.CssSelector, Using = "button.ui.icon.positive.right.labeled.button")]
        //private IWebElement ClickYes { get; set; }

        //Click Yes
        [FindsBy(How = How.XPath, Using = "//body[@class='dimmable dimmed']/div[2]//div[@class='actions']/button[2]")]
        private IWebElement ClickYes { get; set; }


        //Save button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]")]
        private IWebElement Savebutton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.active.section")]
        private IWebElement ViewListingTitleLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[3]")]
        private IWebElement EditedTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/h3")]
        private IWebElement NoServiceListed { get; set; }



        internal void NavigateToViewListedServices()
        {
            Click(ManageListings);
            Click(View);

        }



        internal void EditExistingService(string newTitle)
        {
            Click(ManageListings);
            Click(Edit);
            EnterText(EditTitle, newTitle);
            EnterText(EditDescription, "This is edited Description");
            Click(Savebutton);

        }

        internal void TestDeleteServices()
        {
            Click(ManageListings);
            Click(Delete);
            WaitAndFindElement(AlertBox);

            //Pop up box
            Click(ClickYes);

        }





        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");


        }

        //Check  Listing Active

        public bool IsListingActive()
        {
            return ActiveCheckbox.Enabled;
        }

        //View the Page Title
        public string GetViewPageTitle()
        {
            return GetText(ViewListingTitleLabel);
        }

        //Edit get the listing title
        public string GetListingTitle()
        {
            return GetText(EditedTitle);
        }

        //Delete get null
        public string NoServiceListing()
        {
            return GetText(NoServiceListed);
        }
    }
}
