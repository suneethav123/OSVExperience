Feature: LoginHomeMyAccountTax

#Login Page scenarios
@mytagP2
Scenario: Verification of UI elements of Login page
	Given Open browser 'chrome'
	Then Navigate to url
	Then Verified UI elements of Login Page
	Then Quit browser

@mytagP1
Scenario: Login and Logout verification in OneAtmos site
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Logout from application
	Then  Verify the logout
	Then  Quit browser
 
@mytagP2@P3
Scenario: Verify error message with valid username and empty password
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and without password and login into OneAtmos site
	Then  Verify error message
	Then  Quit browser
 
@mytagP2
Scenario: Verify 'Login' functionality with empty 'Username' and 'Password'
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Click on SignIn button with empty UserName and Password
	Then  Verify error message upon clicking on SignIn button with empty UserName and Password
	Then  Quit browser

@mytagP2
Scenario: Verify 'Login' functionality with empty 'Username' and valid 'Password' 
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Click on SignIn button with valid empty Username and valid Password
	Then  Verify error message upon clicking SignIn button with empty Username and valid Password
	Then  Quit browser

@mytagP2
Scenario: Verify 'Login' functionality with incorrect 'Username' and 'Password'
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Click on SignIn button with incorrect details such Username as 'testing@zenq.com' and Password as 'testing'
	Then  Verify error message upon clicking on SignIn button with Incorrect UserName and Password
	Then  Quit browser

@mytagP2
Scenario:  Verify 'Forgot Your Password?' link
   Given Open browser 'chrome'
   Then  Navigate to url
   Then  Clicked on Forgot Password link in Login Page and verified whether user is navigated to Forgot Password page   
   Then  Quit browser	


@mytagP2P3
Scenario: Verify 'Cancel' link in 'Send Password Email Reset' popup
   Given Open browser 'chrome'
   Then  Navigate to url
   Then  Clicked on Forgot Password link in Login Page and verified whether user is navigated to Forgot Password page   
   Then  Clicked on Cancel link under Forgot Password Page
   Then  Quit browser	

@mytagP2P3
Scenario: Verify page navigation, by clicking on 'My Account' link
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on My Account Link in Home Page
	Then  Verify page navigation to Invoicing tab
	Then  Quit browser

@mytagP1
Scenario: Verify whether user is navigated to 'Dashboard' upon clicking on "OneAtmosphere" logo available at the Page header 
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on My Account Link in Home Page 
	And   Verify page navigation to Invoicing tab
	Then  Clicked on One Atmosphere logo
	Then  Verified Home page
	Then  Quit browser

@mytagP2
Scenario: Verify UI elements under 'Home' page
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Verified UI elements under Home page
	Then Quit browser


@mytagP2
Scenario: Verify page navigation to Invoice details page and the functionality of 'Back to Previous Page' link  under 'Invoice Details' page
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on My Account Link in Home Page
	Then  Verify page navigation to Invoicing tab
	Then Select From Date '06/29/2017' And To Date '07/31/2019' on Invoicing tab 
	Then  Clicked on Invoice Number and verify whether navigated to Invoicing Deatils page
	Then  Click on Back to previous page link
	Then  Quit browser

@mytagP2
Scenario: Verify UI elements under Invoicing tab and Invoicing details page
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on My Account Link in Home Page
	Then  Verify page navigation to Invoicing tab
	Then Select From Date '06/29/2017' And To Date '07/31/2019' on Invoicing tab
	And   Verified UI elements of Invoicing tab  
	Then  Clicked on Invoice Number and verify whether navigated to Invoicing Deatils page
	Then  Verify UI Elements of invoice details page
	Then  Click on Back to previous page link
	Then  Quit browser

@mytagP1
Scenario: Verify Records PerPage drop-down with different values in 'Invoicing' tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on My Account Link in Home Page
	Then  Verify page navigation to Invoicing tab
	Then Select From Date '06/29/2017' And To Date '07/31/2019' on Invoicing tab	
	Then Verify Records Per Page drop-down in Invoicing tab with different values
	Then  Quit browser

