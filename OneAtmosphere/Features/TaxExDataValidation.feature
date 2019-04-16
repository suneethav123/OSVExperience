Feature: TaxExDataValidation

@mytag
Scenario: Data Validation for Missing Power of Attorney
	Given Open browser 'chrome' 
	Then Navigate to url and enter username and password
	| url                         | username                   | password    |
	| https://dev.taxex.net/app/  |sridevi.pediredla@zenq.com  | Zenq@12345  |
	Then Navigate to Process > Import screen
	Then Import Xml into application

