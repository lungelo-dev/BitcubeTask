Bitcube QA Task

Project Overview

This project is part of a QA task provided by Bitcube. The purpose is to showcase your software quality assurance skills by testing and analyzing a specified application or software. This repository contains the necessary documentation, scripts, and configurations used for completing the task.



Table of Contents

1. Requirements
2. Setup Instructions
3. Test Strategy
4. Execution Instructions
5, Test Results
6. Package References

#================================================================================================
Requirements

To complete this task, ensure you have the following:

A computer with a supported operating system (Windows, macOS, or Linux).

Installed dependencies:

Node.js (for JavaScript-based test frameworks).
Playwright.
C#.
.NET 8.
Java 8+.
Visual Studio 2022.
PowerShell.

#================================================================================================
Setup Instructions

Clone the repository:

git clone https://github.com/lungelo-dev/BitcubeTask.git
cd BitcubeTask

Install dependencies:

npm install   # For JavaScript-based frameworks

Ensure the application under test is accessible and running.

Configure the necessary environment variables in the .env file (if applicable).

#================================================================================================

Test Strategy

The test strategy includes:

Test Scope:

Identify critical functionalities and edge cases.

Prioritize user-facing features and high-risk areas.

Test Types:

UI Tests: Validating user interface components and responsiveness.

Tools Used:

Automation framework: Playwright/Selenium.

Reporting tool: Allure Reports.

Test Artifacts:

Test cases and scenarios documented in my Test Lodge trial account:

Link: https://app.testlodge.com/a/41571/projects/58966/suites/248429

Email: lungelotom0@gmail.com

Password: Mi@FRUErms34wYV

#================================================================================================

Execution Instructions

Run automated tests:

First, build the solution.

Navigate to Test > Test Explorer > BitcubeTask > PlaywrightTests.

Use the green "Run" button to execute the tests. You can either execute them all at once or individually.

Generate a test report:

allure generate allure-results --clean -o allure-report
allure open

Manually execute test cases outlined in test-cases.xlsx and record observations.

#================================================================================================

Test Results

Results from the executed tests:

Automated test results are available in the allure-report directory.

Manual test results and observations are recorded in manual-test-results.xlsx.

Screenshots are located in the .NET 8 binary folder.

#================================================================================================

Package References

Project 'BitcubeTask' has the following package references:

[net8.0]:

Top-level Package                 Requested   Resolved

Allure.Commons                  3.5.0.73    3.5.0.73
coverlet.collector              6.0.0       6.0.0
Microsoft.NET.Test.Sdk          17.8.0      17.8.0
Microsoft.Playwright            1.49.0      1.49.0
Microsoft.Playwright.NUnit      1.49.0      1.49.0
NUnit                           3.14.0      3.14.0
NUnit.Allure                    1.2.1.1     1.2.1.1
NUnit.Analyzers                 3.9.0       3.9.0
NUnit3TestAdapter               4.5.0       4.5.0