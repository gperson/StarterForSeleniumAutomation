# StarterForSeleniumAutomation

This project is a starting point for anyone who is looking to use [Selenium](http://www.seleniumhq.org/) and C# for automated testing of a web application.

## Getting Started

Prerequisites - Microsoft Visual Studios (I used 2013)

1. Clone to machine or download project zip file
2. Open VS, in the top dropdown menus go to File -> Open -> Project/Solution
3. Find the StarterForSeleniumAutomation.sln file, select it from file chooser and click open
4. After the project is open, type Ctrl+Shift+B (Build the solution)
5. Now run the 'ExampleTest.cs' test, found at ./StarterForSeleniumAutomation/Tests/ExampleTest, by opening the file and right clicking in the '[TestClass]' and selecting 'Run Tests'

The above steps will launch the test in FireFox, to get IE and Chrome to work you must follow these steps:

6. Download [ChromeDriver](https://sites.google.com/a/chromium.org/chromedriver/downloads)
7. Download newest version of [IEDriverServer](http://selenium-release.storage.googleapis.com/index.html), for me the Win32 version worked best even though my machines OS was 64bit
8. Place the chromedriver.exe and IEDriverServer.exe in the ./StarterForSeleniumAutomation/Drivers directory
9. In ./StarterForSeleniumAutomation/Tests/BaseTest.cs find the below line of code and replace \<path to drivers folder\> with the full path to the Drivers folder (i.e C:/workspace/StarterForSeleniumAutomation/Drivers/)
```c#
string driversPath = @"<path to drivers folder>";
```

## Useful Links

1. General [C# help](https://msdn.microsoft.com/en-us/library/aa288436\(v=vs.71\).aspx) if you are a beginner
2. [Finding IWebelements](https://loadfocus.com/blog/2013/09/05/how-to-locate-web-elements-with-selenium-webdriver/)
3. Although these are not explicit unit tests we do use 'Microsoft.VisualStudio.TestTools.UnitTesting' testing framework to control the flow of our tests, [here](https://msdn.microsoft.com/en-us/library/ms182517\(v=vs.100\).aspx) is general information for this framework

## Project Structure

All the import folders/files are found inside the StarterForSelenium folder. Below I will talk briefly about important files or folders found here.

__Constants__: The classes in here will hold and constant values you want to use throughout the project.  This will help eliminate duplicate code and can be a one stop place to hold any strings, queries, test properties, or anything else.  All methods and fields will be __public__ and  __static__ and so it is to reference them throughout the project.

__Enums__: This will hold any enums you would like to create. I used it for BrowserTypes and TestEnvironment, so I can easily make comparisons when trying to set up my tests.

__Pages__: The classes found here represent all of you applications 'pages'.  All pages will inherit from Page.cs and must use its constructer to initialize its members.  At the top each page will be all the IWebelements used for the page. Here is an example:
```c#
[FindsBy(How = How.Id, Using = "username")]
private IWebElement InputUsername;
```
Below all of these webelments are the methods specific to the page. For example if you had a LoginPage.cs, you would probably have a method in it called LogIn(string username, string password) defined somewhere.

When creating a page you must __intialize the page object in BaseTest.cs__, so it is visible to your test.  This should be accompanied by a protected field for that page at the top of the class.  I do my page initialization in the LaunchBrowser method.

```c#
public class BaseTest
{
  protected YourPage yourPage;
  ...

  protected void LaunchBrowser(string URL)
  {
    ...
    this.yourPage = new YourPage(this.driver);
    ...
  }
  
  ...
}
  
```

__Tests__: This will hold all of your tests, in here feel free to add more folder structure to organize your tests.  Each test class will inherit from BaseTest.cs. BaseTest will hold any methods that you think each test should have access to, like opening and closing the browser.  Each individual test class can have one or many test methods, typically the name will give a summary of what the test does. Here is an example of a basic test class:

```c#
[TestClass]
public class LoginPageTest : BaseTest
{
  [TestInitialize]
  public void TestInitialization()
  {
    LaunchBrowser("https://github.com/");
  }
  
  [TestMethod]
  public void ValidLogin()
  {
    //TODO test steps
  }
  
  [TestMethod]
  public void InvalidLogin()
  {
    //TODO test steps
  }
  
  [TestCleanup]
  public void TestCleanup()
  {
    driver.Quit();
  }
}
```

__Utilities__: Contains any helper classes you want to use throughout the project, like connecting to a database or maybe posting results to a REST client like SauceLabs.

__packages.config__: Is NuGet's configuration file that allows for persisting configuration settings and changing default configuration values.  The only thing in it now is the Selenium files needed for the project, occasionally Selenium will update these. When new browsers versions are released your tests might fail with strange error, this is a sign you need to updated Selenium versions.



