var fh = fh || {};

$(function() {
    $("#dialog-form").dialog({
        autoOpen: false,
        height: 200,
        width: 500,
        modal: true,
        resizable:false
    });

    $("#open-FileUploader")
        .button()
        .click(function () {
            $("#dialog-form").dialog("open");
        });
});
