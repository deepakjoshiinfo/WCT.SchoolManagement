/// <reference path="C:\SF\TFS\College Management System\App\WCT.SMS\WCT.SMS\js/main.js" />
/// <reference path="C:\SF\TFS\College Management System\App\WCT.SMS\WCT.SMS\js/main.js" />

angular.module('app').controller("sectionCrt", function ($scope, sectionSrv) {
    $scope.error = "";
    $scope.loadingMessage = "Loading...";
    $scope.editingInProgress = false;

    $scope.editInProgresItem = {
        Id: 0,
        Name: "",
        IsActive: true
    };
    $scope.editSwitch = function (item) {
        item.edit = !item.edit;
        if (item.edit) {
            $scope.editInProgresItem.Name = item.Name;
            $scope.editInProgresItem.Id = item.Id;
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
            Name: "",
            IsActive: true
        };
    };
    $scope.populate = function () {
        sectionSrv.getItems().then(function (results) {
            $scope.Section = results.data;
            $scope.loadingMessage = "";
        },
            function (err) {
                $scope.error = err;
                $scope.loadingMsg = "";
            });
    };
    $scope.delete = function (id) {
        sectionSrv.deleteItem(id).then(function (results) {
            $scope.loadingMessage = "";
            $scope.populate();
        }, function (err) {
            $scope.error = err;
            $scope.loadingMsg = "";
        });
    };
    $scope.update = function (item) {
        sectionSrv.postItem($scope.editInProgresItem).then(function (results) {
            $scope.loadingMsg = "";
            $scope.populate();
            $scope.editSwitch(item);
        }, function (err) {
            $scope.error = err;
            $scope.loadingMsg = "";
        });
    };
    $scope.add = function () {
        if ($scope.Name != "") {
            var item = {
                "Id": $scope.editInProgresItem.Id,
                "Name": $scope.editInProgresItem.Name,
                "IsActive": $scope.editInProgresItem.IsActive
            };
            sectionSrv.postItem(item).then(function (results) {
                $scope.loadingMsg = "";
                $scope.populate();
                $scope.editSwitch(item);
            },
            function (err) {
                $scope.error = err;
                $scope.loadingMsg = "";
            });
        }
    };
});