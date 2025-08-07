using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;


namespace WebAutomationProject.StepDefinitions
{
    [Binding]
    public class SearchSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver => _scenarioContext.Get<IWebDriver>("WebDriver");

        public SearchSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I navigate to ""(.*)""")]
        public void GivenINavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
            Thread.Sleep(5000);
        }

        [When(@"I click the address field ""(.*)""")]
        public void WhenIClickTheLookupField(string suggestedLocation)
        {
            var lookupElement = _driver.FindElement(By.XPath($"//a[normalize-space()='{suggestedLocation}']"));
            lookupElement.Click();
            Thread.Sleep(5000);
        }

        [When(@"I input ""(.*)"" into the address field")]
        public void WhenIInputIntoTheLookupField(string value)
        {
            var lookupElement = _driver.FindElement(By.XPath("//input[@id='lookup']"));
            lookupElement.SendKeys(value + Keys.Enter);
            Thread.Sleep(5000);
        }
        
        [When(@"I click the Login button")]
        public void WhenIClickTheLogin()
        {
            var lookupElement = _driver.FindElement(By.XPath("(//a[contains(text(),'LOG IN')])[2]"));
            lookupElement.Click();
            Thread.Sleep(5000);
        }

        [When(@"I click the Log In")]
        public void WhenIClickTheLogIn()
        {
            var lookupElement = _driver.FindElement(By.XPath("//button[@type='button']"));
            lookupElement.Click();
            Thread.Sleep(5000);
        }

        [When(@"I input not valid email in the Email field")]
        public void WhenInputNotValidEmail()
        {
            var lookupElement = _driver.FindElement(By.XPath("//input[@id='f_uid']"));
            lookupElement.SendKeys("sampletest@test.com" + Keys.Enter);
            Thread.Sleep(5000);
        }

        [When(@"I input not valid password in the Password field")]
        public void WhenInputNotValidPassword()
        {
            var lookupElement = _driver.FindElement(By.XPath("//input[@id='f_pwd']"));
            lookupElement.SendKeys("password123345" + Keys.Enter);
            Thread.Sleep(5000);
        }

        [When(@"I click the reCAPTCHA checkbox")]
        public void WhenIClickTheReCAPTCHACheckbox()
        {
            _driver.SwitchTo().Frame(_driver.FindElement(By.XPath("//iframe[@title='reCAPTCHA']")));

            var recaptchaCheckbox = _driver.FindElement(By.Id("recaptcha-anchor"));
            recaptchaCheckbox.Click();

            _driver.SwitchTo().DefaultContent();
            Thread.Sleep(5000);
        }

        [Then(@"The location displayed should be ""(.*)""")]
        public void ThenIShouldSeeAHeadingWithTheText(string expectedLocation)
        {
            try
            {
                var locationElement = _driver.FindElement(By.XPath($"//h3[normalize-space()='{expectedLocation}']"));
                string actualLocation = locationElement.Text;

                Assert.That(actualLocation, Is.EqualTo(expectedLocation));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail($"Assertion failed: Could not locate the element with text '{expectedLocation}'. The element was not found on the page.");
            }
        }

        [Then(@"The error message for invalid credentials should be displayed")]
        public void ThenAlertMsgIsDisplayed()
        {
            
            try
            {
                Thread.Sleep(5000);
                var alertElement = _driver.FindElement(By.XPath("//div[@class='alert alert-danger']"));
                Assert.That(alertElement.Displayed, Is.True, "The danger alert element was found but was not displayed.");
            }
            catch (NoSuchElementException)
            {
                // If the element is not found after the wait, fail the test
                Assert.Fail("The error message for invalid credentials did not appear on the page.");
            }
        }
    }
}