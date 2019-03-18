using TechTalk.SpecFlow;

namespace TestWebProject.Webdriver
{
    [Binding]
    public class BaseTest
    {
        protected static Browser Browser;

        [BeforeFeature]
        public static void SetupTest()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximise();
            Browser.NavigateTo(Configuration.BaseUrl);
        }

        [AfterFeature]
        public static void CleanUp()
        {
            Browser.Quit();
        }
    }
}
