resourceUrl = 'http://localhost:3000/students';

getHttpRequest = do -> 
	xmlHttpFactories = [
		() -> new XMLHttpRequest()
		() -> new ActiveXObject "Msxml3.XMLHTTP"
		() -> new ActiveXObject "Msxml2.XMLHTTP.6.0"
		() -> new ActiveXObject "Msxml2.XMLHTTP.3.0"
		() -> new ActiveXObject "Msxml2.XMLHTTP"
		() -> new ActiveXObject "Microsoft.XMLHTTP"
	]
	() -> 
		for xmlFactory in xmlHttpFactories
			try
				return xmlFactory()
			catch
		return null

httpRequest = getHttpRequest()

httpRequest.onreadystatechange = () ->
	if httpRequest.readyState is 4 
		switch httpRequest.status//100
			when 2 then success JSON.parse httpRequest.responseText
			else error httpRequest.responseText
	return

httpRequest.open 'GET', resourceUrl, true
httpRequest.send null

success = (response) ->
	students = response.students
	list = '<ul>';
	if students? and students.length isnt 0
		for student in response.students	
			list += "<li>#{student.name} is in #{student.grade} grade</li>"
		list += '</ul>'
		document.getElementById 'http-response'
			.innerHTML = list
	else 
		document.getElementById 'http-response'
			.innerHTML = 'No students available'
	return
error = (err) ->
	document.getElementById("http-response").innerHTML = 
		"<div><h1 style='color:#f00'>Error happened</h1>" + err + "</div>";
	return