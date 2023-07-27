Feature: login and create
open the opensource website ,login and create admin user in the site

	@MyTag
	Scenario: login and create admin user in orange
		Given open edge and invite the url "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login"
		When login in with admin user
		And open admin page
		Then click add button and open create user page
		And create and save the user
		And check weather if works success
