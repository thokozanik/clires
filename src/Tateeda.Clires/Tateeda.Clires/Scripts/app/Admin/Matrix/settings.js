
var mx = mx || {};

mx.vm = new function () {
	var settings = ko.observableArray([]),
		visit = ko.observable(),
		visitInfo = ko.observableArray([]),
		allforms = ko.observableArray([]),
		alllabs = ko.observableArray([]),
		studyId = 0,
		defaultStudyId = 0,
		alllabsCopy = ko.observableArray([]),
		allformsCopy = ko.observableArray([]),
		clone = function(obj) {
			var copy;
			if (null == obj || "object" != typeof obj) return obj;

			// Handle Array
			if (obj instanceof Array) {
				copy = [];
				for (var i = 0; i < obj.length; ++i) {
					copy[i] = clone(obj[i]);
				}
				return copy;
			}

			// Handle Object
			if (obj instanceof Object) {
				copy = { };
				for (var attr in obj) {
					if (obj.hasOwnProperty(attr)) copy[attr] = clone(obj[attr]);
				}
				return copy;
			}
			return null;
		},
		loadSettings = function(id) {
			if (id > 0) {
				studyId = id;
				$.ajax({
					url: "/Json/GetMappingSettings",
					data: { id: id },
					cache: false,
					dataType: 'json',
					async: true,
					success: function(d) {

						settings([]);
						alllabs([]);
						allforms([]);

						$.each(d.Forms, function(i, data) {
							var item = ko.mapping.fromJS(data);
							item.CreatedOn('2000/01/01');
							item.UpdatedOn('2000/01/01');
							allforms.push(item);
						});
						$.each(d.Labs, function(i, data) {
							var item = ko.mapping.fromJS(data);
							item.CreatedOn('2000/01/01');
							item.UpdatedOn('2000/01/01');
							alllabs.push(item);
						});
						settings(ko.mapping.fromJS(d));
						allformsCopy = clone(allforms);
						alllabsCopy = clone(alllabs);
					}
				});
			}
			else {
				settings([]);
				alllabs([]);
				allforms([]);
			}
		},
		loadVisitInfo = function(id) {
			if (id > 0) {
				$.ajax({
					url: "/Json/GetVisitSettings",
					data: { id: id },
					cache: false,
					dataType: 'json',
					async: true,
					success: function(d) {
						visitInfo([]);
						settings().Forms(clone(allformsCopy()));
						settings().Labs(clone(alllabsCopy()));

						$.each(d.Forms, function(i, data) {
							var item = ko.mapping.fromJS(data);
							item.CreatedOn('2000/01/01');
							item.UpdatedOn('2000/01/01');
							item.VisitId(id);
							visitInfo.push(item);

							ko.utils.arrayFirst(settings().Forms(), function(elt) {
								if (elt && elt.Id() === item.Id()) {
									settings().Forms.remove(elt);
								}
							});
						});
						$.each(d.Labs, function(i, data) {
							var item = ko.mapping.fromJS(data);
							item.CreatedOn('2000/01/01');
							item.UpdatedOn('2000/01/01');
							item.VisitId(id);
							visitInfo.push(item);

							ko.utils.arrayFirst(settings().Labs(), function(elt) {
								if (elt && elt.Id() === item.Id()) {
									settings().Labs.remove(elt);
								}
							});
						});

						visit(ko.mapping.fromJS(d));
						visitInfo.sort();
					}
				});
			}
		},
		loadDefaultStudySettings = function() {
			mx.vm.loadSettings(mx.vm.defaultStudyId);
		};

	return {
		settings: settings,
		loadSettings: loadSettings,
		loadDefaultStudySettings: loadDefaultStudySettings,
		visit: visit,
		loadVisitInfo: loadVisitInfo,
		visitInfo: visitInfo,
		allforms: allforms,
		alllabs: alllabs,
		defaultStudyId: defaultStudyId
	};
}();

$(function () {
	ko.applyBindings(mx.vm);

	$("body").on("change", "#StudyId", function () {
		var id = $(this).val();
		return mx.vm.loadSettings(id);
	});

	$("body").on("change", "#visitId", function () {
		var id = $(this).val();
		mx.vm.loadVisitInfo(id);
		$("#mapId").css('border', '');
	});

	$("body").on("click select", "#formId", function () {
		var id = $(this).val();
		ko.utils.arrayFirst(mx.vm.settings().Forms(), function (elt) {
			if (mx.vm.visit && elt && id && elt.Id() === Number(id[0])) {
				elt.VisitId(mx.vm.visit().VisitId());
				mx.vm.visitInfo.push(elt);
				mx.vm.settings().Forms.remove(elt);
			}
		});
	});

	$("body").on("click select", "#labId", function () {
		var id = $(this).val();
		ko.utils.arrayFirst(mx.vm.settings().Labs(), function (elt) {
			if (mx.vm.visit && elt && id && elt.Id() === Number(id[0])) {
				elt.VisitId(mx.vm.visit().VisitId());
				mx.vm.visitInfo.push(elt);
				mx.vm.settings().Labs.remove(elt);
			}
		});
	});

	$("body").on("click", "#mapId", function () {
		var id = $(this).val();
		ko.utils.arrayFirst(mx.vm.visitInfo(), function (elt) {
			if (elt && id && elt.Id() === Number(id[0])) {
				mx.vm.visitInfo.remove(elt);
				if (elt.FormTypeId() == 1) {
					mx.vm.settings().Forms.push(elt);
				} else {
					mx.vm.settings().Labs.push(elt);
				}
			}
		});

		if (mx.vm.settings().length > 0) {
			mx.vm.settings().Labs.sort(function(left, right) {
				return (left.Name() < right.Name() ? -1 : 1);
			});
			mx.vm.settings().Forms.sort(function(left, right) {
				return (left.Name() < right.Name() ? -1 : 1);
			});
		}
	});

	$("body").on('click', "#btnSettingsUpdate", function () {
		var json = JSON.stringify({ mapping: ko.toJSON(mx.vm.visitInfo) });

		$.ajax({
			url: "/Admin/Mapping/UpdateSettings",
			type: 'POST',
			data: json,
			dataType: "json",
			contentType: "application/json; charset=utf-8",
			success: function (d) {
			    toastr.alert("Done");
			},
			error: function (d) {
				toastr.error(d.responseText);
			}
		});
	});
});