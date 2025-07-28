# Fake Store Automation Testing

This project is an automated testing suite for the Fake Store web application using Playwright, XUnit and C#. It includes tests for various functionalities such as account creation, shipping address editing, and cart management.

## Installation

1. Clone the repository to your local machine:

   ```bash
   git clone https://github.com/your_username/your_repository.git
   cd your_repository
2. Ensure you have the following dependencies installed:
.NET SDK (version 5.0 or higher)
Selenium WebDriver for browser automation
ChromeDriver for Google Chrome automation
3. Install the necessary NuGet packages:
   dotnet add package Selenium.WebDriver
   dotnet add package Selenium.Support
   dotnet add package Microsoft.VisualStudio.TestTools.UnitTesting

Usage
1. Open the project in your preferred IDE (e.g., Visual Studio or Visual Studio Code).
2. Run the tests using the command:
      dotnet test

Tests
The project includes the following tests:
 - NewAccountCreationTests: Verifies the ability to create a new account.
 - ExistingUserShippingAddressCorrectionTest: Checks the functionality of changing the shipping address for an existing user.
 - LoginExistingUserTest: Tests the login functionality for an existing user.
 - CartTests: Verifies the ability to add products to the cart and edit item quantities.
 - CanEditCartTest: Verifies the abiliti of editing quantity alrady added products to the cart
 - NewUserAddressCorrectionTest: Verifies the abiliti of editing sipping address for the new user
