Feature: Salesforce
	

@mytagP1
Scenario: Verify that assigning 'My Account' permission to a demo user is accessible 
	Given Open browser 'chrome'
	Then  Navigate To SalesForce Url 
	Then  Login into Salesforce with valid credentials
	Then  Remove 'MyAccount' permission from Demo user
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OSVAtmos site
	Given Verify MyAccount in OneAtmos after removing permission
	Then  Assign 'MyAccount' permission to Demo User
	Then  Logout from Salesforce
	Given Verify MyAccount in OneAtmos after assigning permission
	Then  Logout from application
	Then  Verify the logout
	Then  Quit browser

@mytagP1
Scenario: Verify that assigning 'Treasury Access' permission to a demo user is accessible 
	Given Open browser 'chrome'
	Then  Navigate To SalesForce Url 
	Then  Login into Salesforce with valid credentials
	Then  Remove 'Treasury' permission from Demo user
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OSVAtmos site
	Given Verify Treasury in OneAtmos after removing permission
	Then  Assign 'Treasury' permission to Demo User
	Then  Logout from Salesforce
	Given Verify Treasury in OneAtmos after assigning permission
	Then  Logout from application
	Then  Verify the logout
	Then  Quit browser

@mytagP1
Scenario: Verify that assigning 'Tax Access' permission to a demo user is accessible
	Given Open browser 'chrome'
	Then Navigate To SalesForce Url 
	Then Login into Salesforce with valid credentials
	Then Remove 'Tax' permission from Demo user
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OSVAtmos site
	Given Verify Tax in OneAtmos after removing permission
	Then Assign 'Tax' permission to Demo User
	Then Logout from Salesforce
	Given Verify Tax in OneAtmos after assigning permission
	Then  Logout from application
	Then  Verify the logout
	Then Quit browser

@mytagP1
Scenario: Verify that assigning 'My account' and 'Treasury Access' permissions to a demo user is accessible 
	Given Open browser 'chrome'
	Then Navigate To SalesForce Url 
	Then Login into Salesforce with valid credentials
	Then Remove 'MyAccount' permission from Demo user
	Then Remove 'Treasury' permission from Demo user
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OSVAtmos site
	Given Verify MyAccount in OneAtmos after removing permission
	Given Verify Treasury in OneAtmos after removing permission
	Then Assign 'MyAccount' permission to Demo User
	Then Assign 'Treasury' permission to Demo User
	Then Logout from Salesforce
	Given Verify MyAccount in OneAtmos after assigning permission
	Given Verify Treasury in OneAtmos after assigning permission
	Then  Logout from application
	Then  Verify the logout
	Then Quit browser

@mytagP1
Scenario: Verify that assigning 'My account' and 'Tax Access' premissions to a demo user is accessible
	Given Open browser 'chrome'
	Then Navigate To SalesForce Url 
	Then Login into Salesforce with valid credentials
	Then Remove 'MyAccount' permission from Demo user
	Then Remove 'Tax' permission from Demo user
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OSVAtmos site
	Given Verify MyAccount in OneAtmos after removing permission
	Given Verify Tax in OneAtmos after removing permission
	Then Assign 'MyAccount' permission to Demo User
	Then Assign 'Tax' permission to Demo User
	Then Logout from Salesforce
	Given Verify MyAccount in OneAtmos after assigning permission
	Given Verify Tax in OneAtmos after assigning permission
	Then  Logout from application
	Then  Verify the logout
	Then Quit browser


@mytagP1
Scenario: Tax Collection >> ACH Money Movement Type - Create Money transaction record in salesforce and validate in the OSVAtmosphere
    Given Open browser 'chrome'
	Then  Navigate To SalesForce Url 
	Then  Login into Salesforce with valid credentials
	Then  Now click on Money Transcation Tab 
	Then  Click on New button present in the Home page of Money Transaction  
	Then  Enter Account details and Tenant Details in Money Transaction page 
	Then  Select 'Approved' status for the New Money Transation 
	Then  Select 'Tax Collection' Transaction Type
	Then  Select 'ACH' Money Movement type
	Then  Enter Adjusted Total Dollar Ammount as '5000' and Total Dollar Amount as '5000'
	Then  Enter '09/10/2018' as Settlement date 
	Then  Enter Bank details Bank name as 'Bank of America', Bank ABN Num as '100235678', Bank Acc Num as '1111111111'
    Then  Select 'Wells Fargo' VRP Processing Bank
	Then  Click on save button
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OSVAtmos site
	Then  Click on Ellipses icon under Treasury section
	And   Verify 'Tax Collection' record in Treasury section
	Then  Logout from application
	Then  Verify the logout
	Then  Quit browser
	Then  Delete created transaction in Salesforce
	Then Logout from Salesforce

