/// <reference path="C:\SF\TFS\College Management System\App\WCT.SMS\WCT.SMS\js/main.js" />
/// <reference path="C:\SF\TFS\College Management System\App\WCT.SMS\WCT.SMS\js/main.js" />

angular.module('app').controller("subjectCrt", function ($scope, subjectSrv) {
    $scope.error = "";
    $scope.loadingMessage = "Loading...";
    $scope.editingInProgress = false;

    $scope.editInProgresItem = {
        Id: 0,
        Name: "",
        IsActive: true,
        Code: "",
        SubjectTypeId:0
    };

    $scope.editSwitch = function (item) {
        item.edit = !item.edit;
        if (item.edit) {
            $scope.editInProgresItem.Name = item.Name;
            $scope.editInProgresItem.Id = item.Id;
            $scope.editInProgresItem.IsActive = item.IsActive;
            $scope.editInProgresItem.Code = item.Code;
            $scope.editInProgresItem.SubjectTypeId = item.SubjectTypeId;
            $scope.editingInProgress = true;
        } else {
            $scope.addSwitch(item);
        }
    };
    $scope.addSwitch = function (item) {
        $scope.editingInProgress = false;
        $scope.editInProgresItem = {
            Id: 0,
            Name: "",
            IsActive: true,
            Code: "",
            SubjectTypeId: 0
        };
    };
    $scope.populate = function () {
        subjectSrv.getItems().then(function (results) {
            $scope.Subjects = results.data;
            $scope.loadingMessage = "";
        },
            function (err) {
                $scope.error = err;
                $scope.loadingMsg = "";
            });
    };
    $scope.delete = function (id) {
        subjectSrv.deleteItem(id).then(function (results) {
            $scope.loadingMessage = "";
            $scope.populate();
        }, function (err) {
            $scope.error = err;
            $scope.loadingMsg = "";
        });
    };
    $scope.update = function (item) {
        subjectSrv.postItem($scope.editInProgresItem).then(function (results) {
            $scope.loadingMsg = "";
            $scope.populate();
            $scope.editSwitch(item);
        }, function (err) {
            $scope.error = err;
            $scope.loadingMsg = "";
        });
    };
    $scope.add = function () {
        if ($scope.editInProgresItem.Name != "") {
            var item = {
                "Id": $scope.editInProgresItem.Id,
                "Name": $scope.editInProgresItem.Name,
                "IsActive": $scope.editInProgresItem.IsActive,
                "Code": $scope.editInProgresItem.Code,
                "SubjectTypeId": $scope.editInProgresItem.SubjectTypeId
            };
            subjectSrv.postItem(item).then(function (results) {
                $scope.loadingMsg = "";
                $scope.populate();
            },
                function (err) {
                    $scope.error = err;
                    $scope.loadingMsg = "";
                });
        }
    };
    $scope.setTheorySubjectType = function () {
        $scope.editInProgresItem.SubjectTypeId = 1;
    };
    $scope.setPracticalSubjectType = function () {
        $scope.editInProgresItem.SubjectTypeId = 2;
    };
    $scope.reset = function () {
        $scope.editingInProgress = false;
        $scope.editInProgresItem = {
            Id: 0,
            Name: "",
            IsActive: true,
            Code: "",
            SubjectTypeId: 0
        };
    }
});