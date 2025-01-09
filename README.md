Project Overview

This project is part of a QA task provided by Bitcube. The purpose is to showcase your software quality assurance skills by testing and analyzing a specified application or software. This repository contains the necessary documentation, scripts, and configurations used for completing the task.

Table of Contents

1. Requirements

2. Setup Instructions

3. Test Strategy

4. Execution Instructions

5. Test Results

6. Improvements and Observations


   
================================================================================================================================================================================
Requirements

To complete this task, ensure you have the following:

A computer with a supported operating system (Windows, macOS, or Linux).

Installed dependencies:

Node.js (for JavaScript-based test frameworks).
Playwright.
C#.
Java 8+.
Visual Studio 2022
Powershell



================================================================================================================================================================================

Setup Instructions

1. Clone the repository:

git clone https://github.com/lungelo-dev/BitcubeTask.git

cd BitcubeTask

Install dependencies:

npm install   # For JavaScript-based frameworks


Ensure the application under test is accessible and running.

Configure the necessary environment variables in the .env file (if applicable).


================================================================================================================================================================================

Test Strategy

The test strategy includes:

Test Scope:

Identify critical functionalities and edge cases.

Prioritize user-facing features and high-risk areas.

Test Types:

Functional Tests: Verifying core features work as expected.

Regression Tests: Ensuring updates do not break existing functionality.

UI Tests: Validating user interface components and responsiveness.

Performance Tests: Evaluating load times and response times under stress.

Tools Used:

Automation framework: Playwright/Selenium.

Reporting tool: Allure/JUnit Reports.

Test Artifacts:

Test cases and scenarios documented in test-cases.xlsx.


================================================================================================================================================================================


Execution Instructions

Run automated tests:

npm test  # For JavaScript-based tests
pytest    # For Python-based tests

Generate a test report:

allure generate allure-results --clean -o allure-report
allure open

Manually execute test cases outlined in test-cases.xlsx and record observations.


================================================================================================================================================================================

Test Results

Results from the executed tests:

Automated test results are available in the allure-report directory.

Manual test results and observations are recorded in manual-test-results.xlsx.


================================================================================================================================================================================

Improvements and Observations

Areas for improvement:

Identify potential areas in the application where user experience can be enhanced.

Suggest performance optimizations if applicable.

Observations:

Any bugs or issues discovered during testing are documented in the bug-report.xlsx file.
