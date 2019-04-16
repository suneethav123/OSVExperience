Feature: TaxExDataValidation

@mytag
Scenario: Data Validation for Missing Power of Attorney
	Given Open browser 'chrome' 
	Then Navigate to url and enter username and password
	| url                         | username                 | password   |
	| https://test.taxex.net/app/ |rupesh.barnawal@zenq.com  | Zenq@1234  |
