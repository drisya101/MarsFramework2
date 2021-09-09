using Excel.Log;
using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;

namespace MarsFramework
{
    [TestFixture]
    [Category("Sprint1")]
    class MarsTests : Base
    {
        ShareSkillPage _shareSkillPage;
        ManageListingsPage _manageListingsPage;
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = GlobalDefinitions.driver;
            ExtentReports();
            test = extent.StartTest(TestContext.CurrentContext.Test.FullName);
            _shareSkillPage = new ShareSkillPage(_driver);
            _manageListingsPage = new ManageListingsPage(_driver);
        }
        //Test Services listing

        [Test, Description("Test entering skill share data in share skill page"), Order(1)]
        public void TestEnterServiesListing()
        {
            _shareSkillPage.EnterSkillDetails();
            Assert.True(_manageListingsPage.IsListingActive(), "Adding a listing failed");
        }

        //Test view

        [Test, Description("Test user can view entered skill share data in manage listing page"), Order(2)]
        public void TestViewListedServices()
        {
            _manageListingsPage.NavigateToViewListedServices();
            Assert.AreEqual("This is a title", _manageListingsPage.GetViewPageTitle());
        }

        //Test Edit
        [Test, Description("Test user can edit entered skill share data in manage listing page"), Order(3)]
        public void TestEditServices()
        {
            var expectedTitle = "This is a edited title";
            _manageListingsPage.EditExistingService(expectedTitle);
            Assert.AreEqual(expectedTitle, _manageListingsPage.GetListingTitle());

        }


        //Test Delete
        [Test, Description("Test user can delete entered skill share data in manage listing page"), Order(4)]
        public void TestDeleteServices()
        {
            var expectedText = "You do not have any service listings!";
            _manageListingsPage.TestDeleteServices();
            Assert.AreEqual(expectedText, _manageListingsPage.NoServiceListing());

        }


    }
}