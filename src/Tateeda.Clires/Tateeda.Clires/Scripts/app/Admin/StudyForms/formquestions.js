/// <reference path="../../jquery-1.8.0.js" />
/// <reference path="../../knockout-2.1.0.debug.js" />
/// <reference path="../../knockout.simplegrid.1.3.js" />
/// <reference path="../../knockout.mapping-latest.js" />
/// <reference path="~/Scripts/lib/knockout.simplegrid.1.3.js" />
var fbq = fbq || {};

fbq.vm = new function () {
    var questions = ko.observableArray([]),
        question = ko.observable(),
        getformquestions = function(id) {
            $.ajax({
                url: "/Json/GetFormQuestions",
                cache: false,
                data: { formId: id },
                dataType: 'json',
                success: function (d) {
                    questions([]);
                    $.each(d, function(i, data) {
                        questions.push(ko.mapping.fromJS(data));
                    });
                    //ko.applyBindings(fbq.vm);
                }
            });
        },
        sortBy = function (field) {
            if (field) {
                questions.sort(function (a, b) {
                    try {
                        return eval('a.' + field)() < eval('b.' + field)() ? -1 : 1;
                    } catch (e) {
                        return eval('a.' + field) < eval('b.' + field) ? -1 : 1;
                    }
                });
            }
        },
        showFormSuccess = function(d) {
            if (d > 0) {                
                $("#studycontainer-modal").modal('hide');
                $("#frmnewquestion").trigger('click');
                getformquestions(d);
            } else {                
                $("#studycontainer-modal").modal('hide');
            }
        },
        showFormError = function(d) {
            toastr.error('error:' + d.responseText);
        },
        gridViewModel = new ko.simpleGrid.viewModel({
            data: questions,
            columns: [
                {
                    headerText: "Controls",
                    rowText: function(item) {
                        return '<button class="btn btn-mini edit" data-id=' + item.Id() + '><i class="icon-pencil"></i> Edit</button>';
                    },
                    sortColumnName: ''
                },
                { headerText: "Id", rowText: function(item) { return item.Id(); }, sortColumnName: 'Id' },
                { headerText: "Question", rowText: function(item) { return item.QuestionText(); }, sortColumnName: 'QuestionText' },
                { headerText: "Code", rowText: function (item) { return item.Code(); }, sortColumnName: 'Code' },
                { headerText: "Required", rowText: function (item) {
                     if(item.IsRequired()) {
                         return '<strong class="required">Yes</strong>';
                     }
                     return 'No';
                }, sortColumnName: 'IsRequired' },
                {
                    headerText: "Parent",
                    rowText: function (item) {
                        var ret = "";
                        if (item.IsParent) ret = "<span style='color:navy'>Parent</span>";
                        if (item.ParentId) ret = "<span style='color:orange'>Child</span>";
                        return ret;
                    },
                    sortColumnName: 'IsParent'
                },
                {
                    headerText: "State",
                    rowText: function(item) {
                        if (item.IsActive() && item.Status() === 1) {
                            return '<span  class=\"span1 userstatus label label-success\" data-id=\"' + item.Id() + '\">Active</span>';
                        } else {
                            return '<span  class=\"span1 userstatus label label-important\" data-id=\"' + item.Id() + '\">Inactive</span>';
                        }
                    },
                    sortColumnName: 'IsActive'
                },
                { headerText: "Type", rowText: function(item) { return item.FieldDataTypeName(); }, sortColumnName: 'FieldDataTypeName' },
                {
                    headerText: '',
                    rowText: function(item) {
                        return '<form class="cell-form" action=/Admin/StudyForms/QuestoinAnswers method="POST" id="frmanswer' + item.Id() + '">' +
                            '<input type="hidden" name="questionId" value="' + item.Id() + '" />' +
                            '<button class=\"btn btn-mini nowrap questionAnswers\" data-formid=\"' + item.Id() + '\"><i class="icon-question-sign"></i> Answers [' + item.AnswersCount() + ']</button>' +
                            '</form>';
                    },
                    sortColumnName: ''
                },
                {
                    headerText: "Details",
                    rowText: function(item) {
                        return questionDetailsHtml(item);
                    },
                    sortColumnName: ''
                }
            ],
            pageSize: 10
        }),
        questionDetailsHtml = function(item) {
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
                    '<button class="btn btn-mini nowrap" onclick="fbq.vm.showrowdetails(' + item.Id() + ')" ><i class="icon-info-sign"></i> View</button></button>';

            return html;
        },
        showrowdetails = function(rowid) {
            $("#modalrow" + rowid).modal('show').css('width', '924px').css('left', '40%');
        },
        newQuestion = function() {
            return {
                Id: ko.observable(0),
                FormId: ko.observable(0),
                FieldDataTypeId: ko.observable(1),
                QuestionText: ko.observable(),
                Code: ko.observable(),
                Directions: ko.observable(),
                Header: ko.observable(),
                Trailer: ko.observable(),
                IsRequired: ko.observable(),
                ParentQuestionId: ko.observable(),
                Description: ko.observable(),
                SortOrder: ko.observable(0),
                Status: ko.observable(1),
                CreatedOn: ko.observable(),
                IsActive: ko.observable(true)
            };
        };

    return {
        question: question,
        questions: questions,
        newQuestion: newQuestion,
        getformquestions: getformquestions,
        gridViewModel: gridViewModel,
        showFormSuccess: showFormSuccess,
        showFormError: showFormError,
        showrowdetails: showrowdetails,
        sortBy: sortBy
    };
}();

$(document).ready(function () {
    window.setTimeout(function () {
        fbq.vm.getformquestions(parentFormId);
        init();
    }, 50);
    ko.applyBindings(fbq.vm);
});

function init() {

    $("body").on("click", ".userstatus", function() {
        toastr.error($(this).data('id'));
    });

    $("body").on("click", ".questionAnswers", function() {
        var fid = $(this).attr('data-formid');
        showAnswers(fid);
    });

    $("body").on('click', ".sortableHead", function() {
        var field = $(this).attr('sortname');
        fbq.vm.sortBy(field);
    });

    $("body").on("click", ".edit", function() {
        var qid = $(this).attr('data-id');
        var data = ko.utils.arrayFirst(fbq.vm.questions(), function(item) {
            return item.Id() == qid;
        });
        //$("#edit-modal").toggle();
        $("#studycontainer-modal").modal();
        fbq.vm.question(data);
    });

    $("#modellink").on("click", function() {
        fbq.vm.question(fbq.vm.newQuestion());
    });

    $("#validation-rule-input").hide();

    $("body").on('change', "#FieldDataTypeId", function(e) {
        $("#validation-rule-input").hide();
        $("#validation-rule-input :input").val('');
        
        var val = Number($("#FieldDataTypeId").val());
        switch (val) {
        case 3:
        case 4:
        case 5:
        case 7:
        case 8:            
            $("#validation-rule-input").show();
            break;
        }
    });
}

function showAnswers(qid) {
    $("#frmanswer" + qid).submit();
}

