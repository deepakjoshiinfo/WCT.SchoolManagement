
'use strict';
angular.module('app')
.factory('genderSrv', ['$http', function ($http) {

    //$http.get('/serviceConfig.json').then(function (response) {
    //    apiEndpoint = response.data.service.url;
    //    console.log(apiEndpoint);
    //});
    $http.defaults.useXDomain = true;
    delete $http.defaults.headers.common['X-Requested-With'];
    var apiEndpoint = $("#apiEndpoint").text();
    return {
        getItems: function () {
            return $http.get(apiEndpoint + '/api/Gender/Get');
        },
        getActiveItems: function () {
            return $http.get(apiEndpoint + '/api/Gender/GetActive');
        },
        getItem: function (id) {
            return $http.get(apiEndpoint + '/api/Gender/Get/' + id);
        },
        postItem: function (item) {
            return $http.post(apiEndpoint + '/api/Gender/Post', item);
        },
        deleteItem: function (id) {
            return $http({
                method: 'DELETE',
                url: apiEndpoint + '/api/Gender/Delete/' + id
            });
        }
    };
}]);