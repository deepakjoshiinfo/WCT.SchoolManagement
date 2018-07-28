var app = angular.module('app');
app.directive('dateFormatter', [
    function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function postLink(scope, element, attrs, ngModel) {
                ngModel.$parsers.push(function(data) {
                    return moment(data).format('DD/MM/YYYY');
                });

                ngModel.$formatters.push(function(data) {
                    return moment(data, 'DD/MM/YYYY').toDate()
                });
            }
        };
    }
]);