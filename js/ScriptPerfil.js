﻿$(function () {
    var day_data = [
        {
            "period": "Jan",
            "Hours worked": 80
        },
        {
            "period": "Feb",
            "Hours worked": 125
        },
        {
            "period": "Mar",
            "Hours worked": 176
        },
        {
            "period": "Apr",
            "Hours worked": 224
        },
        {
            "period": "May",
            "Hours worked": 265
        },
        {
            "period": "Jun",
            "Hours worked": 314
        },
        {
            "period": "Jul",
            "Hours worked": 347
        },
        {
            "period": "Aug",
            "Hours worked": 287
        },
        {
            "period": "Sep",
            "Hours worked": 240
        },
        {
            "period": "Oct",
            "Hours worked": 211
        }
    ];
    Morris.Bar({
        element: 'graph_bar',
        data: day_data,
        xkey: 'period',
        hideHover: 'auto',
        barColors: ['#26B99A', '#34495E', '#ACADAC', '#3498DB'],
        ykeys: ['Hours worked', 'sorned'],
        labels: ['Hours worked', 'SORN'],
        xLabelAngle: 60
    });
});

//segundo script

$(document).ready(function () {

    var cb = function (start, end, label) {
        console.log(start.toISOString(), end.toISOString(), label);
        $('#reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
        //alert("Callback has fired: [" + start.format('MMMM D, YYYY') + " to " + end.format('MMMM D, YYYY') + ", label = " + label + "]");
    }

    var optionSet1 = {
        startDate: moment().subtract(29, 'days'),
        endDate: moment(),
        minDate: '01/01/2012',
        maxDate: '12/31/2015',
        dateLimit: {
            days: 60
        },
        showDropdowns: true,
        showWeekNumbers: true,
        timePicker: false,
        timePickerIncrement: 1,
        timePicker12Hour: true,
        ranges: {
            'Hoje': [moment(), moment()],
            'Ontem': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
            'Ultimos 7 dias': [moment().subtract(6, 'days'), moment()],
            'Ultimos 30 dias': [moment().subtract(29, 'days'), moment()],
            'Esse mês: '[moment().startOf('month'), moment().endOf('month')],
            'Mês passado': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
},
    opens: 'left',
buttonClasses: ['btn btn-default'],
applyClass: 'btn-small btn-primary',
cancelClass: 'btn-small',
format: 'DD/MM/YYYY',
separator: ' to ',
locale: {
    applyLabel: 'OK',
    cancelLabel: 'Limpar',
    fromLabel: 'de',
    toLabel: 'para',
    customRangeLabel: 'Personalizar',
    daysOfWeek: ['DO', 'SE', 'TE', 'QU', 'QU', 'SE', 'SA'],
    monthNames: ['Janeiro', 'Fevereiro', 'Mar诧, 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
    firstDay: 1
}
};
$('#reportrange span').html(moment().subtract(29, 'days').format('D MMMM, YYYY') + ' - ' + moment().format('D MMMM, YYYY'));
$('#reportrange').daterangepicker(optionSet1, cb);
$('#reportrange').on('show.daterangepicker', function () {
    console.log("show event fired");
});
$('#reportrange').on('hide.daterangepicker', function () {
    console.log("hide event fired");
});
$('#reportrange').on('apply.daterangepicker', function (ev, picker) {
    console.log("apply event fired, start/end dates are " + picker.startDate.format('D MMMM, YYYY') + " to " + picker.endDate.format('D MMMM, YYYY'));
});
$('#reportrange').on('cancel.daterangepicker', function (ev, picker) {
    console.log("cancel event fired");
});
$('#options1').click(function () {
    $('#reportrange').data('daterangepicker').setOptions(optionSet1, cb);
});
$('#options2').click(function () {
    $('#reportrange').data('daterangepicker').setOptions(optionSet2, cb);
});
$('#destroy').click(function () {
    $('#reportrange').data('daterangepicker').remove();
});
});