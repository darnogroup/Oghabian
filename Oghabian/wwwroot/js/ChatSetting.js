var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();


connection.on("ReceiveMessage", function (user,message,time) {
    console.log(message);
    $("#list").append("<li class='leftChat'><span>"+user+"</span><p class='message' >" + message +"</p><span>"+time+"</span></li >");
});
connection.on("SupportMessage", function (user,message,time) {
    console.log(message);
    $("#list").append("<li class='rightChat'><span>"+user+"</span><p class='message' >" + message +"</p><span>"+time+"</span></li >");
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;

  
    connection.invoke("SendMessage", "کاربر  سایت", message).catch(function (err) {
        return console.error(err.toString());
    });
    document.getElementById("messageInput").value = "";
    event.preventDefault();
});

function openForm() {
    document.getElementById("myForm").style.display = "block";
}

function closeForm() {
    document.getElementById("myForm").style.display = "none";
}