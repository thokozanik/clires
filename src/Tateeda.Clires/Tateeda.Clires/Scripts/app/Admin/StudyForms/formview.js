/// <reference path="../../../lib/$-1.8.0.js" />
/// <reference path="../../knockout-2.1.0.debug.js" />
/// <reference path="../../knockout.simplegrid.1.3.js" />
/// <reference path="../../knockout.mapping-latest.js" />
/// <reference path="../../../lib/koExternalTemplateEngine.js" />
/// <reference path="../../../lib/$.validate-vsdoc.js" />

var fv = fv || {}; //fv - form view
fv.vm = new function() {
    var form = ko.observable(),
        formCompleted = ko.observable(false),
        formLoad = function(id) {
            if (id > 0) {
                $.ajax({
                    url: "/Json/GetForm",
                    data: { id: id },
                    cache: false,
                    dataType: 'json',
                    success: function(d) {
                        form(ko.mapping.fromJS(d));
                        //ko.applyBindings(fv.vm);
                    }
                });
            }
        },
        apptFormLoad = function(id) {
            if (id > 0) {
                $.ajax({
                    url: "/Json/GetAppointmentForm",
                    data: { id: id },
                    cache: false,
                    dataType: 'json',
                    success: function(d) {
                        form(ko.mapping.fromJS(d));
                        var isCompleted = form().ApptFormStatus() === 1;
                        formCompleted(isCompleted);

                        //ko.applyBindings(fv.vm);

                        if (isCompleted) {
                            $(":input").prop('disabled', true);
                        }
                    }
                });
            }
        },
        fieldrule = { qId: 0, rule: '' },
        rules = ko.observableArray([]),
        addFieldRule = function(id, r) {
            if (r) {
                fieldrule.qId = id;
                fieldrule.rule = r;
                rules.push(fieldrule);                
            }
        };

    return {
        form: form,
        formCompleted: formCompleted,
        formLoad: formLoad,
        apptFormLoad: apptFormLoad,
        rules: rules,
        addFieldRule: addFieldRule
    };
}();


function loadform(id) {
    fv.vm.formLoad(id);
}

function loadAppointmentForm(id) {
    fv.vm.apptFormLoad(id);
}

function getTemplateName(data) {
    var name = 'answer';

    switch (data) {
        case "text-medium":
        case "text-small":
        case "text-long":
        case "text-short":
        case "text":
            name = 'texttempl';
            break;
        case "num":
        case "number":
            name = 'numericanswer';
            break;
        case "date":
            name = 'datetempl';
            break;
        default:
            name = 'answer';
    }

    return name;
}

function SelectedOptionItem(item) {
    for (var i = 0; i < item.length; i++) {
        if (item[i].Selected() === true) {
            return item[i].SelectedId;
        }
    }
    return '';
}

function addAnswerBinding(answerBindId, showQuestionIds, answerId) {
    
    $('body').on('change', "#answerQuestionId_" + answerBindId, (function (event) {
        event.preventDefault();
        var canRender = $("#optTextId_" + $(this).val()).attr('data-canrender') && $("#optTextId_" + $(this).val()).attr('data-canrender-answerId') == answerId;
        if (canRender) {
            $.each(showQuestionIds, function(i, d) {
                $("#divQuestionId_" + d).show();
            });
        } else {
            $.each(showQuestionIds, function(i, d) {
                $("#divQuestionId_" + d + " :input").val('');
                $("#divQuestionId_" + d).hide();
            });
        }
    }));
}

function addAnswerBindingCanRender(id, can, answerId) {
    $("#optTextId_" + id).attr('data-canrender', can);
    $("#optTextId_" + id).attr('data-canrender-answerId', answerId);
}

$(function () {
    ko.applyBindings(fv.vm);
    $(":submit").on('click', function (e) {
        e.preventDefault();
        if (validateForm()) {
            document.forms[0].submit();
        }
    });
});

