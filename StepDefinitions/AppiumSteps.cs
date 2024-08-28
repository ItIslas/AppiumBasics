﻿using AppiumExercises.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow.Time;
using OpenQA.Selenium;

namespace AppiumExercises.StepDefinitions
{
    [Binding]
    [Scope(Tag = "@Appium")]
    internal class AppiumSteps : TestBase
    {
        By myqLogIn = By.XPath("//android.widget.Button[@resource-id='com.chamberlain.android.liftmaster.myq:id/welcome_btn_sign_in']");
        By usernameField = By.XPath("//android.widget.EditText[@resource-id=\"login-email\"]");
        By passField = By.XPath("//android.widget.EditText[@resource-id=\"login-password\"]");
        By tmpUsernameField = By.XPath("//android.view.View[@text=\"Email\"]");
        By loginBttn = By.XPath("//android.widget.Button[@resource-id=\"submit_button\"]");

        protected readonly ScenarioContext _scenarioContext;
        public AppiumSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        public AppiumSteps() { }

        [Given(@"I start the appium driver")]
        public void GivenIStartTheAppiumDriver()
        {
            OptionCollector argCollector = new OptionCollector()
                .AddArguments(new KeyValuePair<string, string>("--base-path", "/wd/hub"));

            AppiumServiceBuilder builder = new AppiumServiceBuilder()
            .WithArguments(argCollector)
            .WithIPAddress("127.0.0.1")
            .WithStartUpTimeOut(new TimeSpan(0, 0, 15))
            .UsingPort(4723);

            service = builder.Build();

            if (!service.IsRunning)
                service.Start();

            var driverOptions = new AppiumOptions
            {
                PlatformName = "Android",
                AutomationName = "UiAutomator2"
            };

            //driverOptions.AddAdditionalAppiumOption(MobileCapabilityType.DeviceName, Configure.ANDROID_DEVICE_NAME);
            driverOptions.AddAdditionalAppiumOption("appPackage", "com.android.settings");
            driverOptions.AddAdditionalAppiumOption("appActivity", "com.android.settings.Settings$NetworkProviderSettingsActivity");
            driverOptions.AddAdditionalAppiumOption("appium:wdaConnectionTimeout", 10000);
            driverOptions.AddAdditionalAppiumOption("appium:waitForIdleTimeout", 10000); 
            driverOptions.AddAdditionalAppiumOption("appium:newCommandTimeout", 10000);
            driverOptions.AddAdditionalAppiumOption("noReset", true);

            var commandExecutor = new HttpCommandExecutor(new Uri("http://127.0.0.1:4723/wd/hub"), TimeSpan.FromSeconds(60));

            appDriver = new AndroidDriver(new Uri("http://127.0.0.1:4723/wd/hub"), driverOptions);
            wait = new WebDriverWait(appDriver, TimeSpan.FromSeconds(Configure.SELENIUM_WAIT_TIMEOUT));

        }

        [Given(@"I open wifi network avaiable")]
        public void GivenIOpenWifiNetworkAvaiable()
        {
            appDriver.StartActivity("com.android.settings", "com.android.settings.Settings$NetworkProviderSettingsActivity");
        }

        [Given(@"I launch network configuration")]
        public void GivenILaunchNetworkConfiguration()
        {
            OpenWifiList();
        }
        
        [Then(@"I open MyQ App")]
        public void ThenIOpenMyQApp()
        {
            appDriver.StartActivity("com.chamberlain.android.liftmaster.myq", "com.chamberlain.myq.features.login.LoginActivity");
        }

        [Then(@"I login into myq")]
        public void ThenIClickOnLoginButton()
        {
            wait.Until(ExpectedConditions.ElementExists(myqLogIn));
            appDriver.FindElement(myqLogIn).Click();
            wait.Until(ExpectedConditions.ElementExists(tmpUsernameField));
            appDriver.FindElement(usernameField).SendKeys(Configure.MYQ_USERNAME);
            appDriver.FindElement(passField).SendKeys(Configure.MYQ_PASSWORD);
            appDriver.FindElement(loginBttn).Click();
            appDriver.FindElement(usernameField).Click();
            appDriver.HideKeyboard();
            appDriver.FindElement(loginBttn).Click(); 
        }

        public void OpenWifiList()
        {
            appDriver.StartActivity("com.android.settings", "com.android.settings.Settings$NetworkProviderSettingsActivity");
        }

        public void OpenChrome()
        {
            appDriver.StartActivity("com.android.chrome", "com.google.android.apps.chrome.Main");
        }

    }
}
