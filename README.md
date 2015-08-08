# StarterForSeleniumAutomation

This project is a starting point for anyone who is looking to use [Selenium](http://www.seleniumhq.org/) and C# for automated testing of a web application.

## Getting Started

Prerequisites - Microsoft Visual Studios (I used 2013)

1. Clone to machine or download project zip file
2. Open VS, in the top dropdown menus go to File -> Open -> Project/Solution
3. Find the StarterForSeleniumAutomation.sln file, select it from file chooser and click open
4. After the project is open, type Ctrl+Shift+B (Build the solution)
5. Now run the 'ExampleTest.cs' test, found at ./StarterForSeleniumAutomation/Tests/ExampleTest, by opening the file and right clicking in the '[TestClass]' and selecting 'Run Tests'

The above steps will launch the test in FireFox, to get IE and Chrome to work you must follow these seteps:

6. Download [ChromeDriver](https://sites.google.com/a/chromium.org/chromedriver/downloads)
7. Download newest version of [IEDriverServer](http://selenium-release.storage.googleapis.com/index.html), for me the Win32 version worked best even though my machines OS was 64bit
8. Place the chromedriver.exe and IEDriverServer.exe in the ./StarterForSeleniumAutomation/Drivers directory
9. In ./StarterForSeleniumAutomation/Tests/BaseTest.cs find the below line of code and replace \<path to drivers folder\> with the full path to the Drivers folder (i.e C:/workspace/StarterForSeleniumAutomation/Drivers/)
```c#
string driversPath = @"<path to drivers folder>";
```

## Useful Links

1. General [C# help](https://msdn.microsoft.com/en-us/library/aa288436\(v=vs.71\).aspx) if you are a begineer
2. [Finding IWebelements](https://loadfocus.com/blog/2013/09/05/how-to-locate-web-elements-with-selenium-webdriver/)
3. Although these are not explicit unit tests we do use 'Microsoft.VisualStudio.TestTools.UnitTesting' testing framework to control the flow of our tests, [here](https://msdn.microsoft.com/en-us/library/ms182517\(v=vs.100\).aspx) is general information for this framework






