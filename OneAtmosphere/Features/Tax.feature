Feature: Tax

@mytagP2P3Tax @yyy
Scenario: Verify Page Navigation to 'Tax' section by clicking on 'Ellipses' icon
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Quit browser

@mytagP2P3Tax @yyy
Scenario: Verify UI elements under 'Filter' wizard in 'Tax' page
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Clicked on Filter icon
	Then  Verified UI elements under Filter wizard
	Then  Quit browser

@mytagP2P3Tax @yyy
Scenario: Verify the functionality of 'Select All' checkbox, if it is selected by default in 'Filter' wizard
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Clicked on Filter icon
	Then Verified whether all companies are in selected state if Select All checkbox is checked by default
	Then Quit browser	

@mytagP1Tax @yyy
Scenario: Verify'Filter' icon and 'Select Company' wizard elements are functional in 'Tax' page
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Clicked on Filter icon
	Then Verified Select company wizard is displayed upon clicked on Filter icon
	Then Verify all companies should be selected when SELECT ALL checkbox is selected
	Then Verified whether all companies are in deselected state if Select All checkbox is unchecked 
	Then Quit browser

	#Features of 'Attention Needed' section at Tax Page Top level Links
@mytagP1Tax @yyy
Scenario: Verify 'Missing Power of Attorney' footer elements are functional
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Click on Missing Power of Attorney link
	Then Verify whether Missing Power of Attorney footer elements are functional
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify 'Invalid SSN#' footer elements are functional
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Click on Invalid SSN# link
	Then Verify whether Invalid SSN# footer elements are functional
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify 'Missing Tax ID/Account#' footer elements are functional
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Click on Missing Tax ID link
	Then Verify whether Missing Tax ID footer elements are functional
	Then Quit browser

#@mytagP1
#Scenario: Verify 'Download icon' in 'Missing Tax ID/Account#' section
#	Given Open browser 'chrome'
#	Then Navigate to url
#	Then Enter username and password and login into OneAtmos site
#	Given Landed on OneAtmos Home Page
#	Then Clicked on Ellipses icon under Tax section
#	Then Landed in Tax page and verified
#	Then Click on Missing Tax ID link
#	Then Click on Download excel down load button
#	Then Quit browser


@mytagP1Tax		#Need to look into.
Scenario: Verify 'Download icon' in 'Missing Power of Attorney' section
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'Attention Needed Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Click on Missing Power of Attorney link
	Then Click on Excel download icon under Details page
	Then Verify 'MissingPowerofAttorney' sheet after downloading 'Attention Needed Export' in Tax Page
	Then Quit browser

@mytagP1Tax		#Need to look into.
Scenario: Verify 'Download icon' in 'Missing Tax ID/Account#' section
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'Attention Needed Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Click on Missing Tax ID link
	Then Click on Excel download icon under Details page
	Then Verify 'MissingTaxID' sheet after downloading 'Attention Needed Export' in Tax Page
	Then Quit browser	

@mytagP1Tax		#Need to look into.
Scenario: Verify 'Download icon' in 'Invalid SSN#' section
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'Attention Needed Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verifieded
	Then Click on Invalid SSN# link
	Then Click on Excel download icon under Details page
	Then Verify 'InvalidSSN' sheet after downloading 'Attention Needed Export' in Tax Page
	Then Quit browser


    #Features of Downloads


@mytagP1Tax @yyy
Scenario: Verify by selecting 'Company Setup' from 'Downloads' drop-down
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'Company Setup Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Click on Downloads dropdown
	Then Select Company Setup option from Downloads dropdown
	Then Quit browser

	#Safari
@mytagP1Tax @yyy
Scenario: Verify by selecting 'Tax Setup' from 'Downloads' drop-down
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'Tax Setup Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Click on Downloads dropdown
	Then Select Tax Setup option from Downloads dropdown
	Then Quit browser


	#Features of Quarterly Balancing worklet

@mytagP2Tax @yyy
Scenario: Verify the Data under 'All tab' for 'Quarterly Balancing' section as per the selected values in drop-downs- 'Tax' section
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year  and quarter from the dropdowns in Quarterly Balancing section
	Then Verify results of All tab in Quarterly Balancing section
	Then Quit browser

	# Safari
@mytagP1Tax @yyy
Scenario: Verify 'Quarterly Balancing' screen of 'All Tab'
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year and quarter from the dropdown in Quarterly Balancing section and verify results
	Then Click on any number link under All tab under Quarterly Balancing section
	Then Verified Quarterly Balancing Results screen of All tab
	Then Quit browser

	#Need to discuss
