/// <reference path="jquery-1.10.2.min.js" />
/// <reference path="jquery.signalr-2.2.3.min.js" />


'use strict';

$(function() {


    var currentUserName = $("#Username").val();

    var curUser = String(currentUserName);


    


    var linkChatHubProxy = $.connection.linkChatHub;

    linkChatHubProxy.client.updateChat= function(userName, message, isPm) {

        var $newMsg;

        if (curUser === userName) {

            $newMsg = $('<div class="panel panel-primary" style="margin-left: 7em; background-color: #337ab7;">' +
                '<div style="padding: .5em; color: white; text-align: right;">' +
                message +
                '</div>' +
                '</div>');


        } else {

            $newMsg = $('<div class="panel panel-primary" style="margin-right: 7em; background-color: ' +
                (isPm ? 'green' : '#337ab7') +
                ';">' +
                '<div style="padding: .5em; color: white; border-bottom: .1em solid white; font-size: 11px;">' +
                userName +
                '</div>' +
                '<div style="padding: .5em; color: white;">' +
                message +
                '</div>' +
                '</div>');
        }

        $("#chat").append($newMsg);

        $newMsg[0].scrollIntoView(true);

    };

    linkChatHubProxy.client.updateUsersOnline = function(data) {

        if (!data.Success) {

            bootbox.alert(data.ErrorMessage);

            return;
        }

        var users = $("#users");

        users.html(null);

        for (var user of data.UsersOnline) {

            if (user === curUser) {

                users.append($('<p class="user current">' + user + '</p>'));

            } else {

                var dUser = $('<p class="user">' + user + '</p>');

                dUser.click(function() {

                    var message = $("#message");

                    message.val('@' + $(this).text() + " ");

                    message.focus();
                });

                users.append(dUser);
            }
        }
    };

    $.connection.hub.start()
        .done(function() {

            var status = linkChatHubProxy.server.connectUser(curUser).done(function(data, textStatus, jqXHR) {

                if (!data.Success) {

                    alert(data.ErrorMessage);

                    return;
                }

                var message = $("#message");

                var sendMessage = function() {

                    message.focus();

                    if (message.val() === "") {

                        return;
                    }

                    linkChatHubProxy.server.sendMessage(curUser, message.val());

                    message.val("");
                };

                message.keyup(function(data) {

                    if (data.which === 13) {

                        sendMessage();
                    }
                });

                $("#send").click(sendMessage);

                message.focus();
            });
        })
        .fail(function() {

            console.log("Could not Connect");
        });

});