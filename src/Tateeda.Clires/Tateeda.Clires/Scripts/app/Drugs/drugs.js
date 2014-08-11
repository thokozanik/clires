var med = med || {};
med.vm = function () {
    var isChanged = ko.observable(false),
        categories = ko.observableArray([]),
        classes = ko.observableArray([]),
        drugs = ko.observableArray([]),
        category = ko.observable(),
        categoryVal = ko.observable(),
        classVal = ko.observable(),
        drugVal = ko.observable(),
        clazz = ko.observable(),
        drug = ko.observable(),
        drugsTotal = ko.observable(0),
        selectedClassId = ko.observable(0),
        currentPageIndex = ko.observable(1),
        loadCategories = function() {
            $.ajax({
                url: "/Json/GetDrugCategories",
                cache: false,
                dataType: 'json',
                success: function(d) {
                    drugs([]);
                    categories([]);
                    $.each(d, function(i, data) {
                        categories.push(ko.mapping.fromJS(data));
                    });
                },
                error: function(e) {
                    toastr.error(e.responseText);
                }
            });
        },
        loadClasses = function(catId) {
            if (catId > 0) {
                drugs([]);
                $("#editDrug").attr('disabled', 'disabled');
                $("#editClass").attr('disabled', 'disabled');
                med.vm.currentPageIndex(1);
                $.ajax({
                    url: "/Json/GetDrugClasses",
                    cache: false,
                    data: { id: catId },
                    dataType: 'json',
                    success: function(d) {
                        classes([]);
                        $.each(d, function(i, data) {
                            classes.push(ko.mapping.fromJS(data));
                        });
                        //ko.applyBindings(med.vm);
                    },
                    error: function(e) {
                        toastr.error(e.responseText);
                    }
                });
            }
        },
        loadDrugs = function(classId, pageIndex, pageSize) {
            if (classId > 0) {
                $("#editDrug").attr('disabled', 'disabled');
                selectedClassId(classId);
                $.ajax({
                    url: "/Json/GetDrugs",
                    cache: false,
                    data: { classId: classId, pageIndex: pageIndex, pageSize: pageSize },
                    dataType: 'json',
                    success: function(d) {
                        drugs([]);
                        $.each(d.Drugs, function(i, data) {
                            drugs.push(ko.mapping.fromJS(data));
                        });
                        drugsTotal(d.GroupTotal);
                        //ko.applyBindings(med.vm);
                    },
                    error: function(e) {
                        toastr.error(e.responseText);
                    }
                });
            }
        },
        deleteCategory = function(catId) {
            if (catId > 0) {

                var answer = confirm("Are you sure you want to delete this Category? It will delete all associated classes and drugs");
                if (!answer) {
                    $("#drugCategory-modal").modal('hide');
                    return;
                }

                $.ajax({
                    url: "/Admin/Medication/DeleteDrugCategory",
                    cache: false,
                    data: { id: catId },
                    type: "POST",
                    dataType: 'json',
                    success: function() {
                        var data = ko.utils.arrayFirst(med.vm.categories(), function(item) {
                            return item.Id() === catId;
                        });
                        categories.remove(data);
                        $("#drugCategory-modal").modal('hide');
                    },
                    error: function(e) {
                        toastr.error(e.responseText);
                    }
                });
            }
        },
        deleteClass = function(classId) {
            if (classId > 0) {

                var answer = confirm("Are you sure you want to delete this drug? It will delete all associated drugs as well");
                if (!answer) {
                    $("#drugClass-modal").modal('hide');
                    return;
                }

                $.ajax({
                    url: "DeleteDrugClass",
                    cache: false,
                    data: { id: classId },
                    dataType: 'json',
                    success: function() {
                        var data = ko.utils.arrayFirst(med.vm.classes(), function(item) {
                            return item.Id() === classId;
                        });
                        classes.remove(data);
                        $("#drugClass-modal").modal('hide');
                    },
                    error: function(e) {
                        toastr.error(e.responseText);
                    }
                });
            }
        },
        deleteDrug = function(drugId) {
            if (drugId > 0) {
                var answer = confirm("Are you sure you want to delete this drug?");
                if (answer) {
                    $("#drug-modal").modal('hide');
                    return;
                }

                $.ajax({
                    url: "DeleteDrug",
                    cache: false,
                    data: { id: drugId },
                    dataType: 'json',
                    success: function() {
                        var data = ko.utils.arrayFirst(med.vm.drugs(), function(item) {
                            return item.Id() === drugId;
                        });
                        drugs.remove(data);
                        $("#drug-modal").modal('hide');
                    },
                    error: function(e) {
                        toastr.error(e.responseText);
                    }
                });
            }
        },
        showDrugEdit = function(drugId) {
            $("#editDrug").attr('disabled', null);
            var data = ko.utils.arrayFirst(drugs(), function(item) {
                return item.Id() == drugId;
            });
            med.vm.drug(data);
        },
        showClassEdit = function(classId) {
            $("#editClass").attr('disabled', null);
            var data = ko.utils.arrayFirst(classes(), function(item) {
                return item.Id() == classId;
            });
            med.vm.clazz(data);

        },
        showCategoryEdit = function(catId) {
            $("#editCategory").attr('disabled', null);
            var data = ko.utils.arrayFirst(categories(), function(item) {
                return item.Id() == catId;
            });
            med.vm.category(data);
        },
        categoryChanged = function(elt, event) {
            var id = elt.categoryVal() ? elt.categoryVal() : $("#catId").val();
            loadClasses(id);
            showCategoryEdit(id);
            //IMPORTANT!!!
            event.preventDefault();
            event.stopImmediatePropagation();
            event.stopPropagation();
        },
        classChanged = function(elt, event) {
            var id = elt.Id ? elt.Id() : (elt.classVal() || $("#classId").val());
            selectedClassId(id);
            loadDrugs(id, 0, 20);
            showClassEdit(id);
            //IMPORTANT!!!
            event.preventDefault();
            event.stopImmediatePropagation();
            event.stopPropagation();
        },
        drugChanged = function(elt, event) {
            var id = elt.drugVal();
            showDrugEdit(id);
            //IMPORTANT!!!
            event.preventDefault();
            event.stopImmediatePropagation();
            event.stopPropagation();
        },
        newCategory = function() {
            return {
                Name: ko.observable(),
                Code: ko.observable(),
                Directions: ko.observable(),
                Description: ko.observable(),
                SortOrder: ko.observable(),
                Status: ko.observable(),
                CreatedOn: ko.observable(),
                UpdatedOn: ko.observable(),
                CreatedBy: ko.observable(),
                UpdatedBy: ko.observable(),
                IsActive: ko.observable(),
                DrugClasses: ko.observable(),
                Id: ko.observable()
            };
        },
        newClass = function() {
            return {
                DrugCategory: ko.observable(),
                Name: ko.observable(),
                Directions: ko.observable(),
                Description: ko.observable(),
                SortOrder: ko.observable(),
                Status: ko.observable(),
                CreatedOn: ko.observable(),
                UpdatedOn: ko.observable(),
                CreatedBy: ko.observable(),
                UpdatedBy: ko.observable(),
                IsActive: ko.observable(),
                Drugs: ko.observable(),
                DrugCategor: ko.observable(),
                Id: ko.observable()
            };
        },
        newDrug = function() {
            return {
                DrugClassId: ko.observable(),
                DrugTypeId: ko.observable(),
                Name: ko.observable(),
                Directions: ko.observable(),
                Status: ko.observable(),
                Description: ko.observable(),
                SortOrder: ko.observable(),
                CreatedOn: ko.observable(),
                UpdatedOn: ko.observable(),
                CreatedBy: ko.observable(),
                UpdatedBy: ko.observable(),
                IsActive: ko.observable(),
                StudyId: ko.observable(),
                DrugClass: ko.observable(),
                SubjectDrugs: ko.observable(),
                Study: ko.observable(),
                Id: ko.observable()
            };
        },
        findDrugs = function(text, max, callback) {
            $.ajax({
                url: "/Json/FindDrugs",
                data: { text: text, max: max },
                cache: false,
                dataType: 'json',
                success: function(d) {
                    drugs([]);
                    $.each(d, function(i, data) {
                        drugs.push(ko.mapping.fromJS(data));
                    });
                    callback(drugs());
                },
                error: function(e) {
                    toastr.error(e.responseText);
                }
            });
        };

    return {
        categories: categories,
        classes: classes,
        drugs: drugs,
        category: category,
        clazz: clazz,
        drug: drug,
        loadCategories: loadCategories,
        loadClasses: loadClasses,
        loadDrugs: loadDrugs,
        deleteCategory: deleteCategory,
        deleteClass: deleteClass,
        deleteDrug: deleteDrug,
        drugsTotal: drugsTotal,
        selectedClassId: selectedClassId,
        currentPageIndex: currentPageIndex,
        categoryChanged: categoryChanged,
        categoryVal: categoryVal,
        classVal: classVal,
        drugVal: drugVal,
        classChanged: classChanged,
        drugChanged: drugChanged,
        newCategory: newCategory,
        newClass: newClass,
        newDrug: newDrug,
        findDrugs: findDrugs
    };

}();

