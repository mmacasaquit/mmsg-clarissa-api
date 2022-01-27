Feature: Get
	Test GET operations for users and resources endpoints

Scenario: Get list of users
	Given I set a GET request for "users"
	When I send a GET request for user page "2"
	Then I should see the "page" value as "2"
	And GET response code should be 200

Scenario: Get single user
	Given I set a GET request for "users/{userid}"
	When I send a GET request for user "2"
	Then I should see the data "id" value as "2"
	And GET response code should be 200

Scenario: Get a non existing single user
	Given I set a GET request for "users/{userid}"
	When I send a GET request for user "23"
	Then GET response code should be 404

Scenario: Get a non existing single resource
	Given I set a GET request for "unknown/{userid}"
	When I send a GET request for user "23"
	Then GET response code should be 404
