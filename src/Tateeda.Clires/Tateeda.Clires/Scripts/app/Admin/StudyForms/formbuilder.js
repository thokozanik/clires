/// <reference path="../../../lib/knockout-2.1.0.js" />
/// <reference path="../../../lib/jquery-1.8.0.js" />
/// <reference path="../../../lib/knockout.simplegrid.1.3.js" />

var fb = fb || {};

fb.vm = new function () {
	var forms = ko.observableArray([]),
		form = ko.observable(),
		defaultStudyId = 0,
		pageIndex = 0,
		getforms = function (id) {
			$.ajax({
				url: "/Json/GetForms",
				data: { studyId: id, size: 10, page: pageIndex },
				cache: false,
				dataType: 'json',
				async: true,
				success: function (d) {
					if (pageIndex === 0)
						forms([]);

					$.each(d, function (i, data) {
						forms.push(ko.mapping.fromJS(data));
					});

					if (d.length > 0) {
						pageIndex++;
					    setTimeout(function() { getforms(id) }, 500);
					} else {
						pageIndex = 0;
					}
				}
			});
		},
		loaddefaultStudy = function () {
			getforms(fb.vm.defaultStudyId);
		},
		sortBy = function (field) {
			if (field) {
				forms.sort(function (a, b) {
					try {
						return eval('a.' + field)() < eval('b.' + field)() ? -1 : 1;
					} catch (e) {
						return eval('a.' + field) < eval('b.' + field) ? -1 : 1;
					}
				});
			}
		},
		showFormSuccess = function (d) {
			if (d[0] === "success") {
				$("#form-modal").modal('hide');
				//$("#frmnewform").trigger('click');
				pageIndex = 0;
				getforms(d[1]);
			} else {
				toastr.error(d[0]);
			}
		},
		showFormError = function (d) {
			//toastr.error('error:' + d.responseText);
			if (d.responseText.indexOf('The duplicate key') >= 0) {
				toastr.error('Error: The duplicate Form Name');
			}
		},
		gridViewModel = new ko.simpleGrid.viewModel({
			data: forms,
			columns: [
				{
					headerText: "Controls", rowText: function (item) {
						return '<button class="btn btn-mini preview" data-id=' + item.Id() + '><i class="icon-check"></i>Preview</button>' +
						'<button class="btn btn-mini editform" data-id=' + item.Id() + '><i class="icon-pencil"></i> Edit</button>';
					}, sortColumnName: ''
				},
				{ headerText: "Id", rowText: function (item) { return item.Id(); }, sortColumnName: 'Id' },
				{
					headerText: "Name",
					rowText: function (item) {
						return '<strong>' + item.Name() + '</strong>';
					},
					sortColumnName: 'Name'
				},
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
				{ headerText: "Type", rowText: function (item) { return item.FormTypeName(); }, sortColumnName: 'FormTypeName' },
				{
					headerText: '',
					rowText: function (item) {
						return '<form class="cell-form" action=/Admin/StudyForms/FormQuestions method="POST" id="frmquestion' + item.Id() + '">' +
							'<input type="hidden" name="formId" value="' + item.Id() + '" />' +
							'<button class="btn btn-mini nowrap formQuestions" data-formid=' + item.Id() + '><i class="icon-question-sign"></i> Questions </button> [' + item.QuestionCount() + ']' +
							'</form>';
					},
					sortColumnName: ''
				},
				{
					headerText: "Details",
					rowText: function (item) {
						return formDetailsHtml(item);
					},
					sortColumnName: ''
				}
			],
			pageSize: 10
		}),
		formDetailsHtml = function (item) {
			var fillBy = 'No';
			if (item.IsFilledBySubject()) { fillBy = 'Yes'; }

			var html =
				'<div class="container" style="width:10px;" id="container-' + item.Id() + '">' +
					'<div class="modal hide fade in" style="display: none;" id="modalrow' + item.Id() + '">' +
					'<div>' +
					'<div><a class="close" data-dismiss="modal" style="width: 10px; height: 10px;" aria-hidden="true">&nbsp;X&nbsp;</a><br/></div>' +
					'<table style="width:940px;">' +
					'<thead>' +
					'<tr><th>Title</th><th>Description</th><th>Header</th><th>Directions</th><th>Trailer</th><th>By Subject</th><th>Display</th><th>Study</th></tr>' +
					'</thead>' +
					'<tr><td>' + item.Title() + '</td><td>' + item.Description() + '</td><td>' + item.Header() + '</td><td>' + item.Directions() + '</td><td>' + item.Trailer() + '</td><td>' + fillBy + '</td><td>' + item.LayoutTypeName() + '</td><td>' + item.StudyName() + '</td></tr>' +
					'</table></div></div></div>' +
					'<button class="btn btn-mini nowrap" onclick="fb.vm.showrowdetails(' + item.Id() + ')" ><i class="icon-info-sign"></i> View</button>';

			return html;
		},
		showrowdetails = function (rowid) {
			$("#modalrow" + rowid).modal('show').css('width', '924px').css('left', '40%');
		},
		newForm = function () {
			return {
				Id: ko.observable(0),
				Name: ko.observable(),
				Code: ko.observable(),
				FormTypeId: ko.observable(1),
				Title: ko.observable(),
				Description: ko.observable(),
				Directions: ko.observable(),
				Header: ko.observable(),
				Trailer: ko.observable(),
				IsFilledBySubject: ko.observable(),
				ShowTotalScore: ko.observable(),
				LayoutTypeId: ko.observable(1),
				SortOrder: ko.observable(0),
				Status: ko.observable(1),
				IsActive: ko.observable(true),
				StudyId: ko.observable(fb.vm.defaultStudyId),
				NotifyOnCompletion: ko.observable(true),
				NotifyOnChange: ko.observable(false)
			};
		};
	return {
		form: form,
		forms: forms,
		newForm: newForm,
		getforms: getforms,
		gridViewModel: gridViewModel,
		showFormSuccess: showFormSuccess,
		showFormError: showFormError,
		showrowdetails: showrowdetails,
		sortBy: sortBy,
		pageIndex: pageIndex,
		defaultStudyId: defaultStudyId,
		loaddefaultStudy: loaddefaultStudy
	};
}();

$(document).ready(function () {
	window.setTimeout(function () {
		//fb.vm.getforms();
		init();
	}, 50);
	ko.applyBindings(fb.vm);
});

function init() {

	$(".loadingIndicator").hide();

	$("#StudyId").on("change", function () {
		var id = $(this).val();
		fb.vm.getforms(id);
	});

	$("#modellink").on("click", function () {
		fb.vm.form(fb.vm.newForm());
	});


	$("body").on("click", ".userstatus", function () {
		toastr.error($(this).data('id'));
	});

	$("body").on("click", ".formQuestions", function () {
		var fid = $(this).attr('data-formid');
		showQuestions(fid);
	});

	$("body").on('click', ".sortableHead", function () {
		var field = $(this).attr('sortname');
		fb.vm.sortBy(field);
	});

	$("body").on("click", ".editform", function () {
		var fid = $(this).attr('data-id');
		var data = ko.utils.arrayFirst(fb.vm.forms(), function (item) {
			return item.Id() == fid;
		});
		$("#form-modal").modal();

		fb.vm.form(data);
		//ko.applyBindings(fb.vm);
	});

	$("body").on("click", ".preview", function () {
		var fid = $(this).attr('data-id');
		window.location = '/Admin/StudyForms/previewform/' + fid;
	});
}

function showQuestions(fid) {
	$("#frmquestion" + fid).submit();
}

