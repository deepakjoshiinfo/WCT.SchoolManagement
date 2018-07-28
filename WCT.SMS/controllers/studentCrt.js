angular.module('app').controller("studentCrt", function ($scope, $routeParams, $location, classSrv, genderSrv, categorySrv, studentSrv, commonSrv) {
    $scope.error = "";
    $scope.loadingMessage = "Loading...";
    $scope.editingInProgress = false;
    $scope.files = [];
    //$scope.Student = { "DOB": new Date() };
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

    $scope.uploadFiles = function () {
        //alert(JSON.stringify($scope.files));
        console.log($scope.files[0].url);
        commonSrv.downloadImage($scope.files[0].url).then(function (results) {
            var bytes = results.data;
        });
    };
    $scope.removeFile = function (item) {
        var index = $scope.files.indexOf(item);
        $scope.files.splice(index, 1);
    }
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
    $scope.getCategories = function () {
        categorySrv.getActiveItems().then(function (results) {
            $scope.Categories = results.data;
            $scope.loadingMessage = "";
        },
          function (err) {
              $scope.error = err;
              $scope.loadingMsg = "";
          });
    };

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

        studentSrv.getItems().then(function (results) {
            $scope.Students = results.data;
            $scope.loadingMessage = "";
        },
            function (err) {
                $scope.error = err;
                $scope.loadingMsg = "";
            });
    };
    $scope.delete = function (id) {
        studentSrv.deleteItem(id).then(function (results) {
            $scope.loadingMessage = "";
            $scope.populate();
        }, function (err) {
            $scope.error = err;
            $scope.loadingMsg = "";
        });
    };
    $scope.update = function (item) {
        studentSrv.postItem($scope.editInProgresItem).then(function (results) {
            $scope.loadingMsg = "";
            $scope.populate();
            $scope.editSwitch(item);
        }, function (err) {
            $scope.error = err;
            $scope.loadingMsg = "";
        });
    };
    $scope.add = function () {
       
        var item = $scope.Student;
        console.log(item);
        //var item = {
        //    "Id": $scope.editInProgresItem.Id,
        //    "Name": $scope.editInProgresItem.Name,
        //    "IsActive": $scope.editInProgresItem.IsActive
        //};
        studentSrv.postItem(item).then(function (results) {
            window.location.href = "master.html#!/student/information";
            $scope.loadingMsg = "";
        },
        function (err) {
            $scope.error = err;
            $scope.loadingMsg = "";
        });
    };
    $scope.getStudent = function (id) {
        studentSrv.getItem(id).then(function (results) {
            $scope.Student = results.data;
            if ($scope.Student.DOB) {
                $scope.Student.DOB = new Date($scope.Student.DOB);
            }
            $scope.getSections($scope.Student.ClassId);
        }, function (err) {
            $scope.error = err;
            $scope.loadingMsg = "";
        });
    };
    $scope.setGuardian = function (id) {
        var item = {
            "Id": 0,
            "Name": "",
            "IsActive": true
        };
        switch (id) {
            case 1: $scope.Student.Guardian = $scope.Student.Mother;
                $scope.Student.Guardian.Relation.Name = "Mother";
                break;
            case 2: $scope.Student.Guardian = $scope.Student.Father;
                $scope.Student.Guardian.Relation.Name = "Father";
                break;
            case 3: $scope.Student.Guardian = item;
                //$scope.Student.Guardian.Relation.Name = "Other";
                break;
        }
    };
    $scope.setStudentCurrentAddress = function () {
        $scope.Student.IsGuardianAddressCurrent = !$scope.Student.IsGuardianAddressCurrent;
        if ($scope.Student.IsGuardianAddressCurrent) {
            $scope.Student.CurrentAddress = $scope.Student.Guardian.Address;
        }
        else {
            $scope.Student.CurrentAddress = null;
        }

    };
    $scope.setStudentPermanentAddress = function () {
        $scope.Student.IsPermanentAddressCurrent = !$scope.Student.IsPermanentAddressCurrent;
        if ($scope.Student.IsPermanentAddressCurrent) {
            $scope.Student.PermanentAddress = $scope.Student.CurrentAddress;
        }
        else {
            $scope.Student.PermanentAddress = null;
        }
    };

    // Using $location service
    var url = $location.path().split('/');
    //$scope.studentid = url[2];
    if (url.length > 3) {
        var studentid = url[3];
        if (studentid) {
            $scope.getStudent(studentid);
        }
    }
});;
