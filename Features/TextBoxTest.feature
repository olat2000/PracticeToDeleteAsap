Feature: TextBoxTest

As a user , i want to complete textbox form

@Demoqa
Scenario Outline: TextBox test
	Then I am on demoqa page
	When I click elements
	Then I am on elements page
	When I click on Text Box menu on elements page
		And I enter Full name <fullname>
		And I enter email address <email>
		And I enter Current address <currentaddress>
		And I enter Permanent address <permanentaddress>
		And I click on Submit button
	Then all the details entered should be displayed
	| fullname   | email   | currentaddress   | permanentaddress   |
	| <fullname> | <email> | <currentaddress> | <permanentaddress> |

	Examples: 
	| fullname | email           | currentaddress | permanentaddress |
	| Anselme  | test01@test.com | Glasgow road   | Glasgow road     |