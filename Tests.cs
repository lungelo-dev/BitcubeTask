using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;


namespace PlaywrightTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]

    [AllureNUnit]
    [TestFixture]
    [AllureSuite("Factorial Calculator Tests")]

    public class Tests : PageTest
    {
        [Test]

        [AllureTag("NUnit", "Playwright")]
        [AllureStep]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureStory("Test various inputs for factorial calculation")]
        //Task 1

        // These are the test cases that I have preapared to test the factorial calculator
        [TestCase("5.5", TestName = "FloatNumber")]
        [TestCase("V", TestName = "InvalidInput_V")]
        [TestCase("5", TestName = "ValidInput_5")]
        [TestCase("", TestName = "EmptyInput")]
        [TestCase("!@#", TestName = "NonDigit")]
        [TestCase("0", TestName = "ZeroInput")]
        [TestCase("1", TestName = "OneInput")]
        [TestCase("999999999", TestName = "LargeNumberInput")]
        [TestCase("-5", TestName = "NegativeNumberInput")]
        public async Task FactorialInputs(string inputValue)
        {
            // Navigate to the site
            await Page.GotoAsync("http://qainterview.pythonanywhere.com");
            await Page.ScreenshotAsync(new PageScreenshotOptions { Path = $"Step1_HomePage_{inputValue}.png" });

            // Input data and click "Calculate!"
            await Page.Locator("#number").FillAsync(inputValue);
            await Page.ScreenshotAsync(new PageScreenshotOptions { Path = $"Step2_Input_{inputValue}.png" });

            //Click on Calculate button
            await Page.Locator("#getFactorial").ClickAsync();
            await Page.ScreenshotAsync(new PageScreenshotOptions { Path = $"Step3_CalculateClicked_{inputValue}.png" });

            //Retreive results returned as text
            var resultText = await Page.Locator("#resultDiv").InnerTextAsync();
            await Page.ScreenshotAsync(new PageScreenshotOptions { Path = $"Step4_Calculate Results: _{inputValue}.png" });

            // Print the result to the test context output
            TestContext.WriteLine($"Input: {inputValue}, Result: {resultText}");

        }

        [Test]

        [AllureTag("NUnit", "Playwright")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureStory("Validate input field style for invalid input")]

        //Task 2
        public async Task StyleValidationTest()
        {
            // Navigate to the site
            await Page.GotoAsync("http://qainterview.pythonanywhere.com");
            await Page.ScreenshotAsync(new PageScreenshotOptions { Path = "Step1_HomePage.png" });

            // Input invalid data and click "Calculate!"
            await Page.Locator("#number").FillAsync("V");
            await Page.ScreenshotAsync(new PageScreenshotOptions { Path = "Step2_InvalidInput.png" });

            await Page.Locator("#getFactorial").ClickAsync();
            await Page.ScreenshotAsync(new PageScreenshotOptions { Path = "Step3_CalculateClicked.png" });

            // Check for the red border on the input field
            var borderColor = await Page.Locator("#number").EvaluateAsync<string>("el => el.style.borderColor");
            Assert.That(borderColor, Is.EqualTo("red"), "Input field should display a red border for invalid input.");
            await Page.ScreenshotAsync(new PageScreenshotOptions { Path = "Step4_ErrorDisplayed.png" });
        }

        [Test]

        [AllureTag("NUnit", "Playwright")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureStory("Capture console messages during test execution")]

       
        //Task 3
        public async Task CaptureConsoleMessages()
        {
            // List to store console messages
            var consoleMessages = new List<string>();

            // Event handler to capture console messages
            Page.Console += (_, msg) => consoleMessages.Add(msg.Text);

            // Navigate to the site
            await Page.GotoAsync("http://qainterview.pythonanywhere.com");

            // Perform actions that trigger console messages
            await Page.Locator("#number").FillAsync("5");
            await Page.Locator("#getFactorial").ClickAsync();

            // Wait for a short period to ensure all console messages are captured
            await Task.Delay(1000);

            // Assert that at least one console message was captured
            Assert.That(consoleMessages, Is.Not.Empty, "No console messages were captured.");

            // Print all captured console messages
            foreach (var message in consoleMessages)
            {
                TestContext.WriteLine(message);
            }
        }

        //Task 4
        [Test]

        [AllureTag("NUnit", "Playwright")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureStory("Calculate factorial of 12 and validate result")]

        public async Task FactorialOf12()
        {
            // Expected result for factorial of 12
            const string expectedResult = "479001600";

            // Navigate to the site
            await Page.GotoAsync("http://qainterview.pythonanywhere.com");
            await Page.ScreenshotAsync(new PageScreenshotOptions { Path = "Step1_HomePage.png" });

            // Input the number 12 and click "Calculate!"
            await Page.Locator("#number").FillAsync("12");
            await Page.ScreenshotAsync(new PageScreenshotOptions { Path = "Step2_Input_12.png" });

            await Page.Locator("#getFactorial").ClickAsync();
            await Page.ScreenshotAsync(new PageScreenshotOptions { Path = "Step3_CalculateClicked.png" });

            // Get the result text
            var resultText = await Page.Locator("#resultDiv").InnerTextAsync();
            await Page.ScreenshotAsync(new PageScreenshotOptions { Path = "Step4_ResultDisplayed.png" });

            // Print the result text for debugging
            TestContext.WriteLine($"Result text: {resultText}");

            // Extract the number after the colon
            var resultParts = resultText.Split(':');
            Assert.That(resultParts.Length, Is.GreaterThan(1), "Result text does not contain a colon.");
            var actualResult = resultParts[1].Trim();

            // Print the extracted number for debugging
            TestContext.WriteLine($"Extracted number: {actualResult}");

            // Assert that the result is as expected
            Assert.That(actualResult, Is.EqualTo(expectedResult), $"The factorial of 12 should be {expectedResult}.");
        }


        //Task 5
        [Test]

        [AllureTag("NUnit", "Playwright")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureStory("Capture API call during test execution")]

        public async Task CaptureApiCall()
        {
            // Variable to store the intercepted request
            IRequest interceptedRequest = null;

            // Intercept the API call
            await Page.RouteAsync("**/api/endpoint", route =>
            {
                interceptedRequest = route.Request;
                route.ContinueAsync();
            });

            // Navigate to the site
            await Page.GotoAsync("http://qainterview.pythonanywhere.com");

            // Perform actions that trigger the API call.
            // the number 5 is just any random number that you can use
            await Page.Locator("#number").FillAsync("5");
            await Page.Locator("#getFactorial").ClickAsync();

            // Wait delay to make sure that the API call has been made
            await Task.Delay(2000);

            // Assert that the request was intercepted
            Assert.That(interceptedRequest, Is.Not.Null, "No API call was intercepted.");

            // Print the request details
            TestContext.WriteLine("URL: " + interceptedRequest.Url);
            TestContext.WriteLine("Method: " + interceptedRequest.Method);
            TestContext.WriteLine("Headers: " + string.Join(", ", interceptedRequest.Headers.Select(h => $"{h.Key}: {h.Value}")));
            TestContext.WriteLine("Post Data: " + interceptedRequest.PostData);

            // Optionally, you can assert specific headers or parameters
            Assert.That(interceptedRequest.Headers["Content-Type"], Is.EqualTo("application/json"), "Content-Type header should be application/json.");
            Assert.That(interceptedRequest.PostData, Does.Contain("\"number\":\"5\""), "Post data should contain the number 5.");
        }
    }
}



