/// <reference path="../../knockout-2.2.1.debug.js" />
var cal = cal || {};
cal.vm = function () {
	var steps = ko.observableArray([]),
	    mappedVisits = ko.observableArray([]),
	    visit = ko.observable(),
		contact = ko.observable({
			email: '',
			phone: ''
		}),
	    disabled = ko.observable(null),
	    isChanged = ko.observable(false),
	    canScheduleGroup = ko.observable(false),
	    appointment = ko.observable(),
	    subjAppts = ko.observableArray([]),
	    initAppointment = function (start, end) {
	    	appointment(null);
	    	disabled(null);
	    	$.ajax({
	    		url: "/Calendar/GetEmptyAppointment",
	    		cache: false,
	    		dataType: 'json',
	    		success: function (d) {
	    			appointment(ko.mapping.fromJS(d));
	    			if (start && end) {
	    				setCalenderDates(start, end);
	    			} else {
	    				setCalenderDates(d.CalendarStartDate, d.CalendarEndDate);
	    			}
	    		}
	    	});
	    },
	    setDelete = function () {
	    	var calEvents = $(".fc-event-title");
	    	$.each(calEvents, function (i, val) {
	    		$(val).append('<i class="icon-remove delete-Calendar-event"></i>');
	    	});

	    	$("body").on("click", ".icon-remove.delete-Calendar-event", function (event) {
	    		$(".modal").modal('hide');
	    		event.stopPropagation();
	    		event.preventDefault();
	    		event.stopImmediatePropagation();

	    		var curEventId = sch.vm.currentEventId();
	    		sch.vm.deleteEvent(curEventId);
	    	});
	    },
	    getSteps = function (armId) {
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
	    					steps.push(ko.mapping.fromJS(data));
	    				});
	    			},
	    			error: function (e) {
	    				toastr.error(e.responseText);
	    			}
	    		});
	    	}
	    },
	    loadStepVisits = function (stepId) {
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
	    					//if not scheduled or can be repeated					    	
	    					var sameVisit = ko.utils.arrayFirst(subjAppts(), function (item) {
	    						return data.VisitId === item.VisitId();
	    					});

	    					if (!sameVisit || (sameVisit.VisitId() !== data.VisitId && sameVisit.CanRepeata())) {
	    						mappedVisits.push(data);
	    					}
	    				});

	    				cal.vm.canScheduleGroup(d.length > 2);
	    			},
	    			error: function (e) {
	    				toastr.error(e.responseText);
	    			}
	    		});
	    	}
	    },
	    setCalenderDates = function (start, end) {
	    	start = new Date(start);
	    	end = new Date(end);

	    	var sd = start.getDate(),
		        sm = start.getMonth() + 1,
		        sy = start.getFullYear(),
		        sh = start.getHours(),
		        smin = start.getMinutes(),
		        ed = end.getDate(),
		        em = end.getMonth() + 1,
		        ey = end.getFullYear(),
		        eh = end.getHours(),
		        emin = end.getMinutes();

	    	appointment().StartDate(sm + '/' + sd + '/' + sy);
	    	appointment().EndDate(em + '/' + ed + '/' + ey);

	    	if (sh > 0) {
	    		var sm0 = smin.toString().length === 2 ? smin : '0' + smin;
	    		var em0 = emin.toString().length === 2 ? emin : '0' + emin;
	    		appointment().CalendarStartTime(sh + ':' + sm0);
	    		appointment().CalendarEndTime(eh + ':' + em0);
	    	}

	    	//ko.applyBindings(cal.vm);
	    },
	    apptChangeStarted = function (appt) {

	    },
	    apptChangeEnded = function (appt, dayDelta, minuteDelta, allDay) {
	    	$.ajax({
	    		url: "/Schedule/Calendar/MoveAppointment",
	    		cache: false,
	    		data: { start: toAspDate(appt.start), end: toAspDate(appt.end), appointmentId: appt.id, subjectId: appt.SubjectId, visitId: appt.VisitId },
	    		type: "POST",
	    		dataType: 'json',
	    		success: function (e) {
	    			if (e) {
	    				toastr.info("Appointment moved and saved");
	    			} else {
	    				appt.start.setDate(appt.start.getDate() + (dayDelta * -1));
	    				appt.start.setMinutes(appt.start.getMinutes() + (minuteDelta * -1));

	    				appt.end.setDate(appt.end.getDate() + (dayDelta * -1));
	    				appt.end.setMinutes(appt.end.getMinutes() + (minuteDelta * -1));
	    				toastr.error('Appointment can\'t be moved');
	    				sch.vm.updateEvent(appt);
	    			}
	    		},
	    		error: function (e) {
	    			toastr.error("Error. Appointment can\'t be moved.");
	    		}
	    	});
	    },
	    saveAppointment = function (appt) {
	    	toastr.info('Appointment Saved');
	    },
	    loadAppointmentInfo = function (id) {
	    	if (id > 0) {
	    		$.ajax({
	    			url: "/Schedule/Calendar/GetAppointementInfo",
	    			cache: false,
	    			data: { id: id },
	    			type: "POST",
	    			dataType: 'json',
	    			success: function (d) {
	    				appointment(ko.mapping.fromJS(d));
	    				setCalenderDates(d.CalendarStart, d.CalendarEnd);
	    				disabled('disabled');
	    				cal.vm.getSubjectContactInfo(d.SubjectId);
	    			}
	    		});
	    	}
	    },
	    getSubjectScheduledVisits = function (sid) {
	    	if (sid > 0) {
	    		subjAppts([]);
	    		mappedVisits([]);
	    		$.ajax({
	    			url: "/Schedule/Calendar/GetSubjectAppointements",
	    			cache: false,
	    			data: { subjectId: sid },
	    			type: "POST",
	    			dataType: 'json',
	    			success: function (d) {
	    				$.each(d, function (i, data) {
	    					subjAppts.push(ko.mapping.fromJS(data));
	    				});
	    			},
	    			error: function (e) {
	    				alert(e);
	    			}
	    		});
	    	}
	    },
		getSubjectContactInfo = function (sid) {
			if (sid > 0) {
				$.ajax({
					url: "/Json/GetSubjectInfo",
					data: { subjectId: sid },
					dataType: 'json',
					success: function (d) {
						//var con = ko.mapping.fromJS(d);
						contact({ email: d.Contact.Emails[0].Address, phone: d.Contact.Phones[0].Telephone });
					}
				});
			}
		};

	ko.bindingHandlers.visitStepChanged = {
		init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
			$(element).on("change", function (e) {
				var chosenValue = $(element).val();
				loadStepVisits(chosenValue);
				e.preventDefault();
			});
		},
		update: function () {
			//isChanged(false);
		}
	};

	return {
		steps: steps,
		mappedVisits: mappedVisits,
		visit: visit,
		appointment: appointment,
		disabled: disabled,
		getSteps: getSteps,
		setCalenderDates: setCalenderDates,
		saveAppointment: saveAppointment,
		apptChangeStarted: apptChangeStarted,
		apptChangeEnded: apptChangeEnded,
		canScheduleGroup: canScheduleGroup,
		loadAppointmentInfo: loadAppointmentInfo,
		initAppointment: initAppointment,
		setDelete: setDelete,
		getSubjectScheduledVisits: getSubjectScheduledVisits,
		getSubjectContactInfo: getSubjectContactInfo,
		subjAppts: subjAppts,
		contact: contact
	};
}();

$(function () {
	cal.vm.initAppointment();
	ko.applyBindings(cal.vm);
    
	$('body').on('change', "#ArmId", function (item) {
		var id = $(this).val();
		cal.vm.getSteps(id);
	});
	$('body').on("click", "#scheduleAll", function (e) {
		if ($(this).is(':checked')) {
			$("#VisitId").val('99999');
			$("#VisitId").removeClass('required').attr('required', null);
		} else {
			$("#VisitId").val('');
			$("#VisitId").addClass('required').attr('required', 'required');
		}
	});
	$('body').on('change', "#StartDate", function () {
		$("#EndDate").val($("#StartDate").val());
	});

	$('body').on('click', "#SubjectId", function () {
		var subjectId = $(this).val();
		cal.vm.getSubjectScheduledVisits(subjectId);
		cal.vm.getSubjectContactInfo(subjectId);
	});

	window.setTimeout(function() { cal.vm.setDelete() }, 3000);
	
});
