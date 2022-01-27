Feature: Delete
	Test DELETE operations for users endpoints

Scenario: Delete a single user
	Given A "DELETE" for endpoint "users/{userid}"
	When I send a DELETE request for user "40" 
	Then Response code should be 204
