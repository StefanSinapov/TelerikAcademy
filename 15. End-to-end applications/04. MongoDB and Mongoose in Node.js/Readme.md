## 04. MongoDB and Mongoose in Node.JS

1. Create a modules for Chat, that keep the data into a local MongoDB instance
	* The module should have the following functionality:
	```javascript
	var chatDb = require('chat-db');
	//inserts a new user records into the DB
	chatDb.registerUser({user: 'DonchoMinkov', pass: '123456q'});
	//inserts a new message record into the DB
	//the message has two references to users (from and to)
	chatDb.sendMessage({
		from: 'DonchoMinkov',
		to: 'NikolayKostov',
		text: 'Hey, Niki!'
	});
	//returns an array with all messages between two users
	chatDb.getMessages({
		with: 'DonchoMinkov',
		and: 'NikolayKostov
	});
	```