@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Quarterly Balancing' screen Navigated from 'All' Tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'Quarterly Balancing Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year and quarter from the dropdown in Quarterly Balancing section and verify results
	Then Click on any number link under All tab under Quarterly Balancing section
	Then Click on Excel download icon under Details page	
	Then Verify 'QuarterlyBalancing_All' sheet after downloading 'Quarterly Balancing Detail Export' in Tax Page
	Then Quit browser

@mytagP2Tax @yyy
Scenario: Verify 'Federal Tab' in 'Quarterly Balancing' under 'Tax' section
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year  and quarter from the dropdowns in Quarterly Balancing section
	Then Click on Federal tab under Quarterly Balancing section
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify the Data under 'Federal tab' for 'Quarterly Balancing' section as per the selected values in drop-downs
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year  and quarter from the dropdowns in Quarterly Balancing section
	Then Click on Federal tab and verify results in Quarterly Balancing section
	Then Quit browser

	# updated
@mytagP1Tax @yyy
Scenario: Verify 'Quarterly Balancing' screen of 'Federal Tab'
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year  and quarter from the dropdowns in Quarterly Balancing section
	Then Click on Federal tab and verify results in Quarterly Balancing section
	Then Click on any number link under Federal tab under Quarterly Balancing section
	Then Verified Quarterly Balancing Results screen of Federal tab
	Then Quit browser

 # need to look into
@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Quarterly Balancing' screen Navigated from 'Federal Tab'
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'Quarterly Balancing Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year  and quarter from the dropdowns in Quarterly Balancing section
	Then Click on Federal tab and verify results in Quarterly Balancing section
	Then Click on any number link under Federal tab under Quarterly Balancing section
	Then Click on Excel download icon under Details page	
	Then Verify 'QuarterlyBalancing_Federal' sheet after downloading 'Quarterly Balancing Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify 'Quarterly Balancing' screen of 'State Tab'
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year  and quarter from the dropdowns in Quarterly Balancing section
	Then Click on State tab and verify results in Quarterly Balancing section
	Then Click on any number link under State tab under Quarterly Balancing section
	Then Verified Quarterly Balancing Results screen of State tab
	Then Quit browser

	# need to look into
@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Quarterly Balancing' screen Navigated from 'State' Tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'Quarterly Balancing Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year  and quarter from the dropdowns in Quarterly Balancing section
	Then Click on State tab and verify results in Quarterly Balancing section
	Then Click on any number link under State tab under Quarterly Balancing section
	Then Click on Excel download icon under Details page	
	Then Verify 'QuarterlyBalancing_State' sheet after downloading 'Quarterly Balancing Detail Export' in Tax Page
	Then Quit browser

	# Safari
@mytagP2Tax @yyy
Scenario: Verify 'Local' tab in 'Quarterly Balancing' under 'Tax' section
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year  and quarter from the dropdowns in Quarterly Balancing section
	Then Click on Local tab under Quarterly Balancing section
	Then Quit browser

	
@mytagP1Tax @yyy
Scenario: Verify the Data under 'Local tab' for 'Quarterly Balancing' section as per the selected values in drop-downs
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year  and quarter from the dropdowns in Quarterly Balancing section
	Then Click on Local tab and verify results in Quarterly Balancing section
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify 'Quarterly Balancing' screen of 'Local Tab'
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year  and quarter from the dropdowns in Quarterly Balancing section
	Then Click on Local tab and verify results in Quarterly Balancing section
	Then Click on any number link under Local tab under Quarterly Balancing section
	Then Verified Quarterly Balancing Results screen of Local tab
	Then Quit browser

	# need to look into
@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Quarterly Balancing' screen Navigated from 'Local' Tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'Quarterly Balancing Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year  and quarter from the dropdowns in Quarterly Balancing section
	Then Click on Local tab and verify results in Quarterly Balancing section
	Then Click on any number link under Local tab under Quarterly Balancing section
	Then Click on Excel download icon under Details page	
	Then Verify 'QuarterlyBalancing_Local' sheet after downloading 'Quarterly Balancing Detail Export' in Tax Page
	Then Quit browser

	# need to look into
@mytagP1Tax @yyy
Scenario: Verify Excel download icon under 'Quarterly Balancing' section for Tax service
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'Quarterly Balancing Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year  and quarter from the dropdowns in Quarterly Balancing section
	Then Click on Excel download icon under Quarterly Balancing worklet
	Then Quit browser


	#Features of Yearly Balancing worklet
@mytagP1Tax @yyy
Scenario: Verify the Data under 'All tab' for 'Yearly Balancing' section as per the selected values in drop-downs
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown in Yearly Balancing section and verify results
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify 'Yearly Balancing' screen of 'All Tab'
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown in Yearly Balancing section and verify results
	Then Click on any number link under All tab
	Then Verified Yearly Balancing Results screen of All tab
	Then Quit browser

	# need to look into
