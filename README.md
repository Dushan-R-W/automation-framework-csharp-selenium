*********************
 AutomationFramework
*********************

Overview
---------
This project demonstrates a QA automation framework using C#, Selenium, NUnit, and RestSharp.
It covers both UI and API automation with a Page Object Model (POM), and configuration setup.
The framework is designed to be maintainable, reusable, and CI-ready.

Tech Stack
-----------
C# / .NET 8
Selenium WebDriver – for UI automation
NUnit – test framework and assertions
RestSharp – for API testing
Page Object Model (POM) – maintainable UI structure
Microsoft.Extensions.Configuration – config-driven URLs, browsers, API base URL
GitHub Actions – CI/CD for automated test execution

Features
---------
UI Tests
Login flow (positive / negative / empty fields)
Cross-browser support (Chrome, extendable)
Page Object Model for maintainability
API Tests
GET / POST requests with validation
Response status, headers, and JSON body checks
Negative tests for invalid endpoints or credentials
CI/CD
Fully integrated with GitHub Actions
Headless browser execution in CI
Automated test reports (.trx files) uploaded as artifacts




******************
 Getting Started
******************

Prerequisites
--------------
Visual Studio 2022
.NET 8 SDK

Clone the repository
---------------------
git clone https://github.com/Dushan-R-W/playwright-pytest-qa-automation.git

Install NuGet Packages
----------------------
UI Automation 
 -Selenium.WebDriver (Lets you click, type, navigate, etc.)
 -Selenium.Support   
 -Selenium.WebDriver.ChromeDriver  (ChromeDriver is required to run Selenium tests in Chrome)

Test Framework
 -NUnit (main test framework)
 -NUnit3TestAdapter (Integrates NUnit with Visual Studio Test Explorer)
 -Microsoft.NET.Test.Sdk  (discover and run unit tests)

API Testing
 -RestSharp  (API testing in C#)

Config Support (allows to use a JSON file as config for a config-driven framework)
 -Microsoft.Extensions.Configuration
 -Microsoft.Extensions.Configuration.Json


Run Tests Locally
-----------------
Open solution in Visual Studio
Build the project: Build → Build Solution
Run all tests via Test Explorer

Run Tests in CI (GitHub Actions)
--------------------------------
Workflow: .github/workflows/main.yml
Runs automatically on push or pull request
Test results are saved as .trx artifacts




***************
 Configuration
***************

appsettings.json
----------------
{
  "baseUrl": "https://the-internet.herokuapp.com",
  "browser": "chrome",
  "apiBaseUrl": "https://dummyjson.com",
  "headless_mode": "true"
}
Change browser to run tests on different browsers (future support)
Change baseUrl / apiBaseUrl for different environments

How it Works
-------------
DriverFactory creates browser instances (headless in CI)
WebDriverSetup handles setup and teardown for each test
Page Objects handle all interactions with web pages.
API clients handle HTTP requests and response validation
Tests are executed via NUnit and results logged to .trx files
CI workflow automatically runs tests and uploads artifacts