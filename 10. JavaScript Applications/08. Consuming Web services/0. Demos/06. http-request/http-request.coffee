@httpRequest = do ->
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
	
	makeRequest = (options) ->
		requestUrl = options.url;
		httpRequest = getHttpRequest();

		options = options ? {}
		options.success = options.success ? () ->
		options.error = options.error ? () ->
		options.contentType = options.contentType ? ''
		options.accept = options.accept ? ''
		options.data = options.data ? null

		httpRequest.onreadystatechange = () ->
			if httpRequest.readyState is 4
				switch httpRequest.status // 100
					when 2 then	options.success httpRequest.responseText
					else options.error httpRequest.responseText

		httpRequest.open (if options.type then options.type else 'GET'), requestUrl, true
		httpRequest.setRequestHeader 'Content-Type', options.contentType
		httpRequest.setRequestHeader 'Accept', options.accept
		
		httpRequest.send options.data

	getJSON = (url, success, error) ->
		makeRequest
			url: url
			type: 'GET'
			contentType: 'application/json'
			accept: 'application/json'
			success: (data)->
				unless success 
					return
				if data
					success JSON.parse data
				else 
					success()
			error: (err) ->
				unless error
					return				
				if err
					error JSON.parse err
				else 
					error()
	postJSON = (url, data, success, error) ->
		makeRequest
			url: url
			type: 'POST'
			contentType: 'application/json'
			accept: 'application/json'
			data: data
			success: (data) ->
				unless success
					return
				if data
					success JSON.parse data
				else 
					success()
			error: (err) ->
				unless error
					return
				if err
					error JSON.parse err
				else
					error()

	make: makeRequest,
	getJSON: getJSON,
	postJSON: postJSON