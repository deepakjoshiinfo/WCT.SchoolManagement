
'use strict';
angular.module('app')
    .factory('classtimetableSrv', ['$http', function ($http) {
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
                return $http.get(apiEndpoint + '/api/ClassTimetable/Get');
            },
            getActiveItems: function () {
                console.log(apiEndpoint);
                return $http.get(apiEndpoint + '/api/ClassTimetable/GetActive');
            },
            getItem: function (id) {
                return $http.get(apiEndpoint + '/api/ClassTimetable/Get/' + id);
            },
            postItem: function (item) {
                return $http.post(apiEndpoint + '/api/ClassTimetable/Post', item);
            },
            deleteItem: function (id) {
                return $http({
                    method: 'DELETE',
                    url: apiEndpoint + '/api/ClassTimetable/Delete/' + id
                });
            },
            getDays: function () {
                console.log(apiEndpoint);
                return $http.get(apiEndpoint + '/api/ClassTimetable/GetDays');
            },
            getTimetable: function (classId, sectionId, subjectId) {
                console.log(apiEndpoint);
                return $http.get(apiEndpoint + '/api/ClassTimetable/GetTimetable?classId=' + classId + '&sectionId=' + sectionId + '&subjectId=' + subjectId);
            },
            getTimetableDetails: function (classId, sectionId, subjectId) {
                console.log(apiEndpoint);
                return $http.get(apiEndpoint + '/api/ClassTimetable/GetTimetableDetails?classId=' + classId + '&sectionId=' + sectionId + '&subjectId=' + subjectId);
            },
        };
    }]);
