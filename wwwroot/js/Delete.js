﻿"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("btdelete").disabled = true;

connection.start().then(function () {
    document.getElementById("btdelete").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

const uri = "/api/chats";
document.getElementById("btdelete").addEventListener("click", function (event) {
    var id = document.getElementById("id").value;
    var user = document.getElementById("user").value;
    var message = "a supprimé un message";

    var uri2 = uri + "/" + id;
    fetch(uri2, {
        method: 'DELETE',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
    })
        .then(response => response.json())
        .then(() => {
            connection.invoke("SendMessage", user, message).catch(function (err) {
                return console.error(err.toString());
            });
            alert('chat supprimé !')
        })
        .catch(error => alert('Chat invalide ! Remplir tous les champs !'));

    event.preventDefault();
});