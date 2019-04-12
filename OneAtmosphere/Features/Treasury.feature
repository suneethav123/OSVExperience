Feature: Treasury
	
@mytagP1
Scenario: Verification of Footer elements under 'Not Fully Funded' tab of Treasury page upon changing the page number from default value 1
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Click on Ellipses Menu available at Treasury section
	Then Change Page Number count and verify state of footer buttons
	Then  Quit browser

@mytagP1
Scenario: Verify whether correct number of records are displayed under 'Not Fully funded' tab when user changes "Records per page"
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Click on Ellipses Menu available at Treasury section
	Then Verify the functionality of Records Per Page dropdown in Not Fully Funded tab
	Then  Quit browser

@mytagP1
Scenario: Verify footer button functionality under Not Fully Funded Tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Click on Ellipses Menu available at Treasury section
	Then Verify the functionality of Footer buttons in Not Fully Funded tab
	Then Quit browser

	#Safari
@mytagP2P3
Scenario: Verification of UI Elements under 'Not Fully Funded' tab, 'Today's Transaction' tab and 'Fully Funded' tab of Treasury page 
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Click on Ellipses Menu available at Treasury section
	Then  Verify UI Elements available in the Not Fully Funded tab
	Given Navigate to Todays Transaction tab
	Then  Verify UI Elements available in the Todays Transaction tab
	Given Navigate to Fully Funded Tab
	Then  Verify UI Elements available in the Fully Funded tab
	Then  Quit browser

@mytagP2
Scenario: Verify page navigation to 'Dashboard' page from 'Not Fully Funded' by clicking on 'Browser Back' button
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Click on Ellipses Menu available at Treasury section
    Then Navigate back to Home Page using browser back
	Then Quit browser

@mytagP2
Scenario: Verify "First","Previous","Next" &"Past" buttons are disabled state when "Not Fully funded" tab has less than 10 records
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Click on Ellipses Menu available at Treasury section
	Then Verify footer buttons in Not Fully Funded tab when there are less than 10 records
	Then Quit browser

#@mytagP2
#Scenario: Verify Sorting functionality of 'Transaction Type', 'Movement Type' and 'Currency' columns under Not Fully Funded tab
#	Given Open browser 'chrome'
#	Then  Navigate to url
#	Then  Enter username and password and login into OneAtmos site
#	Given Landed on OneAtmos Home Page
#	Then  Click on Ellipses Menu available at Treasury section
#	Then Verify Sorting functionality of 'Transaction Type'
#	Then Verify Sorting functionality of 'Movement Type'
#	Then Verify Sorting functionality of 'Currency'
#	Then Quit browser


#Safari
@mytagP1
Scenario: Verification of Today's Transaction count available in Home page is Matching with Records displayed in 'Today's Transaction' tab of Treasury page
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Get the count of Todays Transaction present in Home page under Treasury section and Click on Todays Transaction link 
	Then  Verify the Number of records displayed Today's Transaction Tab with number of records displayed in Home page
	Then  Quit browser

@mytagP2
Scenario: Verify 'Fully Funded' tab 
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Click on Ellipses Menu available at Treasury section
	Given Navigate to Fully Funded Tab
	Then Quit browser


@mytagP1
Scenario: Verify 'Custom' Dropdown with different values in 'Fully Funded' tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Click on Ellipses Menu available at Treasury section
	Given Navigate to Fully Funded Tab
	Then Verify Custom Dropdown with different values
	Then Quit browser

@mytagP1
Scenario: Verify the 'Search Box' functionality with 'Detail Id' under 'Fully Funded' tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Click on Ellipses Menu available at Treasury section
	Given Navigate to Fully Funded Tab
	Then Select From Date '06/29/2017' And To Date '07/31/2019' on Fully Funded tab
	Then Verify Search Box functionality with Detail Id
	Then  Quit browser

@mytagP1
Scenario: Verify "First","Previous","Next" &"Past" buttons are Enabled state when user changes page number count other than value '1' - Under 'Fully Funded' tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Click on Ellipses Menu available at Treasury section
	Given Navigate to Fully Funded Tab
	Then Select From Date '06/29/2017' And To Date '07/31/2019' on Fully Funded tab
	Then Change Page Number count and verify state of footer buttons
	Then Quit browser

