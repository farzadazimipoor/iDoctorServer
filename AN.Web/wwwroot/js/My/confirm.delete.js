
$('#confirmDelete').on('show.bs.modal', function (e) {
    $message = $(e.relatedTarget).attr('data-message');
    $(this).find('.modal-body p').text($message);
    $title = $(e.relatedTarget).attr('data-title');
    $(this).find('.modal-title').text($title);

    $action = $(e.relatedTarget).attr('data-action');
    if ($action != null) {
        $(this).find('#confirm').text($action);

        switch ($action) {
            case "انجام":
                $(this).find('#confirm').removeClass();
                $(this).find('#confirm').addClass('btn btn-success');
                $(this).find('#confirm').text("ئەنجام درا");
                break;
            case "تایید":
                $(this).find('#confirm').removeClass();
                $(this).find('#confirm').addClass('btn btn-success');
                $(this).find('#confirm').text("باشە");
                break;
            case "لغو":
                $(this).find('#confirm').removeClass();
                $(this).find('#confirm').addClass('btn btn-warning');
                break;
            case "حذف":
                $(this).find('#confirm').removeClass();
                $(this).find('#confirm').addClass('btn btn-danger');
                break;
            default:
                $(this).find('#confirm').removeClass();
                $(this).find('#confirm').addClass('btn btn-danger');
                $(this).find('#confirm').text("بەردەوام");
                break;
        }
    }

    // Pass form reference to modal for submission on yes/ok
    var form = $(e.relatedTarget).closest('form');
    $(this).find('.modal-footer #confirm').data('form', form);
});

//Form confirm (yes/ok) handler, submits form
$('#confirmDelete').find('.modal-footer #confirm').on('click', function () {
    $(this).data('form').submit();
});