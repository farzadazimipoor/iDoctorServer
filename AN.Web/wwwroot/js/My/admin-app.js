$(document).ready(function () {
    $(".NumericOnly").keydown(function (e) {
        // Allow: backspace, delete, tab, escape, enter and .
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            // Allow: Ctrl+A, Command+A
            (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
            // Allow: home, end, left, right, down, up
            (e.keyCode >= 35 && e.keyCode <= 40)) {
            // let it happen, don't do anything
            return;
        }
        // Ensure that it is a number and stop the keypress
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });

    $('.popoverData').popover({ html: true });

    //Change PagedList arrow icons
    $('.PagedList-skipToPrevious > a').html("<i class='fa fa-arrow-left' aria-hidden='true'></i>");
    $('.PagedList-skipToNext > a').html("<i class='fa fa-arrow-right' aria-hidden='true'></i>");

    toastr.options = {
        "rtl": true,
        "closeButton": true,
        "debug": false,
        "newestOnTop": true,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "2000",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }

    $("a").on("click", function () {
        var navId = $(this).data("nav-id");
        if (navId != null && navId !== "" && navId !== "undefined") {
            localStorage.setItem("SelectedNavLink", navId);
        }
    });
    $(".brand-link").on("click", function () {
        localStorage.removeItem("SelectedNavLink");
    });
    var selectedNavLink = localStorage.getItem("SelectedNavLink");
    if (selectedNavLink != null && selectedNavLink !== "" && selectedNavLink !== "undefined") {
        var element = $("#" + selectedNavLink);
        if (element.hasClass("nav-link")) {
            element.addClass("active");
        }
    }
});

const Toast = Swal.mixin({
    toast: true,
    position: 'top',
    showConfirmButton: false,
    timer: 3000,
    onOpen: (toast) => {
        toast.addEventListener('mouseenter', Swal.stopTimer)
        toast.addEventListener('mouseleave', Swal.resumeTimer)
    }
});

function waiting(e, m = 'Please Wait') {
    $('#' + e).block({
        message: '<div class="blockui-default-message"><div class="custom-loader"></div><strong class="text-white text-center">' + m + '</strong></div>',
        overlayCSS: {
            background: 'rgba(142, 159, 167, 0.8)',
            opacity: 1,
            cursor: 'wait'
        },
        css: {
            width: '50%'
        },
        blockMsgClass: 'block-msg-default'
    });
}

function waitingDone(e) {
    $('#' + e).unblock();
}

function printHtml(html) {
    var params = [
        'height=' + screen.height,
        'width=' + screen.width,
        'fullscreen=yes',
        'scrollbars=yes'
    ].join(',');
    var popupWin = window.open('', '_blank', params);
    popupWin.document.open();
    popupWin.document.write(html);
    popupWin.document.close();
}

function objectifyForm(formArray) {
    var returnArray = {};
    for (var i = 0; i < formArray.length; i++) {
        returnArray[formArray[i]['name']] = formArray[i]['value'];
    }
    return returnArray;
}

$.fn.serializeFormJSON = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name]) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

function OpenReport(url) {
    var win = window.open(url, '_blank');
    win.focus();
}

function changePassword(modalTitle = "Change Password", waitingText = "Please Wait") {
    waiting('body', waitingText);
    $.ajax({
        type: 'Get',
        url: "/Account/ChangePassword",
        success: function (response) {
            var commonModal = $("#AwroNoreModal");
            commonModal.find('.modal-title').text(modalTitle);
            commonModal.find('#CommonModalContent').html(response);
            commonModal.modal({ backdrop: 'static', keyboard: false });
        },
        error: function (jqXHR, ex) {
            handleAjaxError(jqXHR, ex);
        }
    }).always(function () {
        waitingDone('body');
    });
}

function clearSelectedNavLink() {
    var selectedNavLink = localStorage.getItem("SelectedNavLink");
    if (selectedNavLink != null && selectedNavLink !== "" && selectedNavLink !== "undefined") {
        var element = $("#" + selectedNavLink);
        if (element.hasClass("nav-link") && element.hasClass("active")) {
            element.removeClass("active");
        }
    }
}
