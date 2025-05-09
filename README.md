# Web Automation Framework - Selenium C# SpecFlow

This repository contains a BDD-style test automation framework built using **Selenium WebDriver**, **SpecFlow**, and **Extent Reports**.
It demonstrates a modular and scalable structure suitable for UI automation in .NET environments.

## 🔧 Tech Stack

- Selenium WebDriver
- SpecFlow (BDD)
- NUnit
- C#
- Extent Reports (Spark)
- Page Object Model (POM)
  

## 🧪 Features

- Login test scenario for sample web app
- Tag-based test execution (@Smoke, @Regression)
- Screenshot capture on failure
- Extent/Spark Reports generation
  

## 📂 Project Structure

- `Features/`: Gherkin feature files
- `StepDefinitions/`: Step implementations
- `Pages/`: Page Object Model classes
- `Hooks/`: Setup and teardown methods
- `Utilities/`: Reusable helpers and config
- `Reports/`: HTML reports generated after test runs

## 🚀 Getting Started

### Prerequisites

- Visual Studio 2022
- .NET 6 or higher
- Chrome browser

### How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/pavithradmohandass/LoginPOCDotnet.git
2. Open the solution in Visual Studio.

3. Run tests via Test Explorer or command line:
dotnet test --filter TestCategory=Smoke

Contact
Pavithra DM
pavithradmohandass@gmail.com