$(function () {

    med.vm.loadCategories();
    //ko.applyBindings(med.vm);

    $("#editCategory").on('click', function () {
        $("#drugCategory-modal").modal('show');
    });

    $("#editClass").on('click', function () {
        $("#drugClass-modal").modal('show');
    });

    $("#editDrug").on('click', function () {
        $("#drug-modal").modal('show');
    });

    $("#btnDrugNav").on('click', function () {
        var index = $("#pageIndex").val();
        med.vm.currentPageIndex(index);
        med.vm.loadDrugs(med.vm.selectedClassId(), index, 20);
    });

    $("#btnDeleteCategory").on('click', function () {
        var id = med.vm.category().Id();
        med.vm.deleteCategory(id);
    });
    $("#btnDeleteClass").on('click', function () {
        var id = med.vm.clazz().Id();
        med.vm.deleteClass(id);
    });
    $("#btnDeleteDrug").on('click', function () {
        var id = med.vm.drug().Id();
        med.vm.deleteDrug(id);
    });
    
    /******* New Events *************/
    $("#modellinkCat").on('click', function () {
        med.vm.category(med.vm.newCategory());
    });

    $("#modellinkClass").on('click', function () {
        med.vm.clazz(med.vm.newClass());
    });

    $("#modellinkDrug").on('click', function () {
        med.vm.drug(med.vm.newDrug());
    });

});

function success() {
    $("#drugClass-modal").modal('hide');
    $("#drug-modal").modal('hide');
    $("#drugCategory-modal").modal('hide');
}