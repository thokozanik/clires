var study = study || {};
study.vm = function () {
	var isChanged = ko.observable(false),
		defaultStudyId = 0,
		studies = ko.observableArray([]),
		arms = ko.observableArray([]),
		visits = ko.observableArray([]),
		arm = ko.observable(),
		visit = ko.observable(),
		steps = ko.observableArray([]),
		step = ko.observable(),
		mappedVisits = ko.observableArray([]),
		mappedVisit = ko.observable({ Id: 0, VisitName: '', DaysFromBase: 0, Deviation: 0, SortOrder: 0, IsTermination: false }),
		newMappedVisit = ko.observable({ Id: 0, VisitName: '', DaysFromBase: 0, Deviation: 0, SortOrder: 0, IsTermination: false }),
		loadStudies = function () {
			$.ajax({
				url: "/Json/GetStudies",
				//data: { id: id },
				cache: false,
				dataType: 'json',
				success: function (d) {
					studies([]);
					$.each(d, function (i, data) {
						studies.push(data);
					});
					//ko.applyBindings(study.vm);
				},
				error: function (e) {
					toastr.error(e.responseText);
				}
			});
		},
		loaddefaultStudy = function () {
			loadArms(study.vm.defaultStudyId);
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
						//ko.applyBindings(study.vm);
					},
					error: function (e) {
						toastr.error(e.responseText);
					}
				});
			}
		},
		loadVisits = function (armId) {
			if (armId > 0) {
				$.ajax({
					url: "/Json/GetVisits",
					type: 'POST',
					data: { id: armId },
					cache: false,
					dataType: 'json',
					success: function (d) {
						visits([]);
						$.each(d, function (i, data) {
							visits.push(data);
						});
						//ko.applyBindings(study.vm);
					},
					error: function (e) {
						toastr.error(e.responseText);
					}
				});
			}
		},
		loadSteps = function (armId) {
			if (armId > 0) {
				$.ajax({
					url: "/Json/GetArmSteps",
					type: 'POST',
					data: { armId: armId },
					cache: false,
					dataType: 'json',
					success: function (d) {
						steps([]);
						$.each(d, function (i, data) {
							steps.push(data);
						});
						//ko.applyBindings(study.vm);
						$("#stepName").val('');
						$("#stepDescription").val('');
					},
					error: function (e) {
						toastr.error(e.responseText);
					}
				});
			}
		},
		loadMappedSteps = function (stepId) {
			if (stepId > 0) {
				$.ajax({
					url: "/Json/GetStepVisits",
					type: 'POST',
					data: { stepId: stepId },
					cache: false,
					dataType: 'json',
					success: function (d) {
						mappedVisits([]);
						$.each(d, function (i, data) {
							mappedVisits.push(data);
						});
						//ko.applyBindings(study.vm);
					},
					error: function (e) {
						toastr.error(e.responseText);
					}
				});
			}
		},
		addNewMappedVisit = function (id, text) {
			newMappedVisit({ Id: id, VisitName: text, DaysFromBase: 0, Deviation: 7, SortOrder: 0, IsTermination: false });
			$("#mapSteps").attr('disabled', null);
			isChanged(false);
		},
		saveStepVisits = function () {
			var stepId = step(),
				visitId = newMappedVisit().Id,
				deviation = newMappedVisit().Deviation,
				daysFromBase = newMappedVisit().DaysFromBase,
				sortOrder = newMappedVisit().SortOrder,
				isTermination = newMappedVisit().IsTermination;

			$.ajax({
				url: "AddStepVisits",
				type: 'POST',
				data: {
					stepId: stepId,
					visitId: visitId,
					deviation: deviation,
					daysFromBase: daysFromBase,
					sortOrder: sortOrder,
					isTermination: isTermination
				},
				cache: false,
				traditional: true,
				dataType: 'json',
				success: function (d) {
					loadMappedSteps(d);
				},
				error: function (e) {
					toastr.error(e.responseText);
				}
			});
		},
		unmapVisit = function () {
			var stepId = step(),
				visitId = mappedVisit().VisitId;
			$.ajax({
				url: "DeleteStepVisits",
				type: 'POST',
				data: {
					stepId: stepId,
					visitId: visitId
				},
				cache: false,
				traditional: true,
				dataType: 'json',
				success: function (d) {
					loadMappedSteps(d);
				},
				error: function (e) {
					toastr.error(e.responseText);
				}
			});

		},
		updateMappedVisit = function () {
			var stepId = step(),
				visitId = mappedVisit().VisitId,
				deviation = mappedVisit().Deviation,
				daysFromBase = mappedVisit().DaysFromBase,
				sortOrder = mappedVisit().SortOrder,
				isTermination = mappedVisit().IsTermination;
			$.ajax({
				url: "UpdateStepVisits",
				type: 'POST',
				data: {
					stepId: stepId,
					visitId: visitId,
					deviation: deviation,
					daysFromBase: daysFromBase,
					sortOrder: sortOrder,
					isTermination: isTermination
				},
				cache: false,
				traditional: true,
				dataType: 'json',
				success: function (d) {
					loadMappedSteps(d);
				},
				error: function (e) {
					toastr.error(e.responseText);
				}
			});
		},
		sortBy = function (field) {
			if (field) {
				users.sort(function (a, b) {
					try {
						return eval('a.' + field)() < eval('b.' + field)() ? -1 : 1;
					} catch (e) {
						return eval('a.' + field) < eval('b.' + field) ? -1 : 1;
					}
				});
			}
		},
		gridViewModel = new ko.simpleGrid.viewModel({
			data: mappedVisits,
			columns: [
				{
					headerText: "Control",
					rowText: function (item) {
						return '<button class="btn btn-mini edit" data-id=' + item.VisitId + '><i class="icon-pencil"></i> Edit</button>';
					},
					sortColumnName: ''
				},
				{
					headerText: "Visit Name",
					rowText: function (item) {
						return item.VisitName;
					},
					sortColumnName: 'VisitName'
				},
				{
					headerText: "Deviation",
					rowText: function (item) {
						return item.Deviation;
					},
					sortColumnName: 'Deviation'
				},
				{
					headerText: "Order",
					rowText: function (item) {
						return item.SortOrder;
					},
					sortColumnName: 'SortOrder'
				},
				{
					headerText: "Days from Base",
					rowText: function (item) {
						return item.DaysFromBase;
					},
					sortColumnName: 'DaysFromBase'
				},
				{
					headerText: "Can Terminate",
					rowText: function (item) {
						return item.IsTermination ? "Yes" : "No";
					},
					sortColumnName: 'IsTermination'
				}
			],
			pageSize: 10
		});

	ko.bindingHandlers.stepChanged = {
		init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
			$(element).on("change", function (e) {
				if (!isChanged()) {
					var chosenValue = $(element).val();
					$("#mappedStepsBlock").show();
					loadMappedSteps(chosenValue);
					e.preventDefault();
					isChanged(true);
				}
			});
		},
		update: function () {
			isChanged(false);
		}
	};

	ko.bindingHandlers.visitChanged = {
		init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
			$(element).on("change", function (e) {
				if (!isChanged()) {
					var chosenValue = $(element).val();
					var chosenText = element[element.selectedIndex].text;
					addNewMappedVisit(chosenValue, chosenText);
					e.stopPropagation();
					e.preventDefault();
					isChanged(true);
				}
			});
		},
		update: function () {
			isChanged(false);
		}
	};

	return {
		studies: studies,
		step: step,
		steps: steps,
		arms: arms,
		arm: arm,
		visit: visit,
		visits: visits,
		mappedVisit: mappedVisit,
		mappedVisits: mappedVisits,
		newMappedVisit: newMappedVisit,
		loadStudies: loadStudies,
		loadArms: loadArms,
		loadVisits: loadVisits,
		loadSteps: loadSteps,
		saveStepVisits: saveStepVisits,
		gridViewModel: gridViewModel,
		sortBy: sortBy,
		unmapVisit: unmapVisit,
		updateMappedVisit: updateMappedVisit,
		defaultStudyId: defaultStudyId,
		loaddefaultStudy: loaddefaultStudy
		
	};
}();

