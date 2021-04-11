Feature: Dojo Login
	As a customer of the Dojo platform
	I would like to access the website by logging in

@After
Scenario Outline: Validation error message is displayed when customers have invalid username and password

Given I am on the <login> page
When I enter a invalid <username> with <password>
And I click on the Loginbutton
Then the errorvalidation message <errorMessage> is displayed

Examples:
| login | username          | password  | errorMessage                                  |
| login | ajaytest@dojo.com | !password | Email and password combination not recognised |


Scenario Outline: Validation error message is displayed when customers email field is empty and password is entered
Given I am on the <login> page
When I enter a invalid <username> with <password>
Then the emailerrorvalidation message <emailerrorMessage> is displayed

Examples:
| login | username          | password | emailerrorMessage |
| login |                   | !password | Email required    |

Scenario Outline: Customer is able to reset their password
Given I am on the <login> page
When I click on the forgot your password link
And I enter a valid <email> 
And click on the email reset link
Then a <resetConfirmation> text is displayed

Examples:
| login | email         | resetConfirmation                                                                                                                   |
| login | test@dojo.com | Please check your inbox for instructions on how to reset your password. It may take a few minutes to come through.|

#Cannot be implemeted as sign up button is missing
#Scenario Outline: Customer should be able to open registration page on the dojo website
#Given I am on the <login> page
#When I click on signup button
#And the registration form is completed 
#Then I am logged in to dojo website

#Note this test shows some addition behaviours that cannot be demonstrated on Dojo login page provided
Scenario Outline: Check Weather 

Given I am on the bbc <relativepath>
When I do a search for the term <town>
Then the page is displayed with current <town>

Examples:
| relativepath | town   |
| weather      | London |