
'use strict';
angular.module('app')
.factory('sectionSrv', ['$http', function ($http) {

    //$http.get('/serviceConfig.json').then(function (response) {
    //    apiEndpoint = response.data.service.url;
    //    console.log(apiEndpoint);
    //});
    $http.defaults.useXDomain = true;
    delete $http.defaults.headers.common['X-Requested-With'];
    var apiEndpoint = $("#apiEndpoint").text();
    return {
        getItems: function () {
            return $http.get(apiEndpoint + '/api/Section/Get');
        },
        getActiveItems: function () {
            return $http.get(apiEndpoint + '/api/Section/GetActive');
        },
        getItem: function (id) {
            return $http.get(apiEndpoint + '/api/Section/Get/' + id);
        },
        postItem: function (item) {
            return $http.post(apiEndpoint + '/api/Section/Post', item);
        },
        deleteItem: function (id) {
            return $http({
                method: 'DELETE',
                url: apiEndpoint + '/api/Section/Delete/' + id
            });
        }
    };
}]);