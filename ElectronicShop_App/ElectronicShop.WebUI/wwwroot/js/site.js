// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ShowAjaxLoader() {
    $("#ajax-loader").show();
}

function HideAjaxLoader() {
    $("#ajax-loader").hide();
}

function HandleAjaxErrorSwal(jqXhr, noAuthenticationMsg, notAuthorizedMsg, generalMsg, msgType) {

    if (jqXhr.status == 401) // authentication error
    {
        swal("", noAuthenticationMsg, msgType);
    } else if (jqXhr.status == 403) // forbidden authorization error
    {
        swal("", notAuthorizedMsg, msgType);
    } else {
        swal("", generalMsg, msgType);
    }
}

function SetAlertMessage(message, type) {
    $("#alertDiv").show();
    $("#alertMsgSpan").text(message);

    var typeLower = type.toLowerCase();
    if (typeLower == "success") {
        $("#alertDiv").attr("class", "alert alert-success");
        $("#alertIcon").attr("class", "fa fa-check-circle-o mr-2");
    }
    else if (typeLower == "info") {
        $("#alertDiv").attr("class", "alert alert-info");
        $("#alertIcon").attr("class", "fa fa-bell-o mr-2");
    }
    else if (typeLower == "warning") {
        $("#alertDiv").attr("class", "alert alert-warning");
        $("#alertIcon").attr("class", "fa fa-exclamation mr-2");
    }
    else if (typeLower == "danger") {
        $("#alertDiv").attr("class", "alert alert-danger");
        $("#alertIcon").attr("class", "fa fa-frown-o mr-2");
    }

    ScrollToTop();
}

function HideAlertDiv() {
    $("#alertDiv").hide();
}

function HandleAlertCloseButton() {
    $(document).on('click', '.alert-close', function () {
        $(this).parent().hide();
    })
}

function ScrollToTop() {
    $("html, body").animate({
        scrollTop: 0
    }, 600);
}
