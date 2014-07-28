define(['jquery', 'http-request', 'user', 'mustache'], function ($, request, user, Mustache) {
    'use strict';
    var ChatController = (function () {
        var sourceUrl = '',
            $wrapper,
            messageTemplate,
            refreshTimeMS = 4000,
            showLastMessagesCount = 200;

        function init(url, container) {
            sourceUrl = url;
            $wrapper = $(container);
            $.get('views/chat-msg-template.html', function (data) {
                messageTemplate = data;
            });
            addEventHandlers();
        }

        function loadChatBox() {
            $.when(
                $.get('views/chat-template.html', function (data) {
                    $wrapper.html(data);
                    $wrapper.find('.username-box').text(user.getName());
                    updateChatBox(showLastMessagesCount);
                    setInterval(function() {
                        updateChatBox(showLastMessagesCount);
                    }, refreshTimeMS);
                }));
        }

        function addEventHandlers() {
            $wrapper.on('click', '#exit-btn', function () {
                var exit = confirm("Are you sure you want to exit?");
                if (exit === true) {
                    user.deleteName();
                    window.location = '#/login';
                }
            });

            $wrapper.on('click', '#send-msg-btn', function () {
                var $messageInput = $('#user-msg'),
                    enteredMessage = $messageInput.val().trim(),
                    postBy = user.getName();

                if (enteredMessage) {
                    request.postJSON(sourceUrl, {
                        user: postBy,
                        text: enteredMessage
                    })
                        .then(function () {
                            $messageInput.val('');
                            var postHtml = buildMessage({user: postBy, message: enteredMessage});
                            $('#chat-box').prepend(postHtml);
                        }, function (reason) {
                            alert(reason);
                        })
                }
                else {
                    $messageInput.select();
                }
            });
        }

        function updateChatBox(messageCount) {
            var len,
                i,
                postBy,
                postText,
                message,
                post,
                $allMessages = $('<div/>');

            request.getJSON(sourceUrl)
                .then(function (data) {
                    for (i = data.length - 1, len = data.length; i > len - messageCount; i--) {
                        post = data[i];
                        postBy = post.by.trim();
                        postText = post.text.trim();

                        if (!postBy || !postText) {
                            continue;
                        }
                        message = buildMessage({user: postBy, message: postText});
                        $allMessages.append(message);
                    }
                    $('#chat-box').html($allMessages.html());
                });
        }

        function buildMessage(data) {
            var renderedMessage = Mustache.render(messageTemplate, data);

            return renderedMessage;
        }

        return {
            init: init,
            loadChatBox: loadChatBox
        }

    }());

    return ChatController;
});