@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Yearly Balancing' screen Navigated from 'All' Tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'Yearly Balancing Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown in Yearly Balancing section and verify results
	Then Click on any number link under All tab
	Then Click on Excel download icon under Details page	
	Then Verify 'YearlyBalancing_All' sheet after downloading 'Yearly Balancing Detail Export' in Tax Page
	Then Quit browser

@mytagP2Tax @yyy
Scenario: Verify 'Federal' tab in 'Yearly Balancing' under 'Tax' section
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown in Yearly Balancing section
	Then Click on Federal tab in Yearly Balancing section
	Then Quit browser
	
@mytagP1Tax @yyy
Scenario: Verify the Data under 'Federal tab' for 'Yearly Balancing' section as per the selected values in drop-downs
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown in Yearly Balancing section
	Then Click on Federal tab and verify results in Yearly Balancing section
	Then Quit browser


@mytagP2Tax @yyy
Scenario: Verify 'State' tab in 'Yearly Balancing' under 'Tax' section
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown in Yearly Balancing section
	Then Click on State tab in Yearly Balancing section
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify the Data under 'State tab' for 'Yearly Balancing' section as per the selected values in drop-downs
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown in Yearly Balancing section
	Then Click on State tab and verify results in Yearly Balancing section
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify 'Yearly Balancing' screen of 'State Tab'
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown in Yearly Balancing section
	Then Click on State tab and verify results in Yearly Balancing section
	Then Click on any number link under State tab
	Then Verified Yearly Balancing Results screen of State tab
	Then Quit browser

	# need to look into
@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Yearly Balancing' screen Navigated from 'State' Tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'Yearly Balancing Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown in Yearly Balancing section
	Then Click on Federal tab and verify results in Yearly Balancing section
	Then Click on any number link under Federal tab
	Then Click on Excel download icon under Details page	
	Then Verify 'YearlyBalancing_State' sheet after downloading 'Yearly Balancing Detail Export' in Tax Page
	Then Quit browser

@mytagP2Tax @yyy
Scenario: Verify 'Local' tab in 'Yearly Balancing' under 'Tax' section
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown in Yearly Balancing section
	Then Click on Local tab in Yearly Balancing section
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify the Data under 'Local tab' for 'Yearly Balancing' section as per the selected values in drop-downs
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown in Yearly Balancing section
	Then Click on Local tab and verify results in Yearly Balancing section
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify 'Yearly Balancing' screen of 'Federal Tab'
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown in Yearly Balancing section
	Then Click on Federal tab and verify results in Yearly Balancing section
	Then Click on any number link under Federal tab
	Then Verified Yearly Balancing Results screen of Federal tab
	Then Quit browser

	# need to look into
@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Yearly Balancing' screen Navigated from 'Federal' Tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'Yearly Balancing Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown in Yearly Balancing section
	Then Click on Federal tab and verify results in Yearly Balancing section
	Then Click on any number link under Federal tab
	Then Click on Excel download icon under Details page	
	Then Verify 'YearlyBalancing_Federal' sheet after downloading 'Yearly Balancing Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify 'Yearly Balancing' screen of 'Local Tab'
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown in Yearly Balancing section
	Then Click on Local tab and verify results in Yearly Balancing section
	Then Click on any number link under Local tab
	Then Verified Yearly Balancing Results screen of Local tab
	Then Quit browser

	# need to look into
@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Yearly Balancing' screen Navigated from 'Local' Tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'Yearly Balancing Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown in Yearly Balancing section
	Then Click on Local tab and verify results in Yearly Balancing section
	Then Click on any number link under Local tab
	Then Click on Excel download icon under Details page	
	Then Verify 'YearlyBalancing_Local' sheet after downloading 'Yearly Balancing Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify Excel download icon under 'Yearly Balancing' section for Tax service
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'Yearly Balancing Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown in Yearly Balancing section
	Then Click on Excel download icon under Yearly Balancing worklet
	Then Quit browser

#Features of Daily Processing Results worklet 
@mytagP1Tax @yyy
Scenario: Verify Daily Processing Result's details for 'Payments'_All tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Click on Scheduled link for Payments and verify user navigated to Daily Processing Results  details screen of Payments 
	Then Verified Daily Processing Results details screen for Payments_All tab
	Then Quit browser

	# need to look into
@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Daily Processing Results' details screen for 'Payments'_ All tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Click on Scheduled link for Payments and verify user navigated to Daily Processing Results  details screen of Payments 
	Then Click on Excel download icon under Details page	
	Then Verify 'DailyProcessing_Payments_All' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify 'Daily Processing Results' details screen for 'Filings'_All tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Click on any number link for Filings in All tab under Daily Processing Results section
	Then Verified Daily Processing Results details screen for Filings_All tab
	Then Quit browser

	# need to look into
