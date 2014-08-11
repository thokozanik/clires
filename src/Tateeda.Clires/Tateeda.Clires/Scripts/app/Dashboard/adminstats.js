/// <reference path="../../custom/canvasXpress/canvasXpress.min.js" />$(function () {/*var c = document.getElementById("canvAdminStats");/*var ctx = c.getContext("2d");ctx.fillStyle = "#FDCEDF";ctx.fillRect(0, 0, 300, 80);ctx.fillStyle = "green";ctx.fillRect(20, 10, 10, 70);ctx.fillStyle = "yellow";ctx.fillRect(40, 20, 10, 60);ctx.fillStyle = "green";ctx.fillRect(60, 10, 10, 70);ctx.fillText("Sample", 180, 30, 100);ctx.strokeText("Sample", 100, 30, 100);*/var target = "canvAdminStats";//var cX = new CanvasXpress(target, data, config, events);var cX = new CanvasXpress("canvAdminStats", 
{
	"y": {
		"vars":["UCSD","Site-1","Site-2","Site-3","Site-4","Site-5"],		"smps": ["S0","S2","S4","S6","S8","S10","S12","S14"],		"desc": ["Subjects Per Site"],		"data": [
			[10,12,3,4,100,73,42,64],			[12,4,60,5,24,14,32,13],			[7,12,20,13,49,52,42,92],			[21,10,30,8,65,166,47,58],			[15,14,100,5,34,30,82,51],			[100,82,73,4,3,4,5,2]
		]
	}
}, 
{
	"graphType": "Bar",
	"useFlashIE": true,
	"is3DPlot": true,
	"scatterType": "bar",
	"x3DRatio": 0.5,
	"bar3DInverseWeight": 1.2
});