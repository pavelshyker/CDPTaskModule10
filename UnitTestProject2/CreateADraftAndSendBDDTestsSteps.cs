using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestWebProject.Pages;
using TestWebProject.Webdriver;
using TestWebProject.BO;

namespace TestWebProject
{
    [Binding]
    public class CreateADraftAndSendBDDTestsSteps: BaseTest
    {
        private StartPage startPage;
        private EmailPage emailPage;
        private SentPage sentPage;

        private string name = " testuser.19";
        private string password = "testCDP123";

        [Given(@"I logged as a test user")]
        public void GivenILoggedAsATestUser()
        {
            startPage = new StartPage();
            startPage.Login(new User(name, password));
        }

        [Given(@"^I (?:have created|created|create) a new email on the start page with (.*) and (.*) and (.*)")]
        public void GivenIHaveCreatedANewEmailOnTheStartPageWithAndAnd(string emailAddress,string emaiSubject,string emailText)
        {
            new InboxPage().GoToNewEmailPage();
            emailPage = new EmailPage();
            emailPage.CreateANewEmail(new Email(emailAddress,emaiSubject,emailText));
        }

        [Given(@"^I (?:have navigated|navigated|navigate) to the Send email page and deleted all")]
        public void GivenIHaveNavigatedToTheSendEmailPageAndDeletedAll()
        {
            new InboxPage().GoToSentPage();
            sentPage = new SentPage();
            sentPage.DeleteAllSent();
           // sentPage.GoToNewEmailPage();
        }

        [Given(@"^I (?:have created|created|create) a new email with (.*) and (.*) and (.*)")]
        public void GivenIHaveCreatedANewEmailWithAndAnd(string emailAddress,string emaiSubject,string emailText)
        {
            sentPage = new SentPage();
            sentPage.GoToNewEmailPage();
            emailPage = new EmailPage();
            emailPage.CreateANewEmail(new Email(emailAddress,emaiSubject,emailText));
        }

        [Given(@"^I (?:have saved|saved|save) it as a draft")]
        public void GivenISavedItAsADraft()
        {
            emailPage = new EmailPage();
            emailPage.SaveAsADraft();
        }

        [When(@"^I (?:have saved|saved|save) it as a draft")]
        public void WhenISavedItAsADraft()
        {
            emailPage = new EmailPage();
            emailPage.SaveAsADraft();
        }

        [When(@"^I (?:have sent|sent|sand) a draft email")]
        public void WhenISentADraftEmail()
        {
            emailPage = new EmailPage();
            emailPage.SendEmail();
        }

        [Then(@"The email is saved to the draft page")]
        public void ThenTheEmailIsSavedToTheDraftPage()
        {
            emailPage = new EmailPage();
            emailPage.GoToDraftPage();
            Assert.AreEqual("litmarsd@mail.ru", new DraftPage().GetEmailAddress());
        }

        [Then(@"The email is sent")]
        public void ThenTheEmailIsSent()
        {
            emailPage.GoToSentPage();
            sentPage = new SentPage();
            Assert.IsTrue(sentPage.SentEmailExist());
        }
    }
}
