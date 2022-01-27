Feature: Gets
	Test GET operations for users and resources endpoints

Scenario: Get list of users
	Given A "GET" for endpoint "users"
	When I send a GET request for user page "2"
	Then Response code should be 200
	And Response body should contain correct values 
	| key  | value |
	| page | 2     | 
	 
Scenario: Get single user
	Given A "GET" for endpoint "users/{userid}"
	When I send a GET request for user "2"
	Then Response code should be 200

Scenario: Get a non existing single user
	Given A "GET" for endpoint "users/{userid}"
	When I send a GET request for user "23"
	Then Response code should be 404

Scenario: Get a non existing single resource
	Given A "GET" for endpoint "unknown/{userid}"
	When I send a GET request for user "23"
	Then Response code should be 404
