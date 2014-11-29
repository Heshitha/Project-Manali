

function SaveUser()
{
    debugger;
    var userDTO = new Object();
    userDTO.Name =$("#txtFullName").val();
    userDTO.NIC = $("#txtNIC").val();
    userDTO.Mobile = $("#txtMobileNo").val();
    userDTO.Address = $("#txtAddress").val();
    userDTO.Username = $("#txtUsername").val();
    userDTO.Password = $("#txtPassword").val();
    userDTO.ImagePath = $("#flupProfileImage").val();

    $.ajax({
        url:' /User/SaveUser',
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            alert(1);
        },
        error: function () {
            alert(2);
        }
    });
}

