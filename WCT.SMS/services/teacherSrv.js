
'use strict';
angular.module('app')
.factory('teacherSrv', ['$http', function ($http) {

    //$http.get('/serviceConfig.json').then(function (response) {
    //    apiEndpoint = response.data.service.url;
    //    console.log(apiEndpoint);
    //});
    $http.defaults.useXDomain = true;
    delete $http.defaults.headers.common['X-Requested-With'];
    var apiEndpoint = $("#apiEndpoint").text();
    return {
        getItems: function () {
            console.log(apiEndpoint);
            return $http.get(apiEndpoint + '/api/Teacher/Get');
        },
        getActiveItems: function () {
            console.log(apiEndpoint);
            return $http.get(apiEndpoint + '/api/Teacher/GetActive');
        },
        getItem: function (id) {
            return $http.get(apiEndpoint + '/api/Teacher/Get/' + id);
        },
        postItem: function (item) {
            return $http.post(apiEndpoint + '/api/Teacher/Post', item);
        },
        deleteItem: function (id) {
            return $http({
                method: 'DELETE',
                url: apiEndpoint + '/api/Teacher/Delete/' + id
            });
        }
    };
}]);