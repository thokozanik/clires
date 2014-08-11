$(document).ready(function () {
    var cxSubjects = new CanvasXpress("canvSubjectsStats",
    {
        "y": {
            "vars": [
                "Total"
            ],
            "smps": sitesNames,
            "data": subjects
        }
    }, {
        "backgroundGradient1Color": "rgb(226,236,248)",
        "backgroundGradient2Color": "rgb(112,179,222)",
        "backgroundType": "gradient",
        "graphOrientation": "vertical",
        "graphType": "Bar",
        "legendBackgroundColor": false,
        "legendBox": false,
        "lineThickness": 2,
        "lineType": "spline",
        "showShadow": true,
        "smpLabelRotate": 45,
        "smpTitleFontStyle": "italic",
        "title": "Subjects: Active per site",
        "titleHeight": 30,
        "xAxisTickColor": "rgb(0,0,0)",
        "xAxis2Show": false
    });


    var cxVisits = new CanvasXpress("canvVisitStats",
    {
        "y": {
            "vars": [
              "Completed",
              "In Progress",
              "Scheduled"
            ],
            "smps": sitesNames,
            "data": visits
        }
    }, {
        "backgroundGradient1Color": "rgb(226,236,248)",
        "backgroundGradient2Color": "rgb(112,179,222)",
        "backgroundType": "gradient",
        "graphOrientation": "vertical",
        "graphType": "Bar",
        "legendBackgroundColor": false,
        "legendBox": false,
        "lineThickness": 2,
        "lineType": "spline",
        "showShadow": true,
        "smpLabelRotate": 45,
        "smpTitleFontStyle": "italic",
        "title": "Visits",
        "titleHeight": 30,
        "xAxisTickColor": "rgb(0,0,0)",
        "xAxis2Show": false
    });


    var cxForms = new CanvasXpress("canvFormsStats",
    {
        "y": {
            "vars": [
                "Completed",
                "In Progress"
            ],
            "smps": sitesNames,
            "data": forms
        }
    }, {
        "backgroundGradient1Color": "rgb(226,236,248)",
        "backgroundGradient2Color": "rgb(112,179,222)",
        "backgroundType": "gradient",
        "graphOrientation": "vertical",
        "graphType": "Bar",
        "legendBackgroundColor": false,
        "legendBox": false,
        "lineThickness": 2,
        "lineType": "spline",
        "showShadow": true,
        "smpLabelRotate": 45,
        "smpTitleFontStyle": "italic",
        "title": "Forms",
        "titleHeight": 30,
        "xAxisTickColor": "rgb(0,0,0)",
        "xAxis2Show": false
    });
});
