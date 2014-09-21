## 06. Unit Testing Services

1. Develop a REST API for a BugLogger app
	- Bugs have status:
		- fixed, assigned, for-testing, pending
	- Bugs have text and logDate
	- Newly added bugs always have status "pending"
	- Bugs can be queried – get all bugs, get bugs after a date, get only pending bugs, etc…
* Develop a database in MS SQL Server that keeps the data of the bugs
* Create repositories to work with the bugs database
* Provide a REST API to work with the bugs
	- Using WebAPI
	- Provide the following actions:
		- Log new bug `POST .../bugs`
		- Get all bugs `GET .../bugs`
		- Get bugs after a specific date: `GET .../bugs?date=22-06-2013`
		- Get bugs by status `GET .../bugs?type=pending`
		- Change bug status `PUT .../bugs/{id}`
* Write unit tests to test the BugLogger
	- Use a mocking framework
* Write integration tests to test the BugLogger

