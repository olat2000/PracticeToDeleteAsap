 Feature: WebTables

As a user i want to be able to add new records, edit a record and delete a record


@Demoqa
Scenario: Add entry to the Demoqa Web Table
Then I am on demoqa page
	When I click elements
	Then I will arrive on the Elements page
	When I click on the Web Tables tab
	Then I will arrive on the Web Tables page
	When I click on the Add button
	Then the Registration form window will appear on the screen
	When I complete the Registration form with the following data
	| Firstname | Lastname | Email          | Age | Salary | Department      |
	| Ben       | May      | benmay@abc.com | 25  | 10000  | Human Resources |  
		And I click on the submit button
	Then the entry will be displayed on the list

@Demoqa
Scenario: Edit entry on Demoqa Web Table
Then I am on demoqa page
	When I click elements
	Then I will arrive on the Elements page
	When I click on the Web Tables tab
	Then I will arrive on the Web Tables page
	When I click on the Add button
	Then the Registration form window will appear on the screen
	When I complete the Registration form with the following data
	| Firstname | Lastname    | Email          | Age | Salary | Department         |
	| Ben       | May         | benmay@abc.com | 25  | 10000  | Human Resources    |
		And I click on the submit button
	Then the entry will be displayed on the list
	When I click on the edit button next to the entry 
		And I change the lastname field to 'Nancy'
	Then the newly edited data 'Nancy' will be displayed on the list
	

@Demoqa
Scenario: Delete entry from the Demoqa Web Table
Then I am on demoqa page
	When I click elements
	Then I will arrive on the Elements page
	When I click on the Web Tables tab
	Then I will arrive on the Web Tables page
	When I click on the Add button
	Then the Registration form window will appear on the screen
	When I complete the Registration form with the following data
	| Firstname | Lastname    | Email          | Age | Salary | Department         |
	| Ben       | May         | benmay@abc.com | 25  | 10000  | Human Resources    |
		And I click on the submit button
	Then the entry will be displayed on the list
	When I click on the edit button next to the entry 
		And I change the lastname field to 'Nancy'
	Then the newly edited data 'Nancy' will be displayed on the list
	When I click on the delete button next to the entry 
	Then the entry will be no longer be available on the list 