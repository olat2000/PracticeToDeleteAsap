Feature: Calculator

@Calculator
Scenario: Add two numbers
	Given I am on calculator page
	  And I enter the first number as 50
	  And I enter the second number as 70
	When the two numbers are added
	Then the result should be 120

@Calculator
Scenario: Add two numbers using scenario context
	Given I am on calculator page
	  And I enter the first number using scenario context as 50 
	  And I enter the second number using scenario context as 70
	When the two numbers are added
	Then the result compared to scenario context should be 120