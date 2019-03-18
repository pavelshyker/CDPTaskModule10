Feature: CreateADraftAndSendBDDTests
	In order to create an email and send it
	As user
	I want to save it to the darft folder and send after

 Background: This is background
 Given I logged as a test user


Scenario Outline: Create a draft email
	Given I have created a new email on the start page with <emailAddress> and <emailSubject> and <emailText>
	When I saved it as a draft
	Then The email is saved to the draft page

	Examples: 
	| emailAddress     |  | emailSubject |  | emailText |
	| litmarsd@mail.ru |  | EmailSubject |  | EmailText |

Scenario Outline: Send a draft email
	Given I have navigated to the Send email page and deleted all
	And I have created a new email with <emailAddress> and <emailSubject> and <emailText>
	And I saved it as a draft
	When I sent a draft email
	Then The email is sent

	Examples: 
	| emailAddress     |  | emailSubject |  | emailText |
	| litmarsd@mail.ru |  | EmailSubject |  | EmailText |