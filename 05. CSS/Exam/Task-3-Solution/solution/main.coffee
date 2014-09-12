window.onload =  () -> 
			createMessageItem = (className, author, text) ->
				li = document.createElement 'li'
				li.className = className
				li.innerHTML = '<strong>' + 'by ' + author + '</strong>' + '<span>' + text + '</span>'
				return li

			meInput = document.querySelector '#me input'
			meMessages = document.querySelector '#me ul'

			otherInput = document.querySelector '#other input'
			otherMessages = document.querySelector '#other ul'

			(document.querySelector '#me button').addEventListener 'click', (ev) ->
				msgText = meInput.value;
				meInput.value = '';
				if !msgText
					return

				meMessages.appendChild (createMessageItem 'me', 'me', msgText )
				otherMessages.appendChild (createMessageItem 'other', 'Doncho Minkov', msgText)

			(document.querySelector '#other button') .addEventListener 'click', (ev) ->
				msgText = otherInput.value
				otherInput.value = ''
				if !msgText
					return

				otherMessages.appendChild(createMessageItem 'me', 'me', msgText)
				meMessages.appendChild(createMessageItem 'other', 'Ivaylo Kenov', msgText)