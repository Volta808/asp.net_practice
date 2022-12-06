"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("btsendbutton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messages").appendChild(li);
    li.textContent = `${user} says ${message}`;
});

connection.start().then(function () {
    document.getElementById("btsendbutton").disabled = false;
    getChats();
}).catch(function (err) {
    return console.error(err.toString());
});

const uri = "/api/chats";
document.getElementById("btsendbutton").addEventListener("click", function (event) {
    var user = document.getElementById("user").value;
    var message = document.getElementById("message").value;

    const chat =
    {
        id: 0, user: user, message: message
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(chat)
    })
        .then(response => response.json())
        .then(() => {
            connection.invoke("SendMessage", user, message).catch(function (err) {
                return console.error(err.toString());
            });
        })
        .catch(error => alert('Chat invalide ! Remplir les deux champs !'));

    event.preventDefault();
});

function getChats() {
    fetch(uri)
        .then(response => response.json())
        .then(data =>
            data.forEach(chat => {
                var li = document.createElement("li");
                document.getElementById("messages").appendChild(li);
                li.textContent = `${chat.user} says ${chat.message}`;
            }))
        .catch(error => alert("Erreur retournée par l'API !"));
}