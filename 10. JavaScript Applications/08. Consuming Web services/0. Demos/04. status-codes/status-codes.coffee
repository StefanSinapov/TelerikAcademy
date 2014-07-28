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

successBox = document.getElementById 'success-box'
errorBox = document.getElementById 'error-box'

successBox.style.display = 'none'
errorBox.style.display = 'none'


fadeSuccess = () ->
	opacity = successBox.style.opacity
	opacity -= 0.07
	if opacity <= 0
		successBox.style.display = 'none'
	else
		successBox.style.opacity = opacity
		setTimeout fadeSuccess, 100

showSuccess = (message) ->
	successBox.innerHTML = message
	successBox.style.display = ''
	successBox.style.opacity = 1

	fadeSuccess()

fadeError = () ->
	opacity = errorBox.style.opacity
	opacity -= 0.07
	if opacity <= 0
		errorBox.style.display = 'none'
	else
		errorBox.style.opacity = opacity
		setTimeout fadeError, 100

showError = (message) ->
	errorBox.innerHTML = message
	errorBox.style.display = ''
	errorBox.style.opacity = 1

	fadeError()

buildRequest = (url)->
	httpRequest = getHttpRequest()
	httpRequest.onreadystatechange = () ->
		if httpRequest.readyState is 4

			switch httpRequest.status//100
				when 2 then showSuccess 'Response finished with Success!'
				when 4 then showError 'Something is wrong with the request'
				when 5 then showError 'Something is wrong with the server'
				else showError 'Generic error'		

	httpRequest.open 'GET', url, true
	httpRequest

document.getElementById 'btn-send-success-request'
	.addEventListener 'click', () ->
		httpRequest = buildRequest resourceUrl	
		httpRequest.send null	
document.getElementById 'btn-send-error-request'
	.addEventListener 'click', () ->		
		httpRequest = buildRequest resourceUrl + 'INVALID_URL'	
		httpRequest.send null	