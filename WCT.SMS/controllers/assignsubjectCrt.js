/// <reference path="C:\SF\TFS\College Management System\App\WCT.SMS\WCT.SMS\js/main.js" />
/// <reference path="C:\SF\TFS\College Management System\App\WCT.SMS\WCT.SMS\js/main.js" />

angular.module('app').controller("assignsubjectCrt", function ($scope, subjectSrv, teacherSrv, classSrv, assignsubjectSrv) {
    $scope.error = "";
    $scope.loadingMessage = "Loading...";
    $scope.editingInProgress = false;
    $scope.assignsubjects = [];

    $scope.editInProgresItem = {
        Id: 0,
        ClassId: 0,
        SectionId: 0,
        SubjectId: 0,
        TeacherId: 0,
        IsActive:true
    };
    $scope.editSwitch = function (item) {
        item.edit = !item.edit;
        if (item.edit) {
            $scope.editInProgresItem.Id = item.Id;
            $scope.editInProgresItem.ClassId = item.ClassId;
            $scope.editInProgresItem.SectionId = item.SectionId;
            $scope.editInProgresItem.SubjectId = item.SubjectId;
            $scope.editInProgresItem.TeacherId = item.TeacherId;
            $scope.editInProgresItem.IsActive = item.IsActive;
            $scope.editingInProgress = true;
        } else {
            $scope.addSwitch(item);
        }
    };
    $scope.addSwitch = function (item) {
        $scope.editingInProgress = false;
        $scope.editInProgresItem = {
            Id: 0,
            ClassId: 0,
            SectionId: 0,
            SubjectId: 0,
            TeacherId: 0,
            IsActive: true
        };
    };
    $scope.populate = function () {
        assignsubjectSrv.getActiveItems().then(function (results) {
            $scope.assignsubjects = results.data;
            $scope.loadingMessage = "";
        },
            function (err) {
                $scope.error = err;
                $scope.loadingMsg = "";
            });
    };
    $scope.getClasses = function () {
        classSrv.getItems().then(function (results) {
            $scope.Classes = results.data;
            $scope.loadingMessage = "";
        },
            function (err) {
                $scope.error = err;
                $scope.loadingMsg = "";
            });
    };
    $scope.getSubjects = function () {
        subjectSrv.getItems().then(function (results) {
            $scope.Subjects = results.data;
            $scope.loadingMessage = "";
        },
            function (err) {
                $scope.error = err;
                $scope.loadingMsg = "";
            });
    };
    $scope.getTeachers = function () {
        teacherSrv.getItems().then(function (results) {
            $scope.Teachers = results.data;
            $scope.loadingMessage = "";
        },
            function (err) {
                $scope.error = err;
                $scope.loadingMsg = "";
            });
    };
    $scope.getSections = function (Id) {
        classSrv.getItem(Id).then(function (results) {
            $scope.Sections = results.data.Sections;
            $scope.loadingMessage = "";
        },
            function (err) {
                $scope.error = err;
                $scope.loadingMsg = "";
            });
    };
    
    $scope.addlist = function () {
        $scope.assignsubjects.push(JSON.parse(JSON.stringify( $scope.editInProgresItem)));
    }

    
    $scope.delete = function (id) {
       // $scope.assignsubjects
        $.each($scope.assignsubjects, function (index, item) {
            if (item.Id == id) {
               // const index = $scope.assignsubjects.indexOf(item);
                //$scope.assignsubjects.splice(index, 1);
                item.IsActive = false;

            }
        });

        //assignsubjectSrv.deleteItem(id).then(function (results) {
        //    $scope.loadingMessage = "";
        //    $scope.populate();
        //}, function (err) {
        //    $scope.error = err;
        //    $scope.loadingMsg = "";
        //});
    };
    $scope.update = function (item) {
        assignsubjectSrv.postItem($scope.editInProgresItem).then(function (results) {
            $scope.loadingMsg = "";
            $scope.populate();
            $scope.editSwitch(item);
        }, function (err) {
            $scope.error = err;
            $scope.loadingMsg = "";
        });
    };
    $scope.reset = function () {
        $scope.editingInProgress = false;
        $scope.editInProgresItem = {
            Id: 0,
            ClassId: 0,
            SectionId: 0,
            SubjectId: 0,
            TeacherId: 0,
            IsActive: true
        };
        $scope.assignsubjects = [];
    }
   
    $scope.add = function () {
        console.log(JSON.stringify($scope.assignsubjects));
        $.each($scope.assignsubjects, function (index, item) {
            assignsubjectSrv.postItem(item).then(function (results) {
                $scope.loadingMsg = "";
                $scope.searchTeachers();
            });
        });
    };
    $scope.searchTeachers = function () {
        var classId = $scope.editInProgresItem.ClassId;
        var sectionId = $scope.editInProgresItem.SectionId;
        assignsubjectSrv.searchTeachers(classId, sectionId).then(function (results) {
            $scope.assignsubjects = results.data;
            $scope.loadingMessage = "";
        });
    };
});