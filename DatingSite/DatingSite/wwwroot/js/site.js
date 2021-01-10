/***************** SIGNALR *****************/
/******************************************/
$(function () {
    const connection = new signalR.HubConnectionBuilder().withUrl("/friendHub").build();
    connection.start().catch(err => console.error(err));
   
    connection.on("added", (user) => {
        var notifications = document.getElementById('notifications')
        notifications.innerHTML = `<div class="alert alert-success alert-dismissible fade show m-0" role="alert">
                          Added by user: <strong>${user}</strong>
                          <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                          </button>
                        </div>`
        notifications.appendChild(div);
    });
});