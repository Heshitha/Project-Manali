$(document).ready(function () {
    $("#txtConfirmPassword").keyup(checkPasswordMatch);
});

function checkPasswordMatch()
{
    var password = $("#txtPassword").val();
    var confirmPassword = $("#txtConfirmPassword").val();

    if (password != confirmPassword)
        $("#spnCheckPasswordMatch").html("Passwords do not match!");
    else
        $("#spnCheckPasswordMatch").html("Passwords match.");
}

function SaveUser()
{
    debugger;

    if ($('#userID').val() == 0) {

        var password = $("#txtPassword").val();
        var confirmPassword = $("#txtConfirmPassword").val();

        if(password == confirmPassword)
        {
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
                url: '/User/SaveUser',
                type: 'POST',
                data: form_Data,
                cache: false,
                contentType: false,
                processData: false,
                success: function (data) {
                    if (data > 0) alert("This User Already Exist!");
                    else alert("User Saved Successfuly!");
                },
                error: function () {
                }
            });
        }
        else {
            $("#spnCheckPasswordMatch").html("Passwords do not match!");
        }
        
    }
    else {
        var password = $("#txtPassword").val();
        var confirmPassword = $("#txtConfirmPassword").val();

        if (password.length > 0) {
            
            if(password != confirmPassword)
            {
                $("#spnCheckPasswordMatch").html("Passwords do not match!");
            }
            else if (password.length < 8) {
                $("#spnCheckPasswordMatch").html("Passwords must be at least 8 characters!");
            }
            else {
                var form_Data = new FormData();
                form_Data.append("userID", $("#userID").val());
                form_Data.append("Mobile", $("#txtMobileNo").val());
                form_Data.append("Address", $("#txtAddress").val());
                form_Data.append("Username", $("#txtUsername").val());
                form_Data.append("Password", $("#txtPassword").val());
                var uploadFileData = $("#flupProfileImage").prop('files')[0];
                form_Data.append("file", uploadFileData);

                $.ajax({
                    url: '/User/EditUser',
                    type: 'POST',
                    data: form_Data,
                    cache: false,
                    contentType: false,
                    processData: false,
                    success: function (data) {
                        if (data > 0) alert("This User Already Exist!");
                        else alert("User Saved SuccessFully!");
                    },
                    error: function () {
                    }
                });
            }
        }
        else {
            var form_Data = new FormData();
            form_Data.append("userID", $("#userID").val());
            form_Data.append("Mobile", $("#txtMobileNo").val());
            form_Data.append("Address", $("#txtAddress").val());
            form_Data.append("Username", $("#txtUsername").val());
            form_Data.append("Password", $("#txtPassword").val());
            var uploadFileData = $("#flupProfileImage").prop('files')[0];
            form_Data.append("file", uploadFileData);

            $.ajax({
                url: '/User/EditUser',
                type: 'POST',
                data: form_Data,
                cache: false,
                contentType: false,
                processData: false,
                success: function (data) {
                    if (data > 0) alert("This User Already Exist!");
                    else alert("User Saved SuccessFully!");
                },
                error: function () {
                }
            });
        }
    }


}

