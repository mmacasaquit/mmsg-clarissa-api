Feature: Post

A short summary of the feature

Scenario: Create a user
	Given I set a POST request for "users"
	When I send a POST request for create user
	| name	   | job |
	| Clarissa | QA  | 
	Then POST response code should be 201
	And Create user response body should contain "Clarissa" as name and "QA" as job

Scenario: Successful register
	Given I set a POST request for "register"
	When I send a POST request with credentials
	| email			     | password |
	| eve.holt@reqres.in | pistol   | 
	Then POST response code should be 200
	And POST reponse body contains auth token "QpwL5tke4Pnpja7X4"

Scenario: Unsuccessful register
	Given I set a POST request for "register"
	When I send a POST request with credentials
	| email			     | password |
	| eve.holt@reqres.in |		    | 
	Then POST response code should be 400
	And POST response body contains error with "Missing password" message

Scenario: Successful login
	Given I set a POST request for "login"
	When I send a POST request with credentials 
	| email			     | password |
	| eve.holt@reqres.in | pistol   | 
	Then POST response code should be 200
	And POST reponse body contains auth token "QpwL5tke4Pnpja7X4"