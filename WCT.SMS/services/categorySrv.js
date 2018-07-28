
'use strict';
angular.module('app')
.factory('categorySrv', ['$http', function ($http) {
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
            return $http.get(apiEndpoint + '/api/Category/Get');
        },
        getActiveItems: function () {
            console.log(apiEndpoint);
            return $http.get(apiEndpoint + '/api/Category/GetActive');
        },
        getItem: function (id) {
            return $http.get(apiEndpoint + '/api/Category/Get/' + id);
        },
        postItem: function (item) {
            return $http.post(apiEndpoint + '/api/Category/Post', item);
        },
        deleteItem: function (id) {
            return $http({
                method: 'DELETE',
                url: apiEndpoint + '/api/Category/Delete/' + id
            });
        }
    };
}]);
