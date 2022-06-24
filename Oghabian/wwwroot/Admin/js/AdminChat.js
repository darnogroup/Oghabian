var activeRoomId = "";
var adminConnection = new signalR.HubConnectionBuilder().withUrl("/AdminHub").build();
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
var messages = document.getElementById("message");
var myList = document.getElementById("groups");


adminConnection.on("GatRoom", function (rooms) {
    var roomIds = Object.keys(rooms);
    RemoveRooms();
    roomIds.forEach(function (id) {
        var roomInfo = rooms[id];
        return $("#groups").append("<li class='chat - item pr-1 mt-3  chatRooms'><a data-id=" + roomInfo['chatId'] + " href = 'javascript:;' class= 'd-flex align-items-center'><div class='d-flex justify-content-between flex-grow border-bottom'><div><p data-id=" + roomInfo['chatId'] + " class='text-body font-weight-bold' style='color: darkblue !important'>شناسه:" + roomInfo['chatId'] + "</p></div></div></a></li>");
    });
});
adminConnection.on("Load", function (message) {
    console.log(message);
    if (!message) return;
    message.forEach(function (m) {
        showMessage(m['sender'], m['text'], m['time']);
    });
});

connection.on("ReceiveMessage", showMessage);
function showMessage(sender, message, time) {
    $("#message").append("<li class='message-item friend'><img src='/Images/male.jpg' class='img-xs rounded-circle' alt='avatar'><div class='content'><span>" + sender+"</span><div class='message'><div class='bubble'><p>"+message+"</p></div><span>"+time+"</span></div></div></li>");
}

function showAdminMessage(message) {
    $("#message").append("<li class='message-item friend'><img src='/Images/male.jpg' class='img-xs rounded-circle' alt='avatar'><div class='content'><span>شما</span><div class='message'><div class='bubble'><p>" + message +"</p></div></div></div></li> ");
}

function setActiveRoomButton(el) {
    var allButtons = myList.querySelectorAll("chatRooms");
    allButtons.forEach(function(btn) {
        btn.classList.remove('active');
    });
    el.classList.add('active');
 
}
function  switchActiveRoomTo(id) {
    if (id === activeRoomId) return;
    if (activeRoomId) {
        connection.invoke("LeftGroup", activeRoomId);
    }

    messages.innerHTML = '';
    activeRoomId = id;
    connection.invoke("JoinGroup", activeRoomId);
    adminConnection.invoke("LoadChat", activeRoomId);
}
adminConnection.on("ReceiveMessage", function (message) {
  
    $("#list").append("<li class='leftChat'><span>پشتیبان:</span><p class='message' >" + message + "</p></li >");
});

adminConnection.on(function () {
    console.log("Chat Client");
    var adminForm = $("#adminForm");
    adminForm.on('submit', function (e) {
        console.log("Chat Click");
        e.preventDefault();
      
        console.log(text);
    
    });
});
document.getElementById("submit").addEventListener("click", function (event) {
    console.log("Send");
    var text = document.getElementById("chatText").value;
    console.log(text);
    if (text && text.length) {
        adminConnection.invoke('SendToClient', activeRoomId, text);
        document.getElementById("chatText").value = "";
        showAdminMessage(text);
    }
});



function RemoveRooms() {
   
    myList.innerHTML = '';
}



adminConnection.start().then(function () {
    console.log("StartServerHub...");
}).catch(function (err) {
    return console.error(err.toString());
});

connection.start().then(function () {
    console.log("StartClientHub...");
}).catch(function (err) {
    return console.error(err.toString());
});

myList.addEventListener('click',function (e) {
    myList.style.display = 'block';
    setActiveRoomButton(e.target);
    var roomId = e.target.getAttribute('data-id');
    switchActiveRoomTo(roomId);
});