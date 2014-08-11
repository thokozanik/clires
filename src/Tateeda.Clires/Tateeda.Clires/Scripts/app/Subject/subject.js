/// <reference path="../../lib/knockout-2.1.0.debug.js" />
/// <reference path="../../lib/jquery-1.8.0.js" />
/// <reference path="~/Scripts/lib/knockout.simplegrid.1.3.js" />
var sub = sub || {};
sub.vm = new function () {
    var subject = ko.observable(),
		subjects = ko.observableArray([]),
		getSubjects = function (id) {
			if (id > 0) {
				$.ajax({
					url: "/Json/GetSubjects",
					data: { id: id },
					dataType: 'json',
					cache: false,
					success: function (d) {
						subjects([]);
						$.each(d, function (i, data) {
							subject(ko.mapping.fromJS(data));
							subjects.push(subject());
						});

						//ko.applyBindings(sub.vm);
						$(".app-grid").show();
					}
				});
			}
		},
		getSubject = function (id) {
			if (id > 0) {
				$.ajax({
					url: "/Json/GetSubjectInfo",
					data: { subjectId: id },
					dataType: 'json',
					success: function (d) {
						subject(ko.mapping.fromJS(d));
					}
				});
			}
		},
		find = function (what) {
			if (what.length > 0) {
				$.ajax({
					url: "/Json/FindSubjects",
					data: { what: what },
					dataType: 'json',
					cache: false,
					success: function (d) {
						subjects([]);
						$.each(d, function (i, data) {
							subject(ko.mapping.fromJS(data));
							subjects.push(subject());
						});

						//ko.applyBindings(sub.vm);
						$(".app-grid").show();
					}
				});
			}
		},
		sortBy = function (field) {
			if (field) {
				subjects.sort(function (a, b) {
					try {
						return eval('a.' + field)() < eval('b.' + field)() ? -1 : 1;
					} catch (e) {
						return eval('a.' + field) < eval('b.' + field) ? -1 : 1;
					}
				});
			}
		},
		gridViewModel = new ko.simpleGrid.viewModel({
			data: subjects,
			columns: [
				{
					headerText: "Controls",
					rowText: function (item) {
						return '<button class="btn btn-mini edit" data-id=' + item.Id() + '><i class="icon-pencil"></i> Edit</button>';
					},
					sortColumnName: ''
				},
				{
					headerText: "ID",
					rowText: function (item) {
						return item.Id();
					},
					sortColumnName: 'Id'
				},
				{
					headerText: "First",
					rowText: function (item) {
						return item.Contact.FirstName();
					},
					sortColumnName: 'First'
				},
				{
					headerText: "Last",
					rowText: function (item) {
						return item.Contact.LastName();
					},
					sortColumnName: 'Last'
				},
				{
					headerText: "Is Active",
					rowText: function (item) {
						if (item.IsActive) {
							return '<span  class=\"span1 userstatus label label-success\" data-id=\"' + item.Id() + '\">Active</span>';
						} else {
							return '<span  class=\"span1 userstatus label label-important\" data-id=\"' + item.Id() + '\">Inactive</span>';
						}
					},
					sortColumnName: 'IsActive'
				},
				{
					headerText: "Details",
					rowText: function (item) {
						return '<button class="btn btn-mini subject-details" data-id=' + item.Id() + '><i class="icon-info-sign"></i>View</button>';
					},
					sortColumnName: ''
				}
			],
			pageSize: 10,
		}),
		newSubject = function () {
			return {
				Id: ko.observable(0),
				SiteId: ko.observable(0),
				StudyId: ko.observable(0),
				Nickname: ko.observable(''),
				FamilyId: ko.observable(0),
				Notes: ko.observable(''),
				NIMHID: ko.observable(''),
				GenderTypeId: ko.observable(0),
				YearBorn: ko.observable(0),
				FirstName: ko.observable(''),
				LastName: ko.observable(''),
				DateOfBirth: ko.observable(),
				Directions: ko.observable(''),
				SortOrder: ko.observable(0),
				Status: ko.observable(1),
				CreatedOn: ko.observable(),
				UpdatedOn: ko.observable(),
				CreatedBy: ko.observable(),
				UpdatedBy: ko.observable(),
				IsActive: ko.observable(true),
				Street: ko.observable(),
				City: ko.observable(),
				PostalCode: ko.observable(),
				StateId: ko.observable(),
				CountryId: ko.observable(),
				Telephone: ko.observable(),
				Address: ko.observable(),
				AddressTypeId: ko.observable(),
				PhoneTypeId: ko.observable(),
				SSN: ko.observable(),
				Contact: {
					FirstName: ko.observable(),
					LastNamae: ko.observable(),
					ContactTypeId: ko.observable(),
					Addresses: ko.observableArray([{
						Street: ko.observable(),
						City: ko.observable(),
						PostalCode: ko.observable(),
						CountryId: ko.observable(),
						StateId: ko.observable(),
						AddressTypeId: ko.observable(),
					}]),
					Emails: ko.observableArray([{
						Address: ko.observable()
					}]),
					Phones: ko.observableArray([{
						AreaCodef: ko.observable(),
						Number: ko.observable(),
						PhoneTypeId: ko.observable()
					}]),
				}
			};
		};

	return {
		subject: subject,
		subjects: subjects,
		gridViewModel: gridViewModel,
		getSubject: getSubject,
		getSubjects: getSubjects,
		sortBy: sortBy,
		newSubject: newSubject,
		find: find
	};
}();

$(function () {
    sub.vm.subject(sub.vm.newSubject());
    
	window.setTimeout(function () {
		var sid = siteId || null;
		if (sid) {
			sub.vm.getSubjects(siteId);
		}
		init();
	}, 50);

	$("#modellink").on("click", function () {
		sub.vm.subject(sub.vm.newSubject());
		$("#subject-modal").modal('show');
	});	
	$(".app-grid").hide();
	
	$("body").on('click', ".sortableHead", function () {
		var field = $(this).attr('sortname');
		sub.vm.sortBy(field);
	});
    
	ko.applyBindings(sub.vm);
});

function init() {
	$(".userstatus").on("click", function () {
	});

	$("body").on("click", ".edit", function () {
		var uid = $(this).attr('data-id');
		var data = ko.utils.arrayFirst(sub.vm.subjects(), function (item) {
			return item.Id() == uid;
		});
		
		sub.vm.subject(ko.mapping.fromJS(data));
		$("#subject-modal").modal('show');
		// $("#debug").html(ko.toJSON(data));
	});

	$("body").on('click', ".subject-details", function () {
		var id = $(this).attr('data-id');
		window.location = "/Subject/Info/Details/" + id;
	});

	$("#btnSubjectSearch").on('click', function () {
		sub.vm.find($("#searchSubject").val());
	});
}