@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Daily Processing Results' screen for 'Filings'_All tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Click on any number link for Filings in All tab under Daily Processing Results section
	Then Click on Excel download icon under Details page	
	Then Verify 'DailyProcessing_Filings_All' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

	# Issue for selection of month
@mytagP2Tax
Scenario: Verify 'Federal' tab for 'Daily Processing Results' under 'Tax' section 
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any Month from the dropdown in Daily Processing Results
	Then Navigate to Federal tab of Daily Processing Results
	Then Quit browser

	# Issue for selection of month
@mytagP1Tax
Scenario: Verify 'Daily Processing Results' details screen for 'Filings'_Federal tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any Month from the dropdown in Daily Processing Results
	Then Navigate to Federal tab of Daily Processing Results
	Then Click on All link for Filings in Federal tab under Daily Processing Results section
	Then Verified Daily Processing Results details screen for Filings_Federal tab
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Daily Processing Results' screen for 'Filings'_Federal tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then  Navigate to Federal tab of Daily Processing Results
	Then Click on All link for Filings in Federal tab under Daily Processing Results section
	Then Click on Excel download icon under Details page	
	Then Verify 'DailyProcessing_Filings_Federal' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

	# Issue for selection of month
@mytagP1Tax
Scenario: Verify 'Daily Processing Results' details screen for 'Payments'_Federal tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Select any Month from the dropdown in Daily Processing Results
	Then  Navigate to Federal tab of Daily Processing Results
	Then  Click on All link for Payments in Federal tab under Daily Processing Results section
	Then  Verified Daily Processing Results details screen for Payments_Federal tab
	Then  Quit browser

@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Daily Processing Results' details screen for 'Payments'_ Federal tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then  Navigate to Federal tab of Daily Processing Results
	Then  Click on All link for Payments in Federal tab under Daily Processing Results section
	Then Click on Excel download icon under Details page	
	Then Verify 'DailyProcessing_Payments_Federal' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify Daily Processing Result's details for 'Payments'_Local tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Navigate to Local tab of Payments under Daily Processing Results
	Then Click on Scheduled link for Payments under local tab and verify user navigated to Daily Processing Results  details screen of Payments 
	Then Verified Daily Processing Results details screen for Payments_Local tab 
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Daily Processing Results' details screen for 'Payments'_ Local tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Navigate to Local tab of Payments under Daily Processing Results
	Then Click on Scheduled link for Payments under local tab and verify user navigated to Daily Processing Results  details screen of Payments 
	Then Click on Excel download icon under Details page	
	Then Verify 'DailyProcessing_Payments_Local' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify 'Daily Processing Results' details screen for 'Filings'_Local tab 
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Click on Local tab in Daily Processing Results section 
	Then Click on any number link for Filings in Local tab under Daily Processing Results section
	Then Verified Daily Processing Results screen for Filings_Local tab
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Daily Processing Results' screen for 'Filings'_Local tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Click on Local tab in Daily Processing Results section 
	Then Click on any number link for Filings in Local tab under Daily Processing Results section
	Then Click on Excel download icon under Details page	
	Then Verify 'DailyProcessing_Filings_Local' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify 'Daily Processing Results' details screen for 'Filings'_State tab 
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Navigate to state tab of Daily Processing Results 
	Then Click on Scheduled link of Filings and verify user navigated to Daily Processing Results details screen of Filings 
	Then Verified Daily Processing Results screen for Filings_State tab
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Daily Processing Results' screen for 'Filings'_State tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Navigate to state tab of Daily Processing Results 
	Then Click on Scheduled link of Filings and verify user navigated to Daily Processing Results details screen of Filings 
	Then Click on Excel download icon under Details page	
	Then Verify 'DailyProcessing_Filings_State' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

	# Issue for selecting a month 
@mytagP1Tax
Scenario: Verify 'Daily Processing Results' details screen for 'Payments'_State tab 
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Select any Month from the dropdown in Daily Processing Results
	Then  Navigate to state tab of Daily Processing Results 
	Then  Click on All link of Payments and verify user navigated to Daily Processing Results details screen of payments 
	Then  Verified Daily Processing Results screen for Payments_State tab
	Then Quit browser

	# Issue for selecting a month
@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Daily Processing Results' details screen for 'Payments'_ State tab 
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then  Select any Month from the dropdown in Daily Processing Results
	Then  Navigate to state tab of Daily Processing Results 
	Then  Click on All link of Payments and verify user navigated to Daily Processing Results details screen of payments 
	Then Click on Excel download icon under Details page	
	Then Verify 'DailyProcessing_Payments_State' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

	# Issue for selecting a month
