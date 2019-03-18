using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestWebProject.Pages;
using TestWebProject.Webdriver;
using TestWebProject.BO;

namespace TestWebProject
{
    [Binding]
    public class LoginBddTestSteps: BaseTest
    {
        private StartPage startPage;

        //[Given(@"I navigate to the sign on page")]
        //public void GivenINavigateToTheSignOnPage()
        //{
        //    startPage = new StartPage();
        //}

        [When(@"I entered (.*) and (.*)")]
        public void WhenIEnteredTestuser_AndTestCDP(string name,string password)
        {
            startPage = new StartPage();
            startPage.Login(new User(name,password));
        }

        [Then(@"I should see my emailbox")]
        public void ThenIShouldSeeMyEmailbox()
        {
            Assert.IsTrue(startPage.LoginSuccessMarker());
        }
    }
}
