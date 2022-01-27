Feature: Delete
	Test DELETE operations for users endpoints

@tag1
Scenario: Delete a single user
	Given I set a DELETE request for "users/{userid}"
	When I send a DELETE request for user "40" 
	Then DELETE response code should be 204
