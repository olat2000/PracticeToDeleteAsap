Feature: PracticeForm

As A User I want to be able to complete the 'Practice Form'

@Demoqa
Scenario: Demoqa Elements test
	Then I am on demoqa page
	When I click on Forms menu
	And I click on Practice form
	Then I verify that Student Registration Form is visible
	When I enter the following <FirstName> And <LastName> field
	And I enter email field as <EmailAddress> 
	And I select gender option as <Gender>
	And I enter phone field as <PhoneNumber>
	And I enter <DateofBirth>
	And I enter <Subjects> to choose subject from Dropdown
	And I select <Hobbies>
	And I upload a <File>
	And I enter <PermanentAddress> And <CurrentAddress>
	And I choose <State> from the dropdown
	And I choose <City> from the dropdown
	And I click on Submit button
	Then all the details entered should be displayed and validated

	Examples: 
| FirstName | LastName | EmailAddress           | Gender | PhoneNumber | Subjects | Hobbies | File     | PermanentAddress  | CurrentAddress    | State | City  |
| Racheal   | Stones   | rachealstones@test.com | Female | 00944466679 | Comp     | Reading | Text.txt | 56 Dunduck Avenue | 56 Dunduck Avenue | NRC   | Delhi |