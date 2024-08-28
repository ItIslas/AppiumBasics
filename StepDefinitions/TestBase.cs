using AppiumExercises.Config;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AppiumExercises.StepDefinitions
{
    internal class TestBase
    {
        public AppiumLocalService service;
        public static AndroidDriver appDriver;
        public static WebDriverWait wait;

        [Then(@"I wait a minute")]
        public void ThenIWaitAMinute()
        {
            Thread.Sleep(3000);
        }
    }
}
