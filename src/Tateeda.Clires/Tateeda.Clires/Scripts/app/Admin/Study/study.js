var std = std || {};

std.vm = function () {
	var studies = ko.observableArray([]),
		defaultStudyId = 0,
		studyitem = ko.observable(),
		getstudies = function () {
			$.ajax({
				url: "/Json/GetStudies",
				dataType: 'json',
				cache: false,
				success: function (d) {
					studies([]);
					$.each(d, function (i, data) {
						studies.push(ko.mapping.fromJS(data));
					});					
				}
			});
		},
		sortBy = function (field) {
			if (field) {
				studies.sort(function (a, b) {
					try {
						return eval('a.' + field)() < eval('b.' + field)() ? -1 : 1;
					} catch (e) {
						return eval('a.' + field) < eval('b.' + field) ? -1 : 1;
					}
				});
			}
		},
		gridViewModel = new ko.simpleGrid.viewModel({
			data: studies,
			columns: [
				{
					headerText: "Controls",
					rowText: function (item) {
						return '<button class="btn btn-mini edit" data-id=' + item.Id() + '><i class="icon-pencil"></i> Edit</button>';
					},
					sortColumnName: ''
				},
				{ headerText: "Name", rowText: function (item) { return item.Name(); }, sortColumnName: 'Name' },
				{ headerText: "Description", rowText: function (item) { return item.Description(); }, sortColumnName: 'Description' },
				{ headerText: "Targets", rowText: function (item) { return item.Target(); }, sortColumnName: 'Target' },
				{ headerText: "Goals", rowText: function (item) { return item.Goal(); }, sortColumnName: 'Goal' },
				{ headerText: "Budget", rowText: function (item) { return item.Budget(); }, sortColumnName: 'Budget' },
				{
					headerText: "Start Date",
					rowText: function (item) {
						try {
							var dt = eval('new ' + item.StartDate().replace("/", '').replace("/", ''));
							item.StartDate(dt.toDateString());
							return dt.toDateString();
						}catch (e) {
							return 'N/A';
						}
					},
					sortColumnName: 'StartDate'
				},
				{
					headerText: "End Date",
					rowText: function (item) {
						try {
							if (item.EndDate()) {
								var dt = eval('new ' + item.EndDate().replace("/", '').replace("/", ''));
								item.EndDate(dt.toDateString());
								var enddate = dt.toDateString();
								return enddate;
							}
						} catch (e) {
							return 'N/A';
						}
					},
					sortColumnName: 'EndDate'
				},
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
		newStudy = function () {
			return {
				Name: ko.observable(),
				Description: ko.observable(),
				StartDate: ko.observable(),
				EndDate: ko.observable(),
				Target: ko.observable(),
				Goal: ko.observable(),
				Budget: ko.observable(),
				SortOrder: ko.observable(),
				Status: ko.observable(1),
				CreatedOn: ko.observable(),
				UpdatedOn: ko.observable(),
				CreatedBy: ko.observable(),
				UpdatedBy: ko.observable(),
				IsActive: ko.observable(true),
				Arms: ko.observable(),
				Drugs: ko.observable(),
				Forms: ko.observable(),
				Sites: ko.observable(),
				Id: ko.observable(0),
			};
		};

	return {
		studies: studies,
		defaultStudyId: defaultStudyId,
		studyitem: studyitem,
		newStudy: newStudy,
		getstudies: getstudies,
		sortBy: sortBy,
		gridViewModel: gridViewModel
	};
}();

$(document).ready(function () {
	window.setTimeout(function () {		
		init();		
		std.vm.getstudies();
		ko.applyBindings(std.vm);
	}, 300);

});

function init() {
	$("body").on("click", ".edit", function () {
		var sid = $(this).attr('data-id');
		var data = ko.utils.arrayFirst(std.vm.studies(), function (item) {
			return item.Id() == sid;
		});
		$("#newstudy-modal").modal('show');

		std.vm.studyitem(data);
	});

	$("#modellink").on("click", function () {
		std.vm.studyitem(std.vm.newStudy());
	});

	$("body").on("click", ".userstatus", function () {
		toastr.error($(this).data('id'));
	});

	$("body").on('click', ".sortableHead", function () {
		var field = $(this).attr('sortname');
		std.vm.sortBy(field);
	});
}