@mytagP1Tax
Scenario: Verify the Data under 'All' tab for 'Daily processing Results' section as per the selected value in drop-downs
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Select any year from the dropdown and verify results of Daily Processing worklet are loaded
	Then  Quit browser

	# Issue for selecting a month
@mytagP1Tax
Scenario: Verify the Data under 'Federal' tab for 'Daily Processing Results' section as per the selected values in drop-downs- 'Tax' section
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Select any Month from the dropdown in Daily Processing Results
	Then  Navigate to Federal tab of Daily Processing Results
	Then  Verify results of Daily Processing Results worklet are loaded properly under Federal tab
	Then  Quit browser

@mytagP1Tax @yyy
Scenario: Verify 'State' tab for 'Daily Processing Results' under 'Tax'
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Navigate to state tab of Daily Processing Results
	Then  Quit browser

	# Issue for selecting a month
@mytagP1Tax
Scenario: Verify the Data under 'State' tab for 'Daily Processing Results' section as per the selected values in drop-downs- 'Tax' section
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Select any Month from the dropdown in Daily Processing Results
	Then  Navigate to state tab of Daily Processing Results
	Then  Verify results of Daily Processing Results worklet are loaded properly under State tab
	Then  Quit browser

	# Safari
@mytagP1Tax @yyy
Scenario: Verify 'Local' tab for 'Daily Processing Results' under 'Tax'
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Click on Local tab in Daily Processing Results section
	Then  Quit browser

	# Issue for selecting a month
@mytagP1Tax
Scenario: Verify the Data under 'Local' tab for 'Daily Processing Results' section as per the selected values in drop-downs- 'Tax' section
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Select any Month from the dropdown in Daily Processing Results
	Then  Click on Local tab in Daily Processing Results section
	Then  Verify results of Daily Processing Results worklet are loaded properly under local tab
	Then  Quit browser

	# Issue for selecting a month
@mytagP1Tax
Scenario: Verify Excel download icon under 'Daily Processing Results' section
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Summary Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then  Select any Month from the dropdown in Daily Processing Results
	Then Click on Excel download icon under Daily Processing Results worklet
	Then Quit browser

	#Features of 'Quarterly End Results' worklet 
@mytagP2Tax @yyy
Scenario: Verify 'All' tab for 'Quarterly End Results' under 'Tax' section
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Select year dropdown value under Quarter End Results section
	Then Verify whether the All tab is selected default in Quarter End Results while navigating to Tax page
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify 'Quarterly End Results' details for 'Payments'_All tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Click on Scheduled link for Payments and verify user navigated to Quarterly End Results details screen of Payments 
	Then Verified Quarterly End Results details screen for Payments_All tab
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Quarterly End Results' details screen for 'Payments'_ All tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Click on Scheduled link for Payments and verify user navigated to Quarterly End Results details screen of Payments 
	Then Click on Excel download icon under Details page	
	Then Verify 'QuarterEndResults_Payments_All' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser


@mytagP1Tax @yyy
Scenario: Verify 'Quarterly End Results' details screen for 'Filings'_All tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select year dropdown value under Quarter End Results section
	Then Click on any number link for Filings in All tab under Quarter End Results section
	Then Verify Quarter End Results screen for Filings_All tab
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Quarterly End Results' screen for 'Filings'_All tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select year dropdown value under Quarter End Results section
	Then Click on any number link for Filings in All tab under Quarter End Results section
	Then Click on Excel download icon under Details page	
	Then Verify 'QuarterEndResults_Filings_All' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify Quarterly End Results details for 'Payments'_Local tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Navigate to Local tab under Quarterly End Results
	Then Click on Scheduled link for Payments under local tab and verify user navigated to Quarterly End Results  details screen of Payments
	Then Verified Quarterly End Results details screen for Payments_Local tab 
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Quarterly End Results' details screen for 'Payments'_ Local tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Landed in Tax page and verified
	Then Navigate to Local tab under Quarterly End Results
	Then Click on Scheduled link for Payments under local tab and verify user navigated to Quarterly End Results  details screen of Payments
	Then Click on Excel download icon under Details page	
	Then Verify 'QuarterEndResults_Payments_Local' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify Quarterly End Results details for 'Payments'_Federal tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Select year dropdown value under Quarter End Results section
	Then  Navigate to Federal tab of Quarterly End Results
	Then  Click on Scheduled link for Payments under Federal tab and verify user navigated to Quarterly End Results  details screen of Payments
	Then  Verified Quarterly End Results details screen for Payments_Federal tab 
	Then  Quit browser

