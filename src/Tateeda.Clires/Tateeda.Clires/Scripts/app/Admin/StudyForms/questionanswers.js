var fbqa = fbqa || {};

fbqa.vm = new function () {
    var answers = ko.observableArray([]),
        answer = ko.observable(),
        getquestionanswers = function (id) {
            $.ajax({
                url: "/Json/GetQuestionAnswers",
                data: { questionId: id },
                cache: false,
                dataType: 'json',
                success: function (d) {
                    answers([]);
                    $.each(d, function (i, data) {
                        answers.push(ko.mapping.fromJS(data));
                    });
                    //ko.applyBindings(fbqa.vm);
                }
            });
        },
        sortBy = function (field) {
            if (field) {
                answers.sort(function (a, b) {
                    try {
                        return eval('a.' + field)() < eval('b.' + field)() ? -1 : 1;
                    } catch (e) {
                        return eval('a.' + field) < eval('b.' + field) ? -1 : 1;
                    }
                });
            }
        },
        showFormSuccess = function (d) {
            if (d > 0) {
                $("#studycontainer-modal").modal('hide');
                $("#frmnewanswer").trigger('click');
                getquestionanswers(d);
            } else {
                toastr.error(d);
            }
        },
        showFormError = function (d) {
            toastr.error('error:' + d.responseText);
        },
        gridViewModel = new ko.simpleGrid.viewModel({
            data: answers,
            columns: [
                {
                    headerText: "Controls",
                    rowText: function (item) {
                        return '<button class="btn btn-mini edit" data-id=' + item.Id() + '><i class="icon-pencil"></i> Edit</button>';
                    },
                    sortColumnName: ''
                },
                { headerText: "Id", rowText: function (item) { return item.Id(); }, sortColumnName: 'Id' },
                { headerText: "Answer", rowText: function (item) { return item.OptionText(); }, sortColumnName: 'OptionText' },
                { headerText: "Score", rowText: function (item) { return item.Score(); }, sortColumnName: 'Score' },
                { headerText: "Code", rowText: function (item) { return item.Code(); }, sortColumnName: 'Code' },
                {
                    headerText: "State",
                    rowText: function (item) {
                        if (item.IsActive() && item.Status() === 1) {
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
                        return questionDetailsHtml(item);
                    },
                    sortColumnName: ''
                }
            ],
            pageSize: 10
        }),
        questionDetailsHtml = function (item) {
            var dt = eval('new ' + item.UpdatedOn().replace("/", '').replace("/", ''));
            var html =
                '<div class="container" style="width:10px; id="container-' + item.Id() + '">' +
                    '<div class="modal hide fade in" style="display: none;" id="modalrow' + item.Id() + '">' +
                     '<div>' +
                    '<div><a class="close" data-dismiss="modal" style="width: 10px; height: 10px;" aria-hidden="true">&nbsp;X&nbsp;</a><br/></div>' +
                    '<table width="940px">' +
                    '<tr><th>Directions</th><th>Header</th><th>Trailer</th><th>Sort Order</th><th>Last Changed</th></tr>' +
                    '<tr><td>' + item.Directions() + '</td><td>' + item.Header() + '</td><td>' + item.Trailer() + '</td><td>' + item.SortOrder() + '</td><td>' + dt + '</td></tr>' +
                    '</table></div></div></div>' +
                    '<button class="btn btn-mini nowrap" onclick="fbqa.vm.showrowdetails(' + item.Id() + ')" ><i class="icon-info-sign"></i> View</button>';

            return html;
        },
        showrowdetails = function (rowid) {
            $("#modalrow" + rowid).modal('show').css('width', '924px').css('left', '40%');
        },
        newAnswer = function (id) {
            return {
                Id: ko.observable(0),
                QuestionId: ko.observable(id),
                FieldDataTypeId: ko.observable(1),
                OptionText: ko.observable(),
                Code: ko.observable(),
                Score: ko.observable(),
                Directions: ko.observable(),
                Header: ko.observable(),
                Trailer: ko.observable(),
                SortOrder: ko.observable(0),
                Status: ko.observable(1),
                CreatedOn: ko.observable(),
                IsActive: ko.observable(true)
            };
        };

    return {
        answer: answer,
        answers: answers,
        newAnswer: newAnswer,        
        getquestionanswers: getquestionanswers,
        gridViewModel: gridViewModel,
        showFormSuccess: showFormSuccess,
        showFormError: showFormError,
        showrowdetails: showrowdetails,
        sortBy: sortBy
    };
}();

$(document).ready(function () {

    window.setTimeout(function () {
        fbqa.vm.getquestionanswers(parentQuestionId);        
        init();
    }, 100);

    ko.applyBindings(fbqa.vm);
});

function init() {
 
    $("body").on("click",".userstatus", function () {
        toastr.error($(this).data('id'));
    });

    $("body").on('click', ".sortableHead", function () {
        var field = $(this).attr('sortname');
        fbqa.vm.sortBy(field);
    });
    
    $("#modellink").on("click", function () {
        fbqa.vm.answer(fbqa.vm.newAnswer(parentQuestionId));
    });
    
    $("body").on("click", ".edit", function () {
        var aid = $(this).attr('data-id');
        var data = ko.utils.arrayFirst(fbqa.vm.answers(), function (item) {
            return item.Id() == aid;
        });        
        $("#studycontainer-modal").modal();
        fbqa.vm.answer(data);
    });
}
