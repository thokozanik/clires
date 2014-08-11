$(function() {
	$('body').on('keyup', "#drugSearch", function () {
        var text = $("#drugSearch").val();
        var maxLoad = 20;
        if (text.length > 1) {
            med.vm.findDrugs(text, maxLoad, loadSearchResult);
        }
    });
    
	$('body').on('select click', "#drugSearchResult", function (event) {		
        $("#drugId").val(med.vm.drugVal());
        var drugName = ko.utils.arrayFilter(med.vm.drugs(), function(item) {
            return item.Id() == med.vm.drugVal();
        });
        var drugname = drugName[0] ? drugName[0].Name() : '';
		$("#drugSearch").val(drugname);
		$(this).addClass("hide");
    });

	$("body").on('change', "#endDate", function() {
		var start = new Date($("#startDate").val());
		var end = new Date($(this).val());		
		if(start>=end) {
			toastr.error("End Date before Start Date");
			$(this).val('');
		}
		
		isInFuture(start, end);
	});
	
	$("body").on('change', "#startDate", function () {
		var end = new Date($("#endDate").val());
		var start = new Date($(this).val());
		if (end && start >= end) {
			toastr.error("End Date before Start Date");
			$("#endDate").val('');
		}
		
		isInFuture(start, end);
	});

	//ko.applyBindings(med.vm);
});

function isInFuture(start, end) {
	var now = new Date();
	if (start > now || end > now) {
		toastr.error("Date can not be in the future!");
		return true;
	}
	return false;
}
function loadSearchResult(result) {
    if (result.length > 0) {
        $("#drugSearchResult").removeClass("hide");
        //ko.applyBindings(med.vm);
    } else {
        $("#drugSearchResult").addClass("hide");
    }
}