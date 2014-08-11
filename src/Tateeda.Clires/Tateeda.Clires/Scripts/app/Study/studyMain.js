var std = std || {};
std.vm = function () {
    var appointments = ko.observableArray([]),
        loadAppointements = function (start, end, callback) {
            $.ajax({
                url: "/Json/LoadCalendarEvents",
                type: 'POST',
                data: { start: toAspDate(start), end: toAspDate(end) },
                cache: false,
                dataType: 'json',
                success: function (d) {
                    appointments([]);
                    $.each(d, function (i, data) {
                        appointments.push(ko.mapping.fromJS(data));
                    });
                    if (callback)
                        callback(appointments);
                },
                error: function (e) {
                    toastr.error(e.responseText);
                }
            });
        },		
        sortBy = function(field) {
        	if (field) {
        		appointments.sort(function (a, b) {
        			try {
        				return eval('a.' + field)() < eval('b.' + field)() ? -1 : 1;
        			}catch (e) {
        				return eval('a.' + field) < eval('b.' + field) ? -1 : 1;
        			}
        		});
        	}
        },
        gridViewModel = new ko.simpleGrid.viewModel({
            data: appointments,
            columns: [
                {
                    headerText: "",
                    rowText: function (item) {
                        return '<button class="btn btn-mini appointment" data-id=' + item.Id() + '><i class="icon-user"></i></button>';
                    },
                    sortColumnName: ''
                },
                {
                    headerText: "Appointments",
                    rowText: function (item) {
                        return new Date(item.CalendarStart()).toString();
                    },
                    sortColumnName: 'CalendarStart'
                },
                {
                    headerText: "Title",
                    rowText: function (item) {
                        return item.Title();
                    },
                    sortColumnName: 'Title'
                },
                {
                    headerText: "Subject",
                    rowText: function (item) {
                    	var link = "<a href='/Subject/Info/Details/" + item.SubjectId() + "'>" + item.SubjectId() + " [" + item.SubjectFullName() + "]</a>";
	                    return link;
                    },
                    sortColumnName: 'SubjectId'
                },
                {
                    headerText: "Visit",
                    rowText: function (item) {
                        return item.VisitName;
                    },
                    sortColumnName: 'Visit'
                },
                {
                    headerText: "With",
                    rowText: function (item) {
                        return item.AppUserFullName;
                    },
                    sortColumnName: 'AppUserFullName'
                },
                {
                    headerText: "Status",
                    rowText: function (item) {
                        switch (item.Status()) {
                            case 0:
                                return "---";
                            case 1:
                                return "Scheduled";
                            case 2:
                                return "In Progress";
                            case 3:
                                return "Needs Follow Up";
                            case 4:
                                return "Completed";
                            case 5:
                                return "Require More Data";
                            case 6:
                                return "Canceled";
                            case 7:
                                return "No Show";
                            default:
                                return "N/A";
                        }
                    },
                    sortColumnName: 'Status'
                },
                {
                    headerText: "Forms",
                    rowText: function (item) {
                        return item.AllFormsCount();
                    },
                    sortColumnName: 'AllFormsCount'
                }
            ],
            pageSize: 10
        });

    return {
        appointments: appointments,
        gridViewModel: gridViewModel,
        loadAppointements: loadAppointements,
        sortBy: sortBy
    };
}();

$(function () {
    init();
    $("body").on('click',".appointment", function () {
        var apptId = $(this).attr('data-id');
        gotoAppointment(apptId);
    });
    $("#btnSearch").on('click', function() {
        var f = new Date($("#apptFrom").val());
        var t = new Date($("#apptTo").val());
        std.vm.loadAppointements(f, t);
        //ko.applyBindings(std.vm);
    });
    $("body").on('click', ".sortableHead", function () {
    	var field = $(this).attr('sortname');
    	std.vm.sortBy(field);
    });

    $(".loadingIndicator").hide();
    ko.applyBindings(std.vm);
});

function init() {
    var d = new Date();
    var s = new Date();
    s.setDate(d.getDate() - 7);
    var e = new Date();
    e.setDate(d.getDate() + 7);
    std.vm.loadAppointements(s, e);
    //ko.applyBindings(std.vm);
}

function gotoAppointment(apptId) {
    window.location = "/Study/Visit/Index/" + apptId;
}
