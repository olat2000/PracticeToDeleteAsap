Feature: PracticeForm

As A User I want to be able to complete the 'Practice Form'

@Demoqa @Forms
Scenario: Demoqa Practice Form test
	Then I am on demoqa page
	When I click on Forms menu
		And I click on Practice form
	Then I verify that Student Registration Form is visible
	When  I have filled out the Registration form with the following data
	| FirstName | LastName | Email                  | PhoneNumber | DateOfBirth | File     | CurrentAddress    | State   | City    |
	| Racheal   | Stones   | rachealstones@test.com | 0094446667  |15 May,1990  | Text.txt | 56 Dunduck Avenue | Haryana | Panipat |
		And I click Gender Option 'Female'
		And I click on submit button
	Then all the details entered should be displayed
	Then the data should be successfully submitted and retrieved 
	| FirstName | LastName | Email                  | PhoneNumber | DateOfBirth | File     | CurrentAddress    | State   | City    |
	| Racheal   | Stones   | rachealstones@test.com | 0094446667  | 15 May,1990 | Text.txt | 56 Dunduck Avenue | Haryana | Panipat |