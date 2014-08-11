$(function() {
    $("#saveContinue").on('click', function () {
        $("#frmSubmission").attr('action', '/Study/Visit/SaveContinue').attr('novalidate', 'novalidate');        
        document.forms[0].submit();
    });
    $("#saveAndRequest").on('click', function () {
        $("#frmSubmission").attr('action', '/Study/Visit/SaveRequestData').attr('novalidate', 'novalidate');
        document.forms[0].submit();
    });
    $("#saveFinish").on('click', function() {
        $("#frmSubmission").attr('action', '/Study/Visit/SaveFinish').attr('novalidate', 'validate');
        if (validateForm()) {
            $("#frmSubmission").submit();
        }
    });
});