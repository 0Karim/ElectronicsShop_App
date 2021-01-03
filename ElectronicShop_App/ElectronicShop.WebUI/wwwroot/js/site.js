// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    HandleAlertCloseButton();

    HideAlertDiv();

    HideAjaxLoader();

    SetIgnoreValidation();

    //$(".chosen-select-def").chosen();

    $('.select2-show-search').select2({
        minimumResultsForSearch: ''
    });

    $('.arabicOnly').keypress(function (e) {
        var regex = new RegExp("^[\u0621-\u064A\u0660-\u06690-9 ]+$");
        var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (regex.test(str)) {
            return true;
        }

        e.preventDefault();
        return false;
    });

    $('.englishOnly').keypress(function (e) {
        var regex = new RegExp("^[a-zA-Z0-9 ]+$");
        var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (regex.test(str)) {
            return true;
        }

        e.preventDefault();
        return false;
    });

    $(".allowNumWithDotAndComma").on("keypress keyup blur", function (event) {
        $(this).val($(this).val().replace(/[^0-9\.|\,]/g, ''));
        debugger;
        if (event.which == 44) {
            return true;
        }
        if ((event.which != 46) && (event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }
    });

    $(".allowNumWithDot").on("keypress keyup blur", function (event) {
        $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
        debugger;
        if (event.which == 44) {
            return true;
        }
        if ((event.which != 46) && (event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }
    });

    $(".decimalNumOnly").on("keypress", function (event) {
        if (event.keyCode > 47 && event.keyCode < 58 || event.keyCode == 46) {
            debugger;
            var txtbx = document.getElementById(this.id);
            var amount = document.getElementById(this.id).value;
            var present = 0;
            var count = 0;

            if (amount.indexOf(".", present) || amount.indexOf(".", present + 1));
            {
            }

            do {
                present = amount.indexOf(".", present);
                if (present != -1) {
                    count++;
                    present++;
                }
            }
            while (present != -1);
            if (present == -1 && amount.length == 0 && event.keyCode == 46) {
                event.keyCode = 0;
                //alert("Wrong position of decimal point not  allowed !!");
                return false;
            }

            if (count >= 1 && event.keyCode == 46) {
                event.keyCode = 0;
                //alert("Only one decimal point is allowed !!");
                return false;
            }
            if (count == 1) {
                var lastdigits = amount.substring(amount.indexOf(".") + 1, amount.length);
                if (lastdigits.length >= 6) {
                    //alert("Two decimal places only allowed");
                    event.keyCode = 0;
                    return false;
                }
            }
            return true;
        }
        else {
            event.keyCode = 0;
            //alert("Only Numbers with dot allowed !!");
            return false;
        }
    });

    $('.allowNumOnly').on('input', function (e) {
        this.value = this.value.replace(/[^0-9]/g, '');
    });

    $('.allowStringOnly').on("keypress keyup blur", function (e) {
        var regex = new RegExp("^[a-zA-Z\u0621-\u064A\u0660-\u0669 ]+$");
        var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (regex.test(str)) {
            return true;
        }
        e.preventDefault();
        return false;
    });
});

function SetIgnoreValidation() {
    $.validator.setDefaults({
        ignore: ".ignoreval"
    });
}

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
