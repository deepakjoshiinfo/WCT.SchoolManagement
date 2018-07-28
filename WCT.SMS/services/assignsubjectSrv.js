'use strict';
angular.module('app')
    .factory('assignsubjectSrv', ['$http', function ($http) {
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
                return $http.get(apiEndpoint + '/api/AssignSubject/Get');
            },
            getActiveItems: function () {
                console.log(apiEndpoint);
                return $http.get(apiEndpoint + '/api/AssignSubject/GetActive');
            },
            getItem: function (id) {
                return $http.get(apiEndpoint + '/api/AssignSubject/Get/' + id);
            },
            postItem: function (item) {
                return $http.post(apiEndpoint + '/api/AssignSubject/Post', item);
            },
            deleteItem: function (id) {
                return $http({
                    method: 'DELETE',
                    url: apiEndpoint + '/api/AssignSubject/Delete/' + id
                });
            },
            searchTeachers: function (classId, sectionId) {
                return $http.get(apiEndpoint + '/api/AssignSubject/SearchTeachers?classId=' + classId + '&sectionId=' + sectionId);
            }
        };
    }]);