Feature: LoginBddTest
	In order to send an email
	As a user
	I want to login to mail.ru website

@mytag
Scenario Outline: Login to mail.ru website
	When I entered <username> and <password>
	Then I should see my emailbox

	Examples: 
	| username    |  | password   |
	| testuser.19 |  | testCDP123 |
	| testuser.20 |  | testCDP123 |
