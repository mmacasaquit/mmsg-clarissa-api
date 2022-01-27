Feature: Post
	Test POST operations for users and resources endpoints

Scenario: Create a user
	Given A "POST" for endpoint "users"
	When I send a POST request for create user
	| name	   | job |
	| Clarissa | QA  | 
	Then Response code should be 201
	And Response body should contain correct values 
	| key  | value     |
	| name | Clarissa  | 
	| job  | QA		   | 

Scenario: Successful register
	Given A "POST" for endpoint "register"
	When I send a POST request with credentials
	| email			     | password |
	| eve.holt@reqres.in | pistol   | 
	Then Response code should be 200
	And Response body should contain correct values 
	| key   | value     |
	| token | QpwL5tke4Pnpja7X4  | 

Scenario: Unsuccessful register
	Given A "POST" for endpoint "register"
	When I send a POST request with credentials
	| email			     | password |
	| eve.holt@reqres.in |		    | 
	Then Response code should be 400
	And Response body should contain correct values 
	| key   | value		        |
	| error | Missing password  | 

Scenario: Successful login
	Given A "POST" for endpoint "login"
	When I send a POST request with credentials 
	| email			     | password |
	| eve.holt@reqres.in | pistol   | 
	Then Response code should be 200
	And Response body should contain correct values 
	| key   | value     |
	| token | QpwL5tke4Pnpja7X4  | 