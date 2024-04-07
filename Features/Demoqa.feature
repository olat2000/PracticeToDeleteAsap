Feature: Demoqa


@Demoqa
Scenario: Demoqa Elements test
	Then I am on demoqa page
	When I click elements
	Then I am on elements page

@Demoqa
Scenario: Login Test using Example table
	Then I am on demoqa page
	When  I click <BookStoreApplication> menu
	And I enter <Username> and <Password>
	Then I am loged in as <Username>

Examples: 
| BookStoreApplication   | Username | Password    | 
| Book Store Application | TestUser | Password01! | 

@Demoqa
Scenario: Login Test using table in step
	Then I am on demoqa page
	When  I select BookStoreApplication menu
	| BookStoreApplication   |
	| Book Store Application |
	And I input Username and Password:
	| Username | Password    |
	| TestUser | Password01! |
	Then I am loged in as:
	| Username |
	| TestUser |

@Demoqa
Scenario: Login Test using scenario context
	Then I am on demoqa page
	When  I select BookStoreApplication menu
	| BookStoreApplication   |
	| Book Store Application |
	And I input Username and Passwor and save username as 'user'
	| Username | Password    |
	| TestUser | Password01! |
	Then user is logged in as 'user'