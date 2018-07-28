angular.module('app').controller("teacherCrt", function ($scope, teacherSrv, genderSrv) {
    $scope.error = "";
    $scope.loadingMessage = "Loading...";
    $scope.editingInProgress = false;
    $scope.options = {
        maxDate: new Date(),
        showWeeks: true
    };
    $scope.popup2 = {
        opened: false
    };
    $scope.open2 = function () {
        $scope.popup2.opened = true;
    };
    $scope.editInProgresItem = {
        Id: 0,
        Name: "",
        Email: "",
        GenderId: 1,
        DOB: new Date(),
        Address: "",
        Phone: "",
        IsActive: true,
        TeminationDate: new Date(),
        CreatedBy: 1,
        CreatedDate: new Date(),
        ModifiedBy: 1,
        ModifiedDate: new Date()
    };
    $scope.editSwitch = function (item) {
        item.edit = !item.edit;
        if (item.edit) {
            $scope.editInProgresItem = item;
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
        teacherSrv.getItems().then(function (results) {
            $scope.Teachers = results.data;
            $scope.loadingMessage = "";
        },
            function (err) {
                $scope.error = err;
                $scope.loadingMsg = "";
            });
    };
    $scope.delete = function (id) {
        teacherSrv.deleteItem(id).then(function (results) {
            $scope.loadingMessage = "";
            $scope.populate();
        }, function (err) {
            $scope.error = err;
            $scope.loadingMsg = "";
        });
    };
    $scope.update = function () {
        var item = $scope.editInProgresItem;
        teacherSrv.postItem(item).then(function (results) {
            $scope.loadingMsg = "";
            $scope.populate();
            $scope.editSwitch(item);
        }, function (err) {
            $scope.error = err;
            $scope.loadingMsg = "";
        });
    };
    $scope.add = function () {
        $scope.editingInProgress = false;
        if ($scope.editInProgresItem.Name != "") {
            var item = $scope.editInProgresItem;
            console.log(item);
            teacherSrv.postItem(item).then(function (results) {
                $scope.loadingMsg = "";
                $scope.populate();
            },
                function (err) {
                    $scope.error = err;
                    $scope.loadingMsg = "";
                });
        }
    };
    $scope.getGenders = function () {
        genderSrv.getItems().then(function (results) {
            $scope.Genders = results.data;
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
            Name: "",
            Email: "",
            GenderId: 1,
            DOB: "",
            Address: "",
            Phone: "",
            IsActive: true,
            TeminationDate: new Date(),
            CreatedBy: 1,
            CreatedDate: new Date(),
            ModifiedBy: 1,
            ModifiedDate: new Date()
        };
    };
    $scope.viewTeacher = function (objTeacher) {
        $scope.SelectedTeacher = objTeacher;
    }
    
});
