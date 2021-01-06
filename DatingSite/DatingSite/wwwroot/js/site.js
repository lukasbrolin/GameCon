/***************** SIGNALR *****************/
/******************************************/
$(function () {
    const connection = new signalR.HubConnectionBuilder().withUrl("/friendHub").build();
    connection.start().catch(err => console.error(err));
    connection.on("added", (user) => {
        console.log(user);
    });

    connection.on("added", (user) => {
        $("#notifications").html("Added by user: <strong>" + user + "</strong>");
        window.setTimeout(function () {
            $("#notifications").html("");
        },
            5000);
    });
});