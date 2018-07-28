
'use strict';
angular.module('app')
.factory('relationSrv', ['$http', function ($http) {

    //$http.get('/serviceConfig.json').then(function (response) {
    //    apiEndpoint = response.data.service.url;
    //    console.log(apiEndpoint);
    //});
    $http.defaults.useXDomain = true;
    delete $http.defaults.headers.common['X-Requested-With'];
    var apiEndpoint = $("#apiEndpoint").text();
    return {
        getItems: function () {
            return $http.get(apiEndpoint + '/api/Relation/Get');
        },
        getActiveItems: function () {
            return $http.get(apiEndpoint + '/api/Relation/GetActive');
        },
        getItem: function (id) {
            return $http.get(apiEndpoint + '/api/Relation/Get/' + id);
        },
        postItem: function (item) {
            return $http.post(apiEndpoint + '/api/Relation/Post', item);
        },
        deleteItem: function (id) {
            return $http({
                method: 'DELETE',
                url: apiEndpoint + '/api/Relation/Delete/' + id
            });
        }
    };
}]);