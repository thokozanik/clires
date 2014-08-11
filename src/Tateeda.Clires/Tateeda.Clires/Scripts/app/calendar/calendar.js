/*globals _comma_separated_list_of_variables_*/

var sch = sch || {};

sch.vm = new function () {
	var currentEventId = ko.observable(0),
	calendarDataControl = function () {
		var calendar = $('#calendar').fullCalendar({
			header: {
				left: 'prev,next today',
				center: 'title',
				right: 'month,agendaWeek,agendaDay'
			},
			droppable: true,
			selectable: true,
			selectHelper: true,
			select: function (start, end, allDay) {
				cal.vm.initAppointment(start, end);
				$(".modal").modal('show');
				calendar.fullCalendar('unselect');
			},
			editable: true,
			events: function (start, end, callback) {
				$.ajax({
					url: "/Json/LoadCalendarEvents",
					type: 'POST',
					data: { start: toAspDate(start), end: toAspDate(end) },
					cache: false,
					dataType: 'json',
					success: function (d) {
						var ev = []; //javascript event object created here
					    $.each(d, function(i, data) {
					        var sd = new Date(data.CalendarStart);
					        var ed = new Date(data.CalendarEnd);
					        ev.push({
					            title: data.Title,
					            start: sd.toString(),
					            end: ed.toString(),
					            id: data.Id,
					            SubjectId: data.SubjectId,
					            AppUserId: data.AppUserId,
					            SubjectFullName: data.SubjectFullName,
					            SubjectNickname: data.SubjectNickname,
					            AppUserFullName: data.AppUserFullName,
					            SiteId: data.SiteId,
					            VisitId: data.VisitId,
					            VisitName: data.VisitName,
					            Description: data.Description,
					            editable: true,
					            allDay: sd === ed
					        });
					    });
						callback(ev);
					},
					error: function (e) {
						toastr.error(e.responseText);
					}
				});
			},
			eventClick: function (calEvent, jsEvent, view) {
				var txt = ('Event: ' + calEvent.title +
                        '<br/>Visit: ' + calEvent.VisitName +
                        '<br/>SubjectId: ' + (calEvent.subjectId | calEvent.SubjectId) +
                        '<br/>Start: ' + calEvent.start +
                        '<br/>End: ' + calEvent.end);

				toastr.info(txt);

				cal.vm.loadAppointmentInfo(calEvent.id);
				currentEventId(calEvent.id);
				$(".modal").modal('show');
			},
			eventDragStart: function (appt) {
				//cal.vm.apptChangeStarted(appt);
			},
			eventDrop: function (appt, dayDelta, minuteDelta, allDay, revertFunc) {
				cal.vm.apptChangeEnded(appt, dayDelta, minuteDelta, allDay);
			}
		});
		return calendar;
	},
    allEvents = function () {
    	return $('#calendar').fullCalendar('clientEvents');
    },
    saveEvent = function (appt) {
    	$(calendar).fullCalendar('renderEvent', appt, true);
    },
    deleteEvent = function (id, start, end) {
    	var yes = confirm("Are you sure you want to delete this visit?");
    	if (yes) {
    		$(calendar).fullCalendar("removeEvents", function (event) {
    			return event.id == id || (start == event.start && end == event.end);
    		});
    		
    		$.ajax({
    			url: "/Calendar/DeleteAppointment",
    			data: { id: id },
    			cache: false,
    			dataType: 'json',
    			success: function (d) {
    				toastr.info("Appointment has been deleted");

    			}
    		});

    	}
    },
    updateEvent = function (e) {
    	$(calendar).fullCalendar('updateEvent', e);
    },
    onDone = function (data) {
    	try {
    		var d = ko.mapping.fromJSON(data.responseText);
    		var locStart = new Date(d.CalendarStart()).toString();
    		var locEnd = new Date(d.CalendarEnd()).toString();
    		var ev = {
    			id: d.Id(),
    			_id: d.Id(),
    			title: d.Title(),
    			subjectId: d.SubjectId(),
    			start: locStart,
    			end: locEnd,
    			allDay: locStart === locEnd
    		};
    		saveEvent(ev);
    		$(".modal").modal('hide');
    		reloadCalendar();
    	} catch (e) {
    		toastr.error(data.responseText);
    	}
    },
    reloadCalendar = function () {
    	window.location = "/Schedule/Calendar";
    };

	return {
		calendarDataControl: calendarDataControl,
		saveEvent: saveEvent,
		deleteEvent: deleteEvent,
		updateEvent: updateEvent,
		onDone: onDone,
		allEvents: allEvents,
		reloadCalendar: reloadCalendar,
		currentEventId: currentEventId
	};

}();


$(function () {
	sch.vm.calendarDataControl();
	//ko.applyBindings(sch.vm);
});