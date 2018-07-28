/// <reference path="angular.min.js" />


var schoolModule = angular.module('schoolModule', ['moment-picker']).config(['momentPickerProvider', function (momentPickerProvider) {
    momentPickerProvider.options({
        /* Picker properties */
        locale: 'en',
        format: 'L LTS',
        minView: 'decade',
        maxView: 'minute',
        startView: 'year',
        autoclose: true,
        today: false,
        keyboard: false,

        /* Extra: Views properties */
        leftArrow: '&larr;',
        rightArrow: '&rarr;',
        yearsFormat: 'YYYY',
        monthsFormat: 'MMM',
        daysFormat: 'D',
        hoursFormat: 'HH:[00]',
        minutesFormat: moment.localeData().longDateFormat('LT').replace(/[aA]/, ''),
        secondsFormat: 'ss',
        minutesStep: 5,
        secondsStep: 1
    });
}]);

schoolModule.controller("HeaderCtrl", function ($scope) {
    $scope.header = { name: "header.html", url: "header.html" };
});
