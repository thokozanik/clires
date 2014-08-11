var sidebarShift = 300;
var fv = fv || {};

$(function () {
    //if (!Modernizr.inputtypes.date) {
    //    jQuery('input[type=date]').datepicker({
    //        dateFormat: 'yy-mm-dd'
    //    });
    //}
    
    $('body').on('load focus', ".date", function (e) {
        if (!Modernizr.inputtypes.date) {
            $(this).datepicker({
                changeMonth: true,
                changeYear: true,
                showOtherMonths: true,
                selectOtherMonths: true,
                //yearRange: "-60:+15"
            });
        }
    });
	$('body').on('load focus', ".time", function (e) {
		$(this).timepicker({});
	});
    
	$('input').on('keyup change', ".no-dash",  function (e) {
		$(this).val($(this).val().replace(/[)(*,-/'/ ]/g, ""));
	});

	$('input').on('keyup change', ".number-only", function (e) {
		$(this).val($(this).val().replace(/\D/g, ''));
	});

	/***************** Help SideBar ********************/

	var expended = getCookie('stopSliding');
	$("#sidebar").hide();
	
	$("#sidebar").on("click", function () {
		expended = true;
		moveRight(this, sidebarShift);
	});
	$("#sidebar").on("mouseleave", function () {
		if (expended) {
			moveLeft(this, sidebarShift);
			expended = false;
		}
	});
	//Init site bar
	window.setTimeout(function () {
		if (expended==='false')
			initSiteBar(sidebarShift);
		else {
			initSiteBar('0');
		}
	}, 1000);

	$("#stopSitebar").on('click', function () {
		var days = 30;
		setCookie('stopSliding', true, days);
	});
	$("#startSitebar").on('click', function() {
		var days = 30;
		setCookie('stopSliding', false, days);
	});

	/***************** END Help SideBar ********************/
});

$(".loadingIndicator").hide();

$(".loadingIndicator").ajaxStart(function () {
	$(this).fadeIn();
}).ajaxComplete(function () {
	$(this).fadeOut();
});

function toAspDate(d) {
    if (d) {
        var curr_date = d.getDate();
        var curr_month = d.getMonth() + 1; //Months are zero based
        var curr_year = d.getFullYear();
        var curr_hour = d.getHours();
        var curr_min = d.getMinutes();
        var dt = curr_month + "/" + curr_date + "/" + curr_year + ' ' + curr_hour + ':' + curr_min + ':00';
        return dt;
    }
}

function OnComplete() {
	$(".modal").modal('hide');
}

function OnCompleteWithMsg(msg) {
	toastr.error(msg);
}

function closeModal(id) {
    $("#" + id).modal('hide');
}

function OnCompleteWithCallback(callback) {
	try {
		var call = eval(callback.responseText);
		eval(call);
	}catch (e) {
		toastr.error(e.responseText);
	}
	OnComplete();
}

function OnFailure(e) {
	toastr.error(e.responseText);
}

function validateForm() {
	var settings = $("form").validate({
		rules: {
			number: { number: true },
			date: { date: true, required: true }
		}
	}).settings;

	
    
	settings.highlight = function (element, errorClass, validClass) {
	    var $questiongDiv = $(element).closest("div.question");
	    $questiongDiv.addClass(errorClass).removeClass(validClass).css('color', 'red');
	    $questiongDiv.focus();
	    $('html, body').animate({
	        scrollTop: $questiongDiv.offset().top
	    }, 500);
	};
	settings.unhighlight = function (element, errorClass, validClass) {
	    var $questiongDiv = $(element).closest("div.question");
	    $questiongDiv.removeClass('error').addClass(validClass).css('color', 'black');
	};

    if (validateCustomFields()) {
        return $("form").validate().form();
    }

    return false;
}

function validateCustomFields() {
    var extraRules = fv.vm.rules();
    if (extraRules) {
        for (var i = 0; i < extraRules.length; i++) {
            var field = $("#" + extraRules[i].qId),
                val = field.val(),
                f = new Function("field", extraRules[i].rule),
                result = f(val);
            if (!result) {
                field.css('background', 'pink');
                alert('Filed Validation Error\n' + (extraRules[i].rule).replace('return', ' '));
                field.focus();
                return false;
            }
            field.css('background', 'inherit');
        }
    }
    return true;
}

function showMessage(tag, txt, milsec) {
	$("#" + tag).html(txt);
	var time = Number(milsec);
	var t = setTimeout(function () { $("#" + tag).html(''); }, time);
}

/***************** sidebar HELP ****************************/
function initSiteBar(num) {
	var bar = $("#sidebar");	    
	moveRight(bar, num);
	window.setTimeout(function () {
		moveLeft(bar, num);
	}, 500);
	bar.show();
}

function moveRight(obj, num) {
	$(obj).animate({
		"left": num + "px",
		'opacity': '0.90',
	}, 1000);
}

function moveLeft(obj, num) {
	$(obj).animate({
		"left": "-=" + num + "px",
		'opacity': '1',
	}, "fast");
}

function getCookie(name) { //get cookie value
	var re = new RegExp(name + "=[^;]+", "i"); //construct RE to search for target name/value pair
	if (document.cookie.match(re)) //if cookie found
		return document.cookie.match(re)[0].split("=")[1]; //return its value
	return 'false';
}

function setCookie(name, value, days) { //set cookie value
	var expireDate = new Date();
	//set "expstring" to either future or past date, to set or delete cookie, respectively
	var expstring = expireDate.setDate(expireDate.getDate() + parseInt(days));
	document.cookie = name + "=" + value + "; expires=" + expireDate.toGMTString() + "; path=/";
}