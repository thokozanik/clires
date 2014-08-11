var stdvis = stdvis || {};
stdvis.vm = function() {
    var clearInput = function() {
        $("#drugSearch").val('');
    };

    return {
        clearInput: clearInput
    };
}();