/// <reference path="~/Scripts/lib/knockout.simplegrid.1.3.js" />
var studyArms = studyArms || {};

studyArms.vm = new function () {
	var arms = ko.observableArray([]),
		defaultStudyId = 0,
		arm = ko.observable(),
		loaddefault = function () {
			getStudyArms(studyArms.vm.defaultStudyId);
		},
		getStudyArms = function (id) {
			arms([]);
			if (id > 0) {
				$.ajax({
					url: "/Json/GetArms",
					dataType: 'json',
					data: { id: id },
					cache: false,
					success: function (d) {
						arms([]);
						$.each(d, function (i, data) {
							arms.push(ko.mapping.fromJS(data));
						});
						//ko.applyBindings(studyArms.vm);
					},
					error: function (e) {
						toastr.error(e);
					}
				});
			}
		},
		sortBy = function (field) {
			if (field) {
				arms.sort(function (a, b) {
					try {
						return eval('a.' + field)() < eval('b.' + field)() ? -1 : 1;
					} catch (e) {
						return eval('a.' + field) < eval('b.' + field) ? -1 : 1;
					}
				});
			}
		},
		gridViewModel = new ko.simpleGrid.viewModel({
			data: arms,
			columns: [
				{
					headerText: "Controls",
					rowText: function (item) {
						return '<button class="btn btn-mini edit" data-id=' + item.Id() + '><i class="icon-pencil"></i> Edit</button>';
					},
					sortColumnName: ''
				},
				{ headerText: "Name", rowText: function (item) { return item.Name(); }, sortColumnName: 'Name' },
				{ headerText: "Code", rowText: function (item) { return item.Code(); }, sortColumnName: 'Code' },
				{ headerText: "Description", rowText: function (item) { return item.Description(); }, sortColumnName: 'Description' },
				{
					headerText: "State",
					rowText: function (item) {
						if (item.IsActive()) {
							return '<span  class=\"span1 userstatus label label-success\" data-id=\"' + item.Id() + '\">Active</span>';
						} else {
							return '<span  class=\"span1 userstatus label label-important\" data-id=\"' + item.Id() + '\">Inactive</span>';
						}
						return '';
					},
					sortColumnName: 'IsActive'
				}
			],
			pageSize: 10
		}),
		newArm = function () {
			return {
				Id: ko.observable(0),
				StudyId: ko.observable(studyArms.vm.defaultStudyId),
				Name: ko.observable(),
				Code: ko.observable(),
				Description: ko.observable(),
				IsActive: ko.observable(true)
			};
		};

	return {
		arms: arms,
		loaddefault:loaddefault,
		defaultStudyId: defaultStudyId,
		arm: arm,
		newArm: newArm,
		getStudyArms: getStudyArms,
		sortBy: sortBy,
		gridViewModel: gridViewModel
	};
}();


$(document).ready(function () {
	init();
});

function init() {
	ko.applyBindings(studyArms.vm);
	
	$(".loadingIndicator").hide();

	$("body").on("change", "#StudyId", function () {
		var id = $(this).val();
		studyArms.vm.getStudyArms(id);
	});

	$("body").on("click", ".edit", function () {
		var aid = $(this).attr('data-id');
		var data = ko.utils.arrayFirst(studyArms.vm.arms(), function (item) {
			return item.Id() == aid;
		});
		$("#newarm-modal").modal('show');

		studyArms.vm.arm(data);
	});

	$("#modellink").on("click", function () {		
		studyArms.vm.arm(studyArms.vm.newArm());
	});

	$("body").on('click', ".sortableHead", function () {
		var field = $(this).attr('sortname');
		studyArms.vm.sortBy(field);
	});	
}