/// <reference path="C:\SF\TFS\College Management System\App\WCT.SMS\WCT.SMS\js/main.js" />
/// <reference path="C:\SF\TFS\College Management System\App\WCT.SMS\WCT.SMS\js/main.js" />

angular.module('app').controller("classtimetableCrt", function ($scope, classtimetableSrv, subjectSrv, classSrv,) {
    $scope.error = "";
    $scope.loadingMessage = "Loading...";
    $scope.editingInProgress = false;
    $scope.timetables = [];

    $scope.editInProgresItem = {
        Id: 0,
        SubjectId: 0,
        ClassId: 0,
        SectionId: 0,
        DayId: 0,
        StartTime: "",
        EndTime: "",
        RoomNo: "",
        IsActive: true
    };
    $scope.editSwitch = function (item) {
        item.edit = !item.edit;
        if (item.edit) {
            $scope.editInProgresItem.SubjectId = item.SubjectId;
            $scope.editInProgresItem.ClassId = item.ClassId;
            $scope.editInProgresItem.SectionId = item.SectionId;
            $scope.editInProgresItem.DayId = item.DayId;
            $scope.editInProgresItem.Id = item.Id;
            $scope.editInProgresItem.StartTime = item.StartTime;
            $scope.editInProgresItem.EndTime = item.EndTime;
            $scope.editInProgresItem.RoomNo = item.RoomNo;
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
            SubjectId: 0,
            ClassId: 0,
            SectionId: 0,
            DayId: 0,
            StartTime: "",
            EndTime: "",
            RoomNo: "",
            IsActive: true
        };
    };
    $scope.populate = function () {
        classtimetableSrv.getItems().then(function (results) {
            $scope.timetables = results.data;
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
        $scope.timetables.push(JSON.parse(JSON.stringify($scope.editInProgresItem)));
    }

    $scope.delete = function (id) {
        classtimetableSrv.deleteItem(id).then(function (results) {
            $scope.loadingMessage = "";
            $scope.populate();
        }, function (err) {
            $scope.error = err;
            $scope.loadingMsg = "";
        });
    };
    $scope.update = function (item) {
        classtimetableSrv.postItem($scope.editInProgresItem).then(function (results) {
            $scope.loadingMsg = "";
            $scope.populate();
            $scope.editSwitch(item);
        }, function (err) {
            $scope.error = err;
            $scope.loadingMsg = "";
        });
    };
    $scope.getDays = function () {
        classtimetableSrv.getDays().then(function (results) {
            $scope.days = results.data;
            $scope.loadingMessage = "";

        },
            function (err) {
                $scope.error = err;
                $scope.loadingMsg = "";
            });
    };
    $scope.getTimetable = function (classId, sectionId, subjectId) {
        classtimetableSrv.getTimetable(classId, sectionId, subjectId).then(function (results) {
            $scope.timetables = results.data;
            $scope.loadingMessage = "";
        },
            function (err) {
                $scope.error = err;
                $scope.loadingMsg = "";
            });
    };
    $scope.getTimetableDetails = function (classId, sectionId, subjectId) {
        classtimetableSrv.getTimetableDetails(classId, sectionId, subjectId).then(function (results) {
            $scope.timetables = results.data;
            $scope.loadingMessage = "";
        },
            function (err) {
                $scope.error = err;
                $scope.loadingMsg = "";
            });
    };
    $scope.reset = function () {
        $scope.editingInProgress = false;
        $scope.editInProgresItem = {
            Id: 0,
            SubjectId: 0,
            ClassId: 0,
            SectionId: 0,
            DayId: 0,
            StartTime: "",
            EndTime: "",
            RoomNo: "",
            IsActive: true
        };
        $scope.timetables = [];
    }

    $scope.add = function () {
        //alert("dd");
       // console.log(JSON.stringify($scope.timetables));
        $.each($scope.timetables, function (index, item) {
            classtimetableSrv.postItem(item).then(function (results) {
                $scope.loadingMsg = "Saved..Sucessfully";
            });
        });
    };
});