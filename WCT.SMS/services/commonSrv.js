'use strict';
angular.module('app')
.factory('commonSrv', ['$http', function ($http) {
    $http.defaults.useXDomain = true;
    delete $http.defaults.headers.common['X-Requested-With'];
   
    return {
        downloadImage: function (url) {
            return $http.get(url, { responseType: 'arraybuffer' }).then(function (response) {
                return response;
            });
        },
    };
}]);