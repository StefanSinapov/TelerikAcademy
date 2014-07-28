resourceUrl = 'http://localhost:3000/students';

appendText = (selector, text) ->
	element = document.querySelector(selector);
	element.innerHTML += "<div>#{text}</div>";

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
	switch httpRequest.readyState
		when 1 then appendText "#http-response", "request in loading state"
		when 2 then appendText "#http-response", "request in loaded state"
		when 3 then appendText "#http-response", "request in interactive state"
		when 4 then appendText "#http-response", "request in complete state"
		else appendText "#http-response', 'Something else happened, readyState: #{httpRequest.readyState}"
	return

httpRequest.open 'GET', resourceUrl, true


httpRequest.send null