@mytagP1
Scenario: Verify functionality of Footer buttons in 'Invoicing' tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on My Account Link in Home Page
	And   Verify page navigation to Invoicing tab
	Then Select From Date '06/29/2017' And To Date '07/31/2019' on Invoicing tab	
	Then  Verified functionality of First,Previous,Next and Last buttons in Invoicing tab
	Then  Quit browser

#@mytag
#Scenario: Verify UI elements under Invoicing tab and Invoicing details page
#	Given Open browser 'chrome'
#	Then  Navigate to url
#	Then  Enter username and password and login into OneAtmos site
#	Given Landed on OneAtmos Home Page
#	Then Click on 'Fully Funded' link
#	Then  Quit browser


@mytagP2P3
Scenario: Verify UI elements and navigation in ‘Contracts’ tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on My Account Link in Home Page
	And   Verify page navigation to Invoicing tab
	Then  Clicked and verified Contracts tab in My Account Page
	And   Verified UI elements under Contracts tab
	Then  Clicked on Contract Number under Contracts tab
	Then  Verified UI elements under Contract Detail page
	Then  Clicked on Back To Previous Page link under Contract Details Page
	Then  Quit browser

@mytagP2
Scenario: Verify the UI Elements are available in Contract Details page
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on My Account Link in Home Page
	And Verify page navigation to Invoicing tab
	Then Clicked and verified Contracts tab in My Account Page
	Then Clicked on Contract Number under Contracts tab
	Then Verified details in Contract Detail page
	Then Clicked on Back To Previous Page link under Contract Details Page
	Then Quit browser

#@mytag
#Scenario: Verifying 'Contract Number'column whether it is in sorted order
#	Given Open browser 'chrome'
#	Then Navigate to url
#	Then Enter username and password and login into OneAtmos site
#	Given Landed on OneAtmos Home Page
#	Then Clicked on My Account Link in Home Page
#	And Verify page navigation to Invoicing tab
#	Then Clicked and verified Contracts tab in My Account Page
#	#Then Verified Contract Numbers are in sorted order or not
#	Then Click on Contract Number column and verify whether the elements are in Descending order
#	Then Quit browser

@mytagP2P3
Scenario: Verify UI elements under 'Documents' tab in 'My Account' page
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on My Account Link in Home Page
	And Verify page navigation to Invoicing tab
	Then Clicked and verified Documents tab in My Account Page
	Then Verified UI elements under Documents tab
	Then Quit browser

@mytagP2
Scenario: Verify page navigation, by clicking on 'Documents' tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on My Account Link in Home Page
	And   Verify page navigation to Invoicing tab
	Then  Clicked and verified Documents tab in My Account Page
	Then  Quit browser

@mytagP2
Scenario: Verify  'OSV Admin Services Guide' document
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on My Account Link in Home Page
	And   Verify page navigation to Invoicing tab
	Then  Clicked and verified Documents tab in My Account Page
	Then Click on OSV Admin Services Guide and verify it
	Then  Quit browser

@mytagP2
Scenario: Verify by clicking on 'OSV Admin Services Guide (CANADA)' document
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on My Account Link in Home Page
	And   Verify page navigation to Invoicing tab
	Then  Clicked and verified Documents tab in My Account Page
	Then Click on OSV Admin Services Guide_CANADA link and verify it
	Then  Quit browser

@mytagP2
Scenario: Verify by clicking on 'Workday Soc1 Report' in 'Control Documents' under 'Documents' section
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on My Account Link in Home Page
	And   Verify page navigation to Invoicing tab
	Then  Clicked and verified Documents tab in My Account Page
	Then Click on Workday SocOne Report link under Control Documents and verify it
	Then  Quit browser

@mytagP2
Scenario: Verify by clicking on 'Workday Soc2 Report' in 'Control Documents' under 'Documents' section
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on My Account Link in Home Page
	And   Verify page navigation to Invoicing tab
	Then  Clicked and verified Documents tab in My Account Page
	Then Click on Workday SocTwo Report link under Control Documents and verify it
	Then  Quit browser

@mytagP1
Scenario: Verification  of Records per  page drop down in contracts tab with all the options 
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on My Account Link in Home Page
	And Verify page navigation to Invoicing tab
	Then Clicked and verified Contracts tab in My Account Page
	Then Verified Records Per Page Drop-Down in Contracts tab
	Then Quit browser

