Feature: SpecWorkflow

A short summary of the feature

@sucessfulLogin
Scenario: Successful login
	Given User navigates to the HomePage
	 When User navigates to the login page
		And User enters a valid credentials,with input email "demouser@microsoft.com" and password "Pass@word1"
		And User clicks on login
	Then User is redirected to HomePage where the user's email "demouser@microsoft.com" will appear on the Navbar


	@InvalidPassword
Scenario: Invalid password
	Given User navigates to the HomePage
	 When User navigates to the login page
		And User enters an invalid password,with input email "demouser@microsoft.com" and password "Password"
		And User clicks on login
	Then An error message will be displayed

		@InvalidEmail
Scenario: Invalid email
	Given User navigates to the HomePage
	 When User navigates to the login page
		And User enters an invalid emailAddress,with input email "demouse@microsoft.com" and password "Pass@word1"
		And User clicks on login
	Then An error message will be displayed


