

let connection = null;

setupConnection = () => {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:62618/oddshub")
        .build();

    connection.start()
        .catch(err => console.error(err.toString()));
};

setupConnection();

connection.on('Send', (nick, message, id) => {
    addItem(nick, message, id);
});

document.getElementById("submit").addEventListener("click", e => {
    e.preventDefault();
    const message = document.getElementById("message").value;
  
    connection.invoke('Send', "Alex", message);
});

function addItem(name, message, id) {
    var ul = document.getElementById("dynamic-list");
    var li = document.createElement("li");
    li.setAttribute('id', message);
    li.appendChild(document.createTextNode(name + " " + message + " " + id));
    ul.appendChild(li);
}