@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Quarterly End Results' details screen for 'Payments'_ Federal tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then  Select year dropdown value under Quarter End Results section
	Then  Navigate to Federal tab of Quarterly End Results
	Then  Click on Scheduled link for Payments under Federal tab and verify user navigated to Quarterly End Results  details screen of Payments
	Then Click on Excel download icon under Details page	
	Then Verify 'QuarterEndResults_Payments_Federal' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify Quarterly End Results details for 'Payments'_State tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Select year dropdown value under Quarter End Results section
	Then  Navigate to State tab of Quarterly End Results
	Then  Click on Scheduled link for Payments under State tab and verify user navigated to Quarterly End Results  details screen of Payments
	Then  Verified Quarterly End Results details screen for Payments_State tab 
	Then  Quit browser

@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Quarterly End Results' details screen for 'Payments'_ State tab 
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then  Select year dropdown value under Quarter End Results section
	Then  Navigate to State tab of Quarterly End Results
	Then  Click on Scheduled link for Payments under State tab and verify user navigated to Quarterly End Results  details screen of Payments
	Then Click on Excel download icon under Details page	
	Then Verify 'QuarterEndResults_Payments_State' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify Quarterly End Results details for 'Filings'_State tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Select year dropdown value under Quarter End Results section
	Then  Navigate to State tab of Quarterly End Results
	Then  Click on Scheduled link for Filings under State tab and verify user navigated to Quarterly End Results  details screen of Filings
	Then  Verified Quarterly End Results details screen for Filings_State tab 
	Then  Quit browser

@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Quarterly End Results' screen for 'Filings'_State tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then  Select year dropdown value under Quarter End Results section
	Then  Navigate to State tab of Quarterly End Results
	Then  Click on Scheduled link for Filings under State tab and verify user navigated to Quarterly End Results  details screen of Filings
	Then Click on Excel download icon under Details page	
	Then Verify 'QuarterEndResults_Filings_State' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify Quarterly End Results details for 'Filings'_Federal tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Select year dropdown value under Quarter End Results section
	Then  Navigate to Federal tab of Quarterly End Results
	Then  Click on Scheduled link for Filings under State tab and verify user navigated to Quarterly End Results  details screen of Filings
	Then  Verified Quarterly End Results details screen for Filings_Federal tab 
	Then  Quit browser

@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Quarterly End Results' screen for 'Filings'_Federal tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then  Select year dropdown value under Quarter End Results section
	Then  Navigate to Federal tab of Quarterly End Results
	Then  Click on Scheduled link for Filings under State tab and verify user navigated to Quarterly End Results  details screen of Filings
	Then Click on Excel download icon under Details page	
	Then Verify 'QuarterEndResults_Filings_Federal' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax @yyy
Scenario: Verify Quarterly End Results details for 'Filling'_Local tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Navigate to Local tab under Quarterly End Results
	Then Click on any number link for Filings in Local tab under Quarter End Results section
	Then Verify Quarter End Results screen for Filings_Local tab
	Then Quit browser


@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Quarterly End Results' screen for 'Filings'_Local tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Navigate to Local tab under Quarterly End Results
	Then Click on any number link for Filings in Local tab under Quarter End Results section
	Then Click on Excel download icon under Details page	
	Then Verify 'QuarterEndResults_Filings_Local' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP2Tax @yyy
Scenario:  Verify 'Local' tab for 'Quarterly End Results' under 'Tax' section
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Navigate to Local tab under Quarterly End Results
	Then  Quit browser

@mytagP1Tax @yyy
Scenario: Verify the Data under 'Local' tab for 'Quarterly End Results' section as per the selected values in drop-downs- 'Tax' section
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Navigate to Local tab under Quarterly End Results
	Then  Verify results of Quarterly End Results worklet are loaded
	Then  Quit browser

@mytagP2Tax @yyy
Scenario: Verify 'Federal' tab for 'Quarterly End Results' under 'Tax' section
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Navigate to Federal tab of Quarterly End Results
	Then  Quit browser

@mytagP1Tax @yyy
Scenario: Verify the Data under 'Federal' tab for 'Quarterly End Results' section as per the selected values in drop-downs- 'Tax' section
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Select year dropdown value under Quarter End Results section
	Then  Navigate to Federal tab of Quarterly End Results
	Then  Verify results of Quarterly End Results worklet are loaded properly under Federal tab
	Then  Quit browser

@mytagP2Tax @yyy
Scenario: Verify 'State' tab for 'Quarterly End Results' under 'Tax' section 
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Navigate to State tab of Quarterly End Results
	Then  Quit browser

	#Safari