$(function () {
	study.vm.loadStudies();
	$("#studyDetailsBlock").hide();
	$("#visitsBlock").hide();
	$("#armBlock").hide();
	$("#mappedStepsBlock").hide();
    
	ko.applyBindings(study.vm);

	$("body").on('click', "#unmapVisit", function () {
		study.vm.unmapVisit();
		$("#modal").hide();
	});

	$('body').on('click', "#updateVisit", function () {
		study.vm.updateMappedVisit();
		$("#modal").hide();
	});

	$("body").on('click', "#mapSteps", function () {
		study.vm.saveStepVisits();
	});

	$('body').on('change', "#StudyId", function () {
		var id = $(this).val();
		study.vm.loadArms(id);
		if (id > 0) {
			$("#studyDetailsBlock").show();
		} else {
			$("#visitsBlock").hide();
			$("#armBlock").hide();
		}
		$("#mappedStepsBlock").hide();
	});

	$('body').on('change', "#ArmId", function () {
		var id = $(this).val();
		if (id > 0) {
			study.vm.loadSteps(id);
			study.vm.loadVisits(id);
			$("#visitsBlock").show();
			$("#armBlock").show();
		} else {
			$("#visitsBlock").hide();
			$("#armBlock").hide();
		}

		$("#mappedStepsBlock").hide();
	});

	$("body").on("click", ".edit", function () {
		var uid = $(this).attr('data-id');
		var data = ko.utils.arrayFirst(study.vm.mappedVisits(), function (item) {
			return item.VisitId == uid;
		});
		$("#modal").modal('show');

		study.vm.mappedVisit(data);
		//ko.applyBindings(study.vm);
	});
});

function loadSteps() {
	var armId = $("#ArmId").val();
	study.vm.loadSteps(armId);
}