@mytagP1
Scenario: DDP Collection >> ACH Money Movement Type - Create a new 'Money transaction' with 'Approved' Status for Future settlement date
    Given Open browser 'chrome'
	Then  Navigate To SalesForce Url 
	Then  Login into Salesforce with valid credentials
	Then  Now click on Money Transcation Tab 
	Then  Click on New button present in the Home page of Money Transaction  
	Then  Enter Account details and Tenant Details in Money Transaction page 
	Then  Select 'Approved' status for the New Money Transation 
	Then  Select 'DPP Collection' Transaction Type
	Then  Select 'ACH' Money Movement type
	Then  Enter Adjusted Total Dollar Ammount as '7000' and Total Dollar Amount as '7000'
	Then  Enter '09/10/2018' as Settlement date 
	Then  Enter Bank details Bank name as 'Bank of America', Bank ABN Num as '100235678', Bank Acc Num as '2222222222'
    Then  Select 'Wells Fargo' VRP Processing Bank
	Then  Click on save button
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OSVAtmos site
	Then  Click on Ellipses icon under Treasury section
	And   Verify 'DPP Collection' record in Treasury section
	Then  Logout from application
	Then  Verify the logout
	Then  Quit browser
	Then  Delete created transaction in Salesforce
	Then  Logout from Salesforce

@mytagP1
Scenario: Garnishment Collection >> ACH Money Movement Type - Create a new 'Money Transaction' with 'Approved' Status for Future Settlement date
    Given Open browser 'chrome'
	Then  Navigate To SalesForce Url 
	Then  Login into Salesforce with valid credentials
	Then  Now click on Money Transcation Tab 
	Then  Click on New button present in the Home page of Money Transaction  
	Then  Enter Account details and Tenant Details in Money Transaction page 
	Then  Select 'Approved' status for the New Money Transation 
	Then  Select 'Garnishment Collection' Transaction Type
	Then  Select 'ACH' Money Movement type
	Then  Enter Adjusted Total Dollar Ammount as '7000' and Total Dollar Amount as '7000'
	Then  Enter '09/10/2018' as Settlement date 
	Then  Enter Bank details Bank name as 'Bank of America', Bank ABN Num as '100235678', Bank Acc Num as '3333333333'
    Then  Select 'Wells Fargo' VRP Processing Bank
	Then  Click on save button
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OSVAtmos site
	Then  Click on Ellipses icon under Treasury section
	And   Verify 'Garnishment Collection' record in Treasury section
	Then  Logout from application
	Then  Verify the logout
	Then  Quit browser
	Then  Delete created transaction in Salesforce
	Then  Logout from Salesforce

@mytagP1
Scenario: DPP Refund >> ACH Money Movement Type - Create a new 'Money Transaction' with 'Approved' Status for current date
    Given Open browser 'chrome'
	Then  Navigate To SalesForce Url 
	Then  Login into Salesforce with valid credentials
	Then  Now click on Money Transcation Tab 
	Then  Click on New button present in the Home page of Money Transaction  
	Then  Enter Account details and Tenant Details in Money Transaction page 
	Then  Select 'Approved' status for the New Money Transation 
	Then  Select 'DDP Refund' Transaction Type
	Then  Select 'ACH' Money Movement type
	Then  Enter Adjusted Total Dollar Ammount as '7000' and Total Dollar Amount as '7000'
	Then  Click on Today date link for settlement date. 
	Then  Enter Bank details Bank name as 'Bank of America', Bank ABN Num as '100235678', Bank Acc Num as '4444444444'
    Then  Select 'Wells Fargo' VRP Processing Bank
	Then  Click on save button
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OSVAtmos site
	Then  Navigates to Todays Transaction tab
	And   Verify 'DDP Refund' record in Treasury section
	Then  Logout from application
	Then  Verify the logout
	Then  Quit browser
	Then  Delete created transaction in Salesforce
	Then  Logout from Salesforce

@mytagP1
Scenario: Tax Refund >> ACH Money Movement Type - Create a new 'Money Transaction' with 'Approved' Status for current date
    Given Open browser 'chrome'
	Then  Navigate To SalesForce Url 
	Then  Login into Salesforce with valid credentials
	Then  Now click on Money Transcation Tab 
	Then  Click on New button present in the Home page of Money Transaction  
	Then  Enter Account details and Tenant Details in Money Transaction page 
	Then  Select 'Approved' status for the New Money Transation 
	Then  Select 'Tax Refund' Transaction Type
	Then  Select 'ACH' Money Movement type
	Then  Enter Adjusted Total Dollar Ammount as '7000' and Total Dollar Amount as '7000'
	Then  Click on Today date link for settlement date. 
	Then  Enter Bank details Bank name as 'Bank of America', Bank ABN Num as '100235678', Bank Acc Num as '5555555555'
    Then  Select 'Wells Fargo' VRP Processing Bank
	Then  Click on save button
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OSVAtmos site
	Then  Navigates to Todays Transaction tab
	And   Verify 'Tax Refund' record in Treasury section
	Then  Logout from application
	Then  Verify the logout
	Then  Quit browser
	Then  Delete created transaction in Salesforce
	Then  Logout from Salesforce
