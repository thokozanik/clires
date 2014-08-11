var site = site || {};

site.vm = new function () {
	var sites = ko.observableArray([]),
		defaultStudyId = 0,
        entity = ko.observable(),
        getSites = function () {
            $.ajax({
                url: "/Json/GetSites",
                dataType: 'json',
                cache:false,
                success: function (d) {
                    sites([]);                    
                    $.each(d, function (i, data) {
                        sites.push(data);
                    });
                    if (sites().length > 0) {
                        //ko.applyBindings();
                        $("#site-modal").modal('hide');
                        if ($(".app-grid").is(":hidden"))
                            $(".app-grid").show();
                    }else {
                        $(".app-grid").hide();
                    }
                }
            });
        },
        sortBy = function (field) {
            if (field) {
                sites.sort(function (a, b) {
                    try {
                        return eval('a.' + field)() < eval('b.' + field)() ? -1 : 1;
                    } catch (e) {
                        return eval('a.' + field) < eval('b.' + field) ? -1 : 1;
                    }
                });
            }
        },
        gridViewModel = new ko.simpleGrid.viewModel({
            data: sites,
            columns: [
                {
                    headerText: "Controls",
                    rowText: function (item) {
                        return '<button class="btn btn-mini edit" data-id=' + item.Id + '><i class="icon-pencil"></i> Edit</button>';
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
                    headerText: "Time Zone",
                    rowText: function (item) {
                        return item.TimeZoneName;
                    },
                    sortColumnName: 'TimeZoneName'
                },
                {
                    headerText: "Is Active",
                    rowText: function (item) {
                        if (item.IsActive && item.Status === 1) {
                            return '<span  class=\"span1 usertatus label label-success\" data-id=\"' + item.Id + '\">Active</span>';
                        } else {
                            return '<span  class=\"span1 usertatus label label-important\" data-id=\"' + item.Id + '\">Inactive</span>';
                        }
                    },
                    sortColumnName: 'IsActive'
                },
                {
                    headerText: "Description",
                    rowText: function (item) {
                        return item.Directions;
                    },
                    sortColumnName: 'Directions'
                }
            ],
            pageSize: 10,
            //width: 400,
        }),
        newSite = function () {
            return {
                Id: ko.observable(),
                Name: ko.observable(),
                Code: ko.observable(),
                TimeZoneId: ko.observable(),
                SortOrder: ko.observable(),
                Directions: ko.observable(),
                Status: ko.observable(1),
                UpdatedOn: ko.observable(),
                CreatedOn: ko.observable(),
                UpdatedBy: ko.observable(),
                CreatedBy: ko.observable(),
                IsActive: ko.observable(true),
                IsPrimary: ko.observable(false),
                TimeZoneName: ko.observable(''),
                StudyId: ko.observable(site.vm.defaultStudyId)
            };
        };

    return {
    	sites: sites,
    	defaultStudyId: defaultStudyId,
        entity: entity,
        newSite: newSite,
        getSites: getSites,
        sortBy: sortBy,
        gridViewModel: gridViewModel
    };
}();

$(document).ready(function () {
    ko.applyBindings(site.vm);
    
    window.setTimeout(function () {
        site.vm.getSites();
        init();
    }, 50);

    $("#modellink").on("click", function () {
        site.vm.entity(site.vm.newSite());
    });
       
});

function init() {
	$("body").on("click", ".userstatus", function() {
		toastr.error($(this).data('id'));
	});

    $("body").on('click', ".sortableHead", function () {
    	var field = $(this).attr('sortname');
    	site.vm.sortBy(field);
    });
	
    $(".sortableHead").addClass('caret');

    $("body").on("click", ".edit", function () {
        var uid = $(this).attr('data-id');
        var data = ko.utils.arrayFirst(site.vm.sites(), function (item) {
            return item.Id == uid;
        });
        $("#site-modal").modal('show');

        site.vm.entity(data);
    });
}

