using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace BDDAutomation.StepDefinitions
{
    [Binding]
    public class LoginAndCreateStepDefinitions
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private string _userName ;

        [BeforeScenario]
        public void Before()
        {
            _driver = new EdgeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
        [AfterScenario]
        public void After()
        {
            Thread.Sleep(100000);
            _driver.Quit();
        }

        private string GenerateUserName()
        {
            string name = "jarivs";
            return name + new Random().Next(1000, 9999);
        }
        [Given(@"open edge and invite the url ""([^""]*)""")]
        public void GivenOpenEdgeAndInviteTheUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        [When(@"login in with admin user")]
        public void WhenLoginInWithAdminUser()
        {
            var userField = _wait.Until(_driver => _driver.FindElement(By.Name("username")));
            userField.SendKeys("Admin");
            var passwordField = _wait.Until(_driver => _driver.FindElement(By.Name("password")));
            passwordField.SendKeys("admin123");
            var loginButton = _driver.FindElement(By.XPath("/html/body/div/div[1]/div/div[1]/div/div[2]/div[2]/form/div[3]/button"));
            loginButton.Click();
        }

        [When(@"open admin page")]
        public void WhenOpenAdminPage()
        {
            var adminMenu = _wait.Until(_driver => _driver.FindElement(By.XPath("//a[@href=\"/web/index.php/admin/viewAdminModule\"]")));
            adminMenu.Click();

            var addButton = _wait.Until(_driver =>
                _driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div[2]/div[1]/button")));
            addButton.Click();

        }

        [Then(@"click add button and open create user page")]
        public void ThenClickAddButtonAndOpenCreateUserPage()
        {
            var userRoleSelect = _wait.Until(_driver => 
                _driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[1]/div/div[2]/div/div/div[1]")));
            userRoleSelect.Click();

            var userRoleValue = _wait.Until(_driver =>
                _driver.FindElements(By.XPath("//div[@role=\"listbox\"]"))).FirstOrDefault();
            userRoleValue.Click();

            var statusSelect = _driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[3]/div/div[2]/div/div/div[1]"));
            statusSelect.Click();
            var statusValue = _wait.Until(_driver =>
                _driver.FindElements(By.XPath("//div[@role=\"listbox\"]"))).FirstOrDefault();
            statusValue.Click();

            var employeeInput = _driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[2]/div/div[2]/div/div/input"));
            employeeInput.SendKeys("and");
            var employeeValue = _wait.Until(_driver =>
                _driver.FindElements(By.XPath("//div[@role=\"listbox\"]"))).FirstOrDefault();
            employeeValue.Click();

            var usernameField = _driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[4]/div/div[2]/input"));
            _userName = this.GenerateUserName();
            usernameField.SendKeys(_userName);

            var passwordField = _driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[1]/div/div[2]/input"));
            passwordField.SendKeys("password1");
            var passwordConfirmField = _driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[2]/div/div[2]/input"));
            passwordConfirmField.SendKeys("password1");

            var saveButton = _driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[3]/button[2]"));
            saveButton.Click();
            
        }

        [Then(@"create and save the user")]
        public void ThenCreateAndSaveTheUser()
        {
            throw new PendingStepException();
        }

        [Then(@"check weather if works success")]
        public void ThenCheckWeatherIfWorksSuccess()
        {
            throw new PendingStepException();
        }
    }
}
