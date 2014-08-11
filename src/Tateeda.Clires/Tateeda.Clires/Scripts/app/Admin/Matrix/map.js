$(function() {
	$("body").on("change", "#StudyId", function() {
		var id = $(this).val();
		if(id>0){
			$.ajax({
				url: "/Mapping/Map",
				data: { id: id },
				cache: false,
				dataType: 'json',
				async: true,
				success: function (d) {
					$("#result").html(d);
				}
			});
		}
    });
});
