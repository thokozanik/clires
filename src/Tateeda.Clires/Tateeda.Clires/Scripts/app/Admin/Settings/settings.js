var settings = settings || {};
settings.vm = function () {
	var defaultStudyId = 0,
		setDefaultStudy = function(id) {
			if(id>0) {
				$.ajax({
					url: "/Admin/Settings/SetDefaultStudy",
					data: { studyId: id },
					cache: false,
					dataType: 'json',
					success: function (d) {
						print(d);
					},
					error: function (e) {
						toastr.error(e.responseText);
					}
				});
			}
		},
	print = function (txt) {
		$("#result").html(txt);
		
		setTimeout(function () {
			$("#result").hide('slow');
		}, 2000);
		
		toastr.info(txt);
	};
	return {
		print: print,
		setDefaultStudy : setDefaultStudy,
		defaultStudyId: defaultStudyId
	};
}();

$(function() {
	ko.applyBindings(settings.vm);

	$("#submitDefStudy").on('click', function() {
		settings.vm.setDefaultStudy($("#StudyId").val());
	});
});