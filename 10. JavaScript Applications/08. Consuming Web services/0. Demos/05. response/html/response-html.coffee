resourceUrl = 'http://localhost:3000/students';

getHttpRequest = do -> 
	xmlHttpFactories = [
		() -> new XMLHttpRequest()
		() -> new ActiveXObject 'Msxml3.XMLHTTP'
		() -> new ActiveXObject 'Msxml2.XMLHTTP.6.0'
		() -> new ActiveXObject 'Msxml2.XMLHTTP.3.0'
		() -> new ActiveXObject 'Msxml2.XMLHTTP'
		() -> new ActiveXObject 'Microsoft.XMLHTTP'
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
			when 2 then document.getElementById('http-response').innerHTML = httpRequest.responseText
			else document.getElementById 'http-response'.innerHTML = '<div><h1 style="color:#f00">Error happened</h1>#{httpRequest.responseText}</div>'

httpRequest.open 'GET', 'partial.html', true
httpRequest.setRequestHeader 'Content-type', 'application/json'
httpRequest.send null