"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("btsave").disabled = true;

connection.start().then(function () {
    document.getElementById("btsave").disabled = false;
    //document.getElementById("editsubmit").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

const uri = "/api/chats";
document.getElementById("btsave").addEventListener("click", function (event) {
    var id = document.getElementById("id").value;

    var user = document.getElementById("user").value;
    var message = document.getElementById("message").value;

    const chat =
    {
        id: id, user: user, message: message
    };

    var uri2 = uri + "/" + id;
    fetch(uri2, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(chat)
    })
    .then(response => response.json())
        .then(() => {
        message = message + " ( reprise )"
            connection.invoke("SendMessage", user, message).catch(function (err) {
                return console.error(err.toString());
            });
            alert('chat envoyé et enregistré !')
     })
     .catch(error => alert('Chat invalide ! Remplir tous les champs !'));

    event.preventDefault();
});
