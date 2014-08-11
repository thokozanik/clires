var vis = vis || {};
vis.vm = new function () {
    var arms = ko.observableArray([]),
        visits = ko.observableArray([]),
		defaultStudyId = 0,
        visit = ko.observable({
            StudyId: ko.observable(),
            VisitTypeId: ko.observable(),
            ArmId: ko.observable(),
            Name: ko.observable(),
            Code: ko.observable(),
            Directions: ko.observable(),
            SortOrder: ko.observable(0),
            Status: ko.observable(1),
            CreatedOn: ko.observable(),
            UpdatedOn: ko.observable(),
            CreatedBy: ko.observable(),
            UpdatedBy: ko.observable(),
            IsActive: ko.observable(true),
            ParentVisitId: ko.observable(),
            IsBaseVisit: ko.observable(false),
            CanRepeat: ko.observable(true),
            CanMove: ko.observable(true),
            HasChild: ko.observable(false),
            Appointments: ko.observableArray([]),
            Arm: ko.observable(),
            FormVisibilityByVisitForSubjects: ko.observableArray([]),
            ScheduleSubjectVisits: ko.observableArray([]),
            VisitStepVisitSequences: ko.observableArray([]),
            VisitForms: ko.observableArray([]),
            VisitSteps: ko.observableArray([]),
            Id: ko.observable()
        }),
        newVisit = function () {
            return {

                StudyId: ko.observable(vis.vm.defaultStudyId),
                VisitTypeId: ko.observable(),
                ArmId: ko.observable(),
                Name: ko.observable(),
                Code: ko.observable(),
                Directions: ko.observable(),
                SortOrder: ko.observable(0),
                Status: ko.observable(1),
                CreatedOn: ko.observable(),
                UpdatedOn: ko.observable(),
                CreatedBy: ko.observable(),
                UpdatedBy: ko.observable(),
                IsActive: ko.observable(true),
                ParentVisitId: ko.observable(),
                IsBaseVisit: ko.observable(false),
                CanRepeat: ko.observable(true),
                CanMove: ko.observable(true),
                HasChild: ko.observable(false),
                Appointments: ko.observableArray([]),
                Arm: ko.observable(),
                FormVisibilityByVisitForSubjects: ko.observableArray([]),
                ScheduleSubjectVisits: ko.observableArray([]),
                VisitStepVisitSequences: ko.observableArray([]),
                VisitForms: ko.observableArray([]),
                VisitSteps: ko.observableArray([]),
                Id: ko.observable()

            };
        },
	    loaddefaultStudy = function () {
		    loadVisits(vis.vm.defaultStudyId);
	    },
        loadVisits = function (id) {
            $.ajax({
                url: "/Json/GetAllVisits",
                data: { studyId: id },
                type: 'POST',
                cache: false,
                dataType: 'json',
                success: function (d) {
                    visits([]);
                    $.each(d, function (i, data) {
                        visits.push(ko.mapping.fromJS(data));
                    });
                    //ko.applyBindings(vis.vm);
                    if (visits().length > 0) {
                        $(".app-grid").show();
                    }
                }
            });
        },
        loadArms = function (studyId) {
            if (studyId > 0) {
                $.ajax({
                    url: "/Json/GetArms",
                    data: { id: studyId },
                    type: 'POST',
                    cache: false,
                    dataType: 'json',
                    success: function (d) {
                        arms([]);
                        $.each(d, function (i, data) {
                            arms.push(ko.mapping.fromJS(data));
                        });
                        //ko.applyBindings(vis.vm);
                    },
                    error: function (e) {
                        toastr.error(e.responseText);
                    }
                });
            }
        },
        selectedArm = function (item) {
            for (var i = 0; i < item.length; i++) {
                if (item[i].Selected() === true) {
                    return item[i].SelectedId;
                }
            }
            return '';
        },
        sortBy = function (field) {
            if (field) {
                visits.sort(function (a, b) {
                    try {
                        return eval('a.' + field)() < eval('b.' + field)() ? -1 : 1;
                    } catch (e) {
                        return eval('a.' + field) < eval('b.' + field) ? -1 : 1;
                    }
                });
            }
        },
        gridViewModel = new ko.simpleGrid.viewModel({
            data: visits,
            columns: [
                {
                    headerText: "Controls",
                    rowText: function (item) {
                        return '<button class="btn btn-mini edit" data-id=' + item.Id() + '><i class="icon-pencil"></i> Edit</button>';
                    },
                    sortColumnName: ''
                },
                {
                    headerText: "Name",
                    rowText: function (item) {
                        return item.Name;
                    },
                    sortColumnName: 'Name'
                },

                {
                    headerText: "Code",
                    rowText: function (item) {
                        return item.Code;
                    },
                    sortColumnName: 'Code'
                },
                {
                    headerText: "Description",
                    rowText: function (item) {
                        return item.Directions;
                    },
                    sortColumnName: 'Directions'
                },
                {
                    headerText: "Arm/Phase",
                    rowText: function (item) {
                        return item.ArmName;
                    },
                    sortColumnName: 'ArmName'
                },
                {
                    headerText: "Depends On",
                    rowText: function (item) {
                        return item.ParentVisitName;
                    },
                    sortColumnName: 'ParentVisitName'
                },
                {
                    headerText: "Total Forms",
                    rowText: function (item) {
                        return item.FormsCount;
                    },
                    sortColumnName: 'FormsCount'
                },
                {
                    headerText: "Base",
                    rowText: function (item) {
                        return item.IsBaseVisit() ? "<span style='color:green;'>Yes</span>" : "No";
                    },
                    sortColumnName: 'IsBaseVisit'
                },
                {
                    headerText: "Can Repeat",
                    rowText: function (item) {
                        return item.CanRepeat() ? "<span style='color:orange;'>Yes</span>" : "No";
                    },
                    sortColumnName: 'CanRepeat'
                },
                {
                    headerText: "Can Move",
                    rowText: function (item) {
                        return item.CanMove() ? "<span style='color:green;'>Yes</span>" : "No";
                    },
                    sortColumnName: 'CanMove'
                },
                {
                    headerText: "Has Child",
                    rowText: function (item) {
                        return item.HasChild() ? "<span style='color:navy;'>Yes</span>" : "No";
                    },
                    sortColumnName: 'HasChild'
                },
                {
                    headerText: "Is Active",
                    rowText: function (item) {
                        if (item.IsActive()) {
                            return '<span  class=\"span1 userstatus label label-success\" data-id=\"' + item.Id() + '\">Active</span>';
                        } else {
                            return '<span  class=\"span1 userstatus label label-important\" data-id=\"' + item.Id() + '\">Inactive</span>';
                        }
                    },
                    sortColumnName: 'IsActive'
                }
            ],
            pageSize: 10,
            //width: 400,
        });

    return {
        arms: arms,
        selectedArm: selectedArm,
        visits: visits,
        visit: visit,
        newVisit: newVisit,
        loadVisits: loadVisits,
        loadArms: loadArms,
        sortBy: sortBy,
        gridViewModel: gridViewModel,
        loaddefaultStudy: loaddefaultStudy
    };
}();

$(function () {
    window.setTimeout(function () {
        //vis.vm.loadVisits();
        init();
    }, 50);

    $("#modellink").on("click", function () {
        vis.vm.visit(vis.vm.newVisit());
    });

    $(".app-grid").hide();

    ko.applyBindings(vis.vm);
});

function init() {
    $(".loadingIndicator").hide();

    $("body").on("change", "#StudyId", function () {
        var id = $(this).val();
        vis.vm.loadVisits(id);
        vis.vm.loadArms(id);
    });

    $("body").on("click",  ".userstatus", function () {
        toastr.error($(this).data('id'));
    });

	$("body").on('click', ".sortableHead", function() {
		var field = $(this).attr('sortname');
		vis.vm.sortBy(field);
	});

    $("body").on("click", ".edit", function () {
        var id = $(this).attr('data-id');
        var data = ko.utils.arrayFirst(vis.vm.visits(), function (item) {
            return item.Id() == id;
        });
        $("#visit-modal").modal('show');
        vis.vm.visit(data);
    });
}