@mytagP1
Scenario: Verification of Footer elements under 'Contracts' tab of My Account page upon changing the page number from default value 1
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on My Account Link in Home Page
	And  Verify page navigation to Invoicing tab
	Then Clicked and verified Contracts tab in My Account Page
	Then Changed Page Number Count textbox value in Contracts
	Then Quit browser

@mytagP1
Scenario: Verify functionality of Footer buttons in 'Contracts' tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on My Account Link in Home Page
	And   Verify page navigation to Invoicing tab
	Then  Clicked and verified Contracts tab in My Account Page
	Then  Verified functionality of First,Previous,Next and Last buttons in Contracts page
	Then  Quit browser

@mytagP1
Scenario: Verification of Footer elements under 'Invoicing' tab of My Account page upon changing the page number from default value 1
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on My Account Link in Home Page
	And  Verify page navigation to Invoicing tab
	Then Select From Date '06/29/2017' And To Date '07/31/2019' on Invoicing tab
	Then Changed Page Number Count textbox value
	Then Quit browser

@mytagP1
Scenario: Verify 'From Calendar' date is advanced to 'To Calendar' date in 'Invoicing'
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on My Account Link in Home Page
	And  Verify page navigation to Invoicing tab
	Then Select From Date '06/29/2017' And To Date '05/01/2017' on Invoicing tab
	Then Quit browser

@mytagP1
Scenario: Verify 'Today' link in both 'From' and 'To' calendars in 'Invoicing' tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on My Account Link in Home Page
	And  Verify page navigation to Invoicing tab
	Then Verified Today link in From calendar
	Then Verified Today link in To calendar
	Then Quit browser

@mytagP1
Scenario: Verify Records in 'Invoicing' Table by selecting From and To Dates
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on My Account Link in Home Page
	And   Verify page navigation to Invoicing tab	
	Then Select From Date '06/29/2017' And To Date '09/30/2019' on Invoicing tab
	Then Verify Invoicing Dates lies between From Date '06/29/2017' and To Date '09/30/2019'
	Then  Quit browser

@mytagP1
Scenario: Verify 'Total Amount Due' and 'Past Amount Due' values in 'Invoicing'
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on My Account Link in Home Page
	And   Verify page navigation to Invoicing tab	
	Then Select From Date '06/29/2017' And To Date '09/30/2019' on Invoicing tab
	Then Verify Total Amount Due in Invoicing tab
	Then Verify Past Due Amount in invoicing tab
	Then  Quit browser

@mytagP2
Scenario: Verify user is navigated  to 'Not Fully Funded' page when clicked on 'Balance' sector of 'payroll collection' pie chart  present in  Treasury section
    Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Click on Pie chart of Payroll Collection in Home Page
	Then Verify whether the user is navigated to NotFullyFunded page
	Then  Quit browser

@mytagP2
Scenario: Verify user is navigated  to 'Not Fully Funded' page when clicked on 'Balance' sector of 'Tax Collection' pie chart  present in  Treasury section
    Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Click on Pie chart of Tax Collection in Home Page
	Then Verify whether the user is navigated to NotFullyFunded page
	Then  Quit browser

@mytagP2
Scenario: Verify user is navigated  to 'Not Fully Funded' page when clicked on 'Balance' sector of 'Garn Collection' pie chart  present in  Treasury section
    Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Click on Pie chart of Garn Collection in Home Page
	Then Verify whether the user is navigated to NotFullyFunded page
	Then  Quit browser

@mytagP2
Scenario: Verify 'Fully funded' link navigates to Fully Funded section of treasury page
    Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Click on Fully Funded link in Home page
	Then Verify whether the user is navigated to Fully Funded page
	Then  Quit browser

@mytagP2
Scenario: Verify the functionality of header elements in Dashboard page
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on My Account Link in Home Page
	Then  Verify page navigation to Invoicing tab
	Then Clicked on One Atmosphere logo
	Given Click on User Account dropdown in Home Page and Verify results
	Then  Quit browser

@mytagP2
Scenario: Verify user is navigated  to 'Treasury Page' when clicked on 'ellipsis menu' present at top of Treasury section
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Click on Ellipses Menu available at Treasury section
	Then  Quit browser


	


