@Appium
Feature: Appium Exercises

Scenario: Login into myq
	Given I start the appium driver
	Then I open MyQ App
	Then I login into myq

Scenario: Connect a device
	Given I start the appium driver
	Then I open MyQ App
	Then I add a device

Scenario: Record the process of connect a device
	Given I start the appium driver
	Then I start the recording
	Then I open MyQ App
	Then I add a device
	Then I stop the recording