@mytagP1Tax @yyy
Scenario: Verify the Data under 'State' tab for 'Quarterly End Results' section as per the selected values in drop-downs- 'Tax' section
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Select year dropdown value under Quarter End Results section
	Then  Navigate to State tab of Quarterly End Results
	Then  Verify results of Quarterly End Results worklet are loaded properly under State tab
	Then  Quit browser

	#Safari
@mytagP1Tax @yyy
Scenario: Verify the Data under 'All' tab for 'Quarterly End Results' section as per the selected values in drop-downs- 'Tax' section
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Select year dropdown value under Quarter End Results section
	Then  Verify results of Quarterly End Results worklet are loaded properly under All tab
	Then  Quit browser


@mytagP1Tax @yyy
Scenario: Verify Excel download icon under 'Quarterly End Results' section
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Summary Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then  Select year dropdown value under Quarter End Results section
	Then Click on Excel download icon under Year End Results worklet
	Then Quit browser

# Features of 'Year End Results' Worklet
@mytagP1Tax
Scenario: Verify the Data under 'All' tab for 'Year End Results' section as per the selected values in drop-downs
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown and verify results
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Year End Results' details screen for 'Filings'_All tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown and verify results
	Then Click on any number link for Filings in All tab under Year End Results section
	Then Verify Year End Results screen for Filings_All tab
	Then Quit browser


@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Year End Results' screen for 'Filings'_All tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown and verify results
	Then Click on any number link for Filings in All tab under Year End Results section
	Then Click on Excel download icon under Details page	
	Then Verify 'YearEndResults_Filings_All' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser


@mytagP1Tax
Scenario: Verify 'Year End Results' details screen for 'Payments'_All tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown and verify results
	Then Click on any number link for Payments in All tab under Year End Results section
	Then Verify Year End Results screen for Payments_All tab
	Then Quit browser


@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Year End Results' details screen for 'Payments'_ All tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown and verify results
	Then Click on any number link for Payments in All tab under Year End Results section
	Then Click on Excel download icon under Details page	
	Then Verify 'YearEndResults_Payments_All' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Year End Results' details screen for 'Filings'_Federal tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Select any year from the dropdown and verify results
	Then  Click on Federal tab under Year End Results section and verify data
	Then  Click on any number link for Filings in Federal tab under Year End Results section
	Then  Verify Year End Results screen for Filings_Federaltab
	Then  Quit browser

@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Year End Results' screen for 'Filings'_Federal tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then  Select any year from the dropdown and verify results
	Then  Click on Federal tab under Year End Results section and verify data
	Then  Click on any number link for Filings in Federal tab under Year End Results section
	Then Click on Excel download icon under Details page	
	Then Verify 'YearEndResults_Filings_Federal' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Year End Results' details screen for 'W2Filings'_All tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Select any year from the dropdown and verify results
	Then  Click on any number link for W2Filings in All tab under Year End Results section
	Then  Verify Year End Results screen for W2Filings_Alltab
	Then  Quit browser


@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Year End Results' screen for 'W2 Filings'_All tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Select any year from the dropdown and verify results
	Then  Click on any number link for W2Filings in All tab under Year End Results section
	Then Click on Excel download icon under Details page	
	Then Verify 'YearEndResults_W2Filings_All' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Year End Results' details screen for 'Payments'_Federal tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Select any year from the dropdown and verify results
	Then  Click on Federal tab under Year End Results section and verify data
	Then  Click on any number link for Payments in Federal tab under Year End Results section
	Then  Verify Year End Results screen for Payments_ Federaltab
	Then  Quit browser

@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Year End Results' details screen for 'Payments'_ Federal tab 
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then  Select any year from the dropdown and verify results
	Then  Click on Federal tab under Year End Results section and verify data
	Then  Click on any number link for Payments in Federal tab under Year End Results section
	Then Click on Excel download icon under Details page	
	Then Verify 'YearEndResults_Payments_Federal' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Year End Results' details screen for 'W2 Filings_Federal tab
	Given Open browser 'chrome'
	Then  Navigate to url
	Then  Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then  Clicked on Ellipses icon under Tax section
	Then  Landed in Tax page and verified
	Then  Select any year from the dropdown and verify results
	Then  Click on Federal tab under Year End Results section and verify data
	Then  Click on any number link for W2Filings in Federal tab under Year End Results section
	Then  Verify Year End Results screen for W2Filings_ Federaltab
	Then  Quit browser

@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Year End Results' screen for 'W2 Filings'_Federal tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then  Select any year from the dropdown and verify results
	Then  Click on Federal tab under Year End Results section and verify data
	Then  Click on any number link for W2Filings in Federal tab under Year End Results section
	Then Click on Excel download icon under Details page	
	Then Verify 'YearEndResults_W2Filings_Federal' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax
