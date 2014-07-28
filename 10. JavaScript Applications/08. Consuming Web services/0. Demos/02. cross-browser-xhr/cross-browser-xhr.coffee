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

httpRequest.open 'GET', resourceUrl, true

httpRequest.send null	