

function SaveUser()
{
    debugger;
    var form_Data = new FormData();
    form_Data.append("Name", $("#txtFullName").val());
    form_Data.append("NIC", $("#txtNIC").val());
    form_Data.append("Mobile", $("#txtMobileNo").val());
    form_Data.append("Address", $("#txtAddress").val());
    form_Data.append("Username", $("#txtUsername").val());
    form_Data.append("Password", $("#txtPassword").val());
    var uploadFileData = $("#flupProfileImage").prop('files')[0];
    form_Data.append("file", uploadFileData);
    

    $.ajax({
        url:' /User/SaveUser',
        type: 'POST',
        data: form_Data,
        cache:false,
        contentType: false,
        processData:false,
        success: function (data) {
            if (data > 0) alert("This User Already Exist!");
            else alert("User Saved SuccessFully!");
        },
        error: function () {
        }
    });
}