@mytagP1
Scenario: Verify Currency checkboxes with different selections in Fully Funded tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Click on Ellipses Menu available at Treasury section
	Given Navigate to Fully Funded Tab
	Then Select From Date '06/29/2017' And To Date '07/31/2019' on Fully Funded tab
	Then Verify all currency checkboxes with different selections
	Then Quit browser

@mytagP1
Scenario: Verify the correct number of records are displayed under 'Fully Funded' tab when user changes "Records per page" count value
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Click on Ellipses Menu available at Treasury section
	Given Navigate to Fully Funded Tab
	Then Select From Date '06/29/2017' And To Date '07/31/2019' on Fully Funded tab
	Then Verify the functionality of Records Per Page dropdown in Fully Funded tab
	Then Quit browser

@mytagP1
Scenario: Verify records by selecting both 'Dates' and 'Currencies' under 'Fully Funded' tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Click on Ellipses Menu available at Treasury section
	Given Navigate to Fully Funded Tab
	Then Select From Date '06/29/2017' And To Date '07/31/2019' on Fully Funded tab
	Then Verify Fully Funded records lies between From Date '06/29/2017' and To Date '07/31/2019'
	Then Quit browser

@mytagP1
Scenario: Verify the functionality of 'From' and 'To' calendars in 'Fully Funded' tab 
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Click on Ellipses Menu available at Treasury section
	Given Navigate to Fully Funded Tab
	Then Verify by selecting Today link in From and To calendars
	Then Select From Date '06/29/2017' And To Date '07/31/2019' on Fully Funded tab
	Then Verify Fully Funded records lies between From Date '06/29/2017' and To Date '07/31/2019'
	Then Quit browser

@mytagP1
Scenario: Verify footer buttons are Enabled state when user changes page number count other than value '1' - Under 'Todays Transaction' tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Click on Ellipses Menu available at Treasury section
	Given Navigate to Todays Transaction tab
	Then Change Page Number count and verify state of footer buttons
	Then Quit browser

@mytagP1
Scenario:Verify the Records Per Page Dropdown functionality in Today's Transaction tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Click on Ellipses Menu available at Treasury section
	Given Navigate to Todays Transaction tab
	Then Verify the functionality of Records Per Page Dropdown in Todays Transaction tab
	Then Quit browser

@mytagP2
Scenario:  Verify "First","Previous","Next" &"Past" buttons are disabled state when 'Today's Transactions' tab has less than 10 records
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Click on Ellipses Menu available at Treasury section
	Given Navigate to Todays Transaction tab
	Then Verify footer buttons in Todays Transactions tab when there are less than 10 records
	Then Quit browser

@mytagP2
Scenario: Verify "First","Previous","Next" &"Past" buttons are disabled state when 'Fully Funded' tab has less than 10 records
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Click on Ellipses Menu available at Treasury section
	Given Navigate to Fully Funded Tab
	Then Verify by selecting Today link in From and To calendars
	Then Verify footer buttons in Fully Funded tab when there are less than 10 records
	Then Quit browser

@mytagP2
Scenario: Verify the functionality of footer buttons in Fully Funded Page
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Click on Fully Funded link in Home page
	Then Select From Date '06/29/2017' And To Date '07/31/2019' on Fully Funded tab
	Then Verify the functionality of footer buttons in Fully Funded page
	Then Quit browser

	#Safari
@mytagP2
Scenario: Verify the functionality of footer buttons in Today's Transactions Page
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Click on Fully Funded link in Home page
	Given Navigate to Todays Transaction tab
	Then Verify the functionality of footer buttons in Todays' Transactions Page
	Then Quit browser

	#Safari
@mytagP1
Scenario: Verify that user is able to download "ExcelReport" by clicking on 'Download' Button available at right corner of Treasury page
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'ExcelReport' sheet
	Then  Click on Ellipses Menu available at Treasury section
	Then Click on Excel download icon under Not Fully Funded tab
	Then Quit browser
