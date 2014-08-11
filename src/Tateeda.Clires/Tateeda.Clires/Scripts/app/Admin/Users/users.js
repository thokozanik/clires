var admin = admin || {};

admin.vm = new function() {
    var users = ko.observableArray([]),
        user = ko.observable(),
	    isreadonly = ko.observable(null),
        sites = function() {
            $("#sites").find('option').remove().end().append('<option value="">Select</option>').val('');
            $.ajax({
                url: "/Json/GetSites",
                dataType: 'json',
                cache: false,
                success: function (d) {
                    $.each(d, function(i, value) {                       
                        $("#sites").append($('<option>').text(value.Name).attr('value', value.Id));
                    });
                }
            });
        },
        siteusers = function(id) {            
        	if (Number(id) > 0) {       		        		
                if ($(".app-grid").is(":hidden"))
                    $(".app-grid").show('slow');

                $.ajax({
                    url: "/Json/GetSiteUsers",
                    data: { id: id },
                    cache: false,
                    dataType: 'json',
                    success: function(d) {
                    	users([]);
                    	isreadonly('readonly');
                        $.each(d, function(i, data) {
                            //user(ko.mapping.fromJS(data));
                            users.push(ko.mapping.fromJS(data));
                        });                        
                    },
                    error: function(e) {
                        toastr.error(e.responseText);
                    }
                });
            } else {
                $(".app-grid").hide('fast');
            }
        },
        sortBy = function(field) {
            if (field) {
                users.sort(function (a, b) {
                    try {
                        return eval('a.' + field)() < eval('b.' + field)() ? -1 : 1;
                    }catch (e) {
                        return eval('a.' + field) < eval('b.' + field) ? -1 : 1;
                    }
                });
            }
        },
        gridViewModel = new ko.simpleGrid.viewModel({
            data: users,
            columns: [
                {
                    headerText: "Controls",
                    rowText: function(item) {
                        return '<button class="btn btn-mini edit" data-id=' + item.Id() + '><i class="icon-pencil"></i> Edit</button>';
                    },
                    sortColumnName: ''
                },
                {
                    headerText: "First",
                    rowText: function(item) {
                        return item.Contact.FirstName;
                    },
                    sortColumnName: 'First'
                },
                {
                    headerText: "Last",
                    rowText: function(item) {
                        return item.Contact.LastName;
                    },
                    sortColumnName: 'Last'
                },
                {
                    headerText: "Role",
                    rowText: function(item) {
                        return item.RoleName;
                    },
                    sortColumnName: 'Role'
                },
                {
                    headerText: "Email",
                    rowText: function (item) {
                        return item.Email;
                    },
                    sortColumnName: 'Email'
                },
                {
                    headerText: "Phone",
                    rowText: function (item) {
                        return item.Contact.Phones()[0].Telephone;
                    },
                    sortColumnName: 'Phone'
                },
                {
                    headerText: "Is Active",
                    rowText: function(item) {
                        if (item.IsActive) {
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
        }),
        newUser = function () {
	        isreadonly(null);
            return {                
                SiteId: ko.observable(0),
                Title: ko.observable(),
                SortOrder: ko.observable(),
                Comments: ko.observable(),
                Status: ko.observable(1),
                UpdatedOn: ko.observable(),
                CreatedOn: ko.observable(),
                UpdatedBy: ko.observable(),
                CreatedBy: ko.observable(),
                IsActive: ko.observable(true),
                MembershipUserId: ko.observable(),
                Id: ko.observable(-1),
                Email: ko.observable(''),
                Password: ko.observable(''),
                UserName: ko.observable(''),
                RoleId: ko.observable(0),
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
                        AreaCode: ko.observable(),
                        Number: ko.observable(),
                        PhoneTypeId: ko.observable(4)
                    }]),
                }
            };
        };

    return {
        users: users,
        user: user,
        newUser: newUser,
        sites: sites,
        siteusers: siteusers,
        sortBy: sortBy,
        isreadonly: isreadonly,
        gridViewModel: gridViewModel
    };
}();

$(function () {
    window.setTimeout(function () {
        admin.vm.sites();
        init();
        ko.applyBindings(admin.vm);
    }, 50);


    $("#modellink").on("click", function () {
        admin.vm.user(admin.vm.newUser());
    });

    $(".app-grid").hide();

    $("#sites").change(function () {
        admin.vm.siteusers($(this).val());
    });

});

function init() {
	$("body").on("click",".userstatus", function () {
        toastr.error($(this).data('id'));
    });

    $("body").on('click', ".sortableHead", function () {
        var field = $(this).attr('sortname');
        admin.vm.sortBy(field);
    });

    $("body").on("click", ".edit", function () {
        var uid = $(this).attr('data-id');
        var data = ko.utils.arrayFirst(admin.vm.users(), function (item) {
            return item.Id() == uid;
        });
        $("#newuser-modal").modal('show');

        //admin.vm.user(data);
        admin.vm.user(data);
        //$("#debug").html(ko.toJSON(data));
        //ko.applyBindings(admin.vm);
    });

    $("#CountryId").change(function () {
        var id = $("#CountryId  option:selected").val();
        $.ajax({
            url: "/Json/GetStates",
            data: { id: id },
            cache: false,
            dataType: 'json',
            success: function (d) {
                $("#StateId")
                    .find('option')
                    .remove()
                    .end();
                $.each(d, function(i, data) {
                    $("#StateId").append("<option value='" + data.Value + "'>" + data.Text + "</option>");
                });
            },
            error: function (e) {
                toastr.error(e.responseText);
            }
        });
    });
}