/// <reference path="C:\SF\TFS\College Management System\App\WCT.SMS\WCT.SMS\js/main.js" />
/// <reference path="C:\SF\TFS\College Management System\App\WCT.SMS\WCT.SMS\js/main.js" />

angular.module('app').controller("classCrt", function ($scope, classSrv, sectionSrv) {
    $scope.error = "";
    $scope.loadingMessage = "Loading...";
    $scope.editingInProgress = false;
    $scope.editInProgresItem = {
        Id: 0,
        Name: "",
        IsActive: true,
        Sections: "",
        edit: false
    };
    $scope.editSwitch = function (item) {
        item.edit = !item.edit;
        if (item.edit) {
            $scope.editInProgresItem.Name = item.Name;
            $scope.editInProgresItem.Id = item.Id;
            $scope.editInProgresItem.IsActive = item.IsActive;
            $scope.editInProgresItem.Sections = item.Sections;
            $scope.editingInProgress = true;
            $scope.selectSections(item);
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
            Sections: "",
        };
        $scope.getSection();
    };
    $scope.selectSections = function (item) {
        angular.forEach($scope.Section, function (section, key) {
            section.IsSelected = false;
            angular.forEach(item.Sections, function (selected, key) {
                if (section.Id == selected.Id) {
                    section.IsSelected = true;
                }
            });
        });
    };
    $scope.populate = function () {
        classSrv.getItems().then(function (results) {
            $scope.Class = results.data;
            $scope.loadingMessage = "";
        },
            function (err) {
                $scope.error = err;
                $scope.loadingMsg = "";
            });
    };
    $scope.delete = function (id) {
       classSrv.deleteItem(id).then(function (results) {
            $scope.loadingMessage = "";
            $scope.populate();
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
                "Sections": $scope.Section,
                "edit": true
            };
            classSrv.postItem(item).then(function (results) {
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
    $scope.getSection = function () {
        sectionSrv.getItems().then(function (results) {
            $scope.Section = results.data;
            $scope.loadingMessage = "";
        },
           function (err) {
               $scope.error = err;
               $scope.loadingMsg = "";
           });
    }
});