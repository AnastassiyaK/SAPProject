Feature: CheckTutorialNavigatorSearch
Put random word into the search input and check
that all tiles on the page has this word in their title
or description

Background:
Given A browser Chrome is set to launch

@positive
Scenario Outline: Search tutorial by a random word
	Given I have opened Tutorial Navigator page
	Given I have set searching word <words>
	Given I have entered the searching word in the input and press the search button
	Then The tutorial navigator page has tutorials with entered text in it's description or title

	Examples:
		| words                |
		| SAP                  |
		| SuccessFactors using |
		| a sample SAPUI5      |
#
#	Examples:
#		| browser |
#		| Chrome  |
#		| Firefox |
#		| IE      |