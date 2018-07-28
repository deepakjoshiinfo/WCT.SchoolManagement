
'use strict';
angular.module('app')
.factory('classSrv', ['$http', function ($http) {
 
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
            return $http.get(apiEndpoint + '/api/Class/Get');
        },
        getActiveItems: function () {
            console.log(apiEndpoint);
            return $http.get(apiEndpoint + '/api/Class/GetActive');
        },
        getItem: function (id) {
            return $http.get(apiEndpoint + '/api/Class/Get/' + id);
        },
        postItem: function (item) {
            return $http.post(apiEndpoint + '/api/Class/Post', item);
        },
        deleteItem: function (id) {
            return $http({
                method: 'DELETE',
                url: apiEndpoint + '/api/Class/Delete/' + id
            });
        }
    };
}]);
