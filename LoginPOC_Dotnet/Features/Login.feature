Feature: Login

@smoke
Scenario: Successful login with valid credentials
  Given I navigate to the login page
  When I enter valid username and password
  And I click the login button
  Then I should be redirected to the dashboard
  And i click Logout button
  Then Test login page should be displayed

  @smoke

Scenario: Negative username Test
Given I navigate to the login page
When I enter invalid username and valid password
And I click the login button
Then Error message should be displayed as "Your username is invalid!"

@smoke

Scenario: Negative Password Test
Given I navigate to the login page
When I enter valid username and invalid password
And I click the login button
Then Error message should be displayed as "Your password is invalid!"