Scenario:  Verify the Data under 'Federal' tab for 'Year End Results' section as per the selected values in drop-downs
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown
	Then Click on Federal tab under Year End Results section and verify data
	Then Quit browser

@mytagP1Tax
Scenario: Verify the Data under 'State' tab for 'Year End Results' section as per the selected values in drop-downs- 'Tax' section
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown
	Then Click on State tab under Year End Results section and verify data
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Year End Results' details screen for 'Filings'_State tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown
	Then Click on State tab under Year End Results section and verify data
	Then Click on any number link for Filings in State tab under Year End Results section
	Then Verify Year End Results screen for Filings_State tab
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Year End Results' screen for 'Filings'_State tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown
	Then Click on State tab under Year End Results section and verify data
	Then Click on any number link for Filings in State tab under Year End Results section
	Then Click on Excel download icon under Details page	
	Then Verify 'YearEndResults_Filings_State' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'State' tab for 'Year End Results' under 'Tax' section
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Click on State tab under Year End Results section and verify data

@mytagP1Tax
Scenario: Verify 'Year End Results' details screen for 'W2 Filings'_State tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown
	Then Click on State tab under Year End Results section and verify data
	Then Click on any number link for W2Filings in State tab under Year End Results section
	Then Verify Year End Results screen for W2Filings_State tab
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Year End Results' screen for 'W2 Filings'_State tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown
	Then Click on State tab under Year End Results section and verify data
	Then Click on any number link for W2Filings in State tab under Year End Results section
	Then Click on Excel download icon under Details page	
	Then Verify 'YearEndResults_W2Filings_State' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax
Scenario: Verify the Data under 'Local' tab for 'Year End Results' section as per the selected values in drop-downs- 'Tax' section
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown 
	Then Click on Local tab under Year End Results section and verify data
	Then Quit browser

@mytagP1Tax
Scenario: Verify  'Year End Results' details for 'Payments'_State tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown 
	Then Click on State tab under Year End Results section and verify data
	Then Click on any number link for Payments in State tab under Year End Results section
	Then Verify Year End Results screen for Payments_State tab
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Year End Results' details screen for 'Payments'_ State tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown 
	Then Click on State tab under Year End Results section and verify data
	Then Click on any number link for Payments in State tab under Year End Results section
	Then Click on Excel download icon under Details page	
	Then Verify 'YearEndResults_Payments_State' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Year End Results' details screen for 'Filings'_Local tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown 
	Then Click on Local tab under Year End Results section and verify data 
	Then Click on any number link for Filings in Local tab under Year End Results section
	Then Verify Year End Results screen for Filings_Local tab
	Then Quit browser


@mytagP1Tax
Scenario:  Verify 'Excel Download' icon in 'Year End Results' screen for 'Filings'_Local tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown 
	Then Click on Local tab under Year End Results section and verify data 
	Then Click on any number link for Filings in Local tab under Year End Results section
	Then Click on Excel download icon under Details page	
	Then Verify 'YearEndResults_Filings_Local' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Year End Results' details screen for 'W2 Filings'_Local tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown 
	Then Click on Local tab under Year End Results section and verify data 
	Then Click on any number link for W2Filings in Local tab under Year End Results section
	Then Verify Year End Results screen for W2Filings_Local tab
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Year End Results' screen for 'W2 Filings'_Local tab 
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown 
	Then Click on Local tab under Year End Results section and verify data 
	Then Click on any number link for W2Filings in Local tab under Year End Results section
	Then Click on Excel download icon under Details page	
	Then Verify 'YearEndResults_W2Filings_Local' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Year End Results' details screen for 'Payments'_Local tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown 
	Then Click on Local tab under Year End Results section and verify data 
	Then Click on any number link for Payments in Local tab under Year End Results section
	Then Verify Year End Results screen for Payments_Local tab
	Then Quit browser

@mytagP1Tax
Scenario: Verify 'Excel Download' icon in 'Year End Results'  details screen for 'Payments'_ Local tab
	Given Open browser 'chrome'
	Then Navigate to url
	Then Enter username and password and login into OneAtmos site
	Given Landed on OneAtmos Home Page
	Given Set location for downloaded 'End Results Detail Export' sheet
	Then Clicked on Ellipses icon under Tax section
	Then Landed in Tax page and verified
	Then Select any year from the dropdown 
	Then Click on Local tab under Year End Results section and verify data 
	Then Click on any number link for Payments in Local tab under Year End Results section
	Then Click on Excel download icon under Details page	
	Then Verify 'YearEndResults_Payments_Local' sheet after downloading 'End Results Detail Export' in Tax Page
	Then Quit browser



