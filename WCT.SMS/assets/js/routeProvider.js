/// <reference path="C:\SF\TFS\College Management System\App\WCT.SMS\WCT.SMS\academic/accadmic-class.html" />
var app = angular.module("app", ['ngRoute', 'ui.bootstrap', 'moment-picker']);

// =====================================
// configure the route navigation
// =====================================
app.config(function ($routeProvider) {
    $routeProvider
    .when('/',
    {
        templateUrl: 'home.html',
        controller: 'SPAController'
    })
    .when('/about',
    {
        templateUrl: 'about.html',
        controller: 'AboutController'
    })
    .when('/contact',
    {
        templateUrl: 'contact.html',
        controller: 'ContactController'
    })
    .when('/PD',
    {
        templateUrl: '/SPA/PD/index.html',
        controller: "PDController"
    })
    .when('/PD/Create',
    {
        templateUrl: '/SPA/PD/create.html',
        controller: "PDControllerCreate"
    })
    .when('/PD/Edit/:id',
    {
        templateUrl: '/SPA/PD/edit.html',
        controller: "PDControllerEdit"
    })
    .when('/PD/Details/:id',
    {
        templateUrl: '/SPA/PD/details.html',
        controller: "PDControllerDetails"
    })
    .when('/PD/Delete/:id',
    {
        templateUrl: '/SPA/PD/delete.html',
        controller: "PDControllerDelete"
    })
    //Added for school

    /// ##### Student ### 
     .when('/student/information',
    {
        templateUrl: '/views/student/student-details.html',
        controller: "SPAController"
    })
      .when('/student/register',
    {
        templateUrl: '/views/student/register.html',
        controller: "studentCrt"
    })
    .when('/student/register/:studentid',
    {
        templateUrl: '/views/student/register.html',
        controller: "studentCrt"
    })
      .when('/student/category',
    {
        templateUrl: '/views/student/student-category.html',
        controller: "categoryCrt"
    })
      .when('/student/promote',
    {
        templateUrl: '/views/student/promote-student.html',
        controller: "SPAController"
    })
     /// ##### Fee ### 
     .when('/fee/master',
    {
        templateUrl: '/views/fee/fee-master.html',
        controller: "SPAController"
    })
      .when('/fee/type',
    {
        templateUrl: '/views/fee/fee-type.html',
        controller: "SPAController"
    })
      .when('/fee/category',
    {
        templateUrl: '/views/fee/fee-category.html',
        controller: "SPAController"
    })
      .when('/fee/payment',
    {
        templateUrl: '/views/fee/fee-payment.html',
        controller: "SPAController"
    })
      .when('/fee/due',
    {
        templateUrl: '/views/fee/fee-due.html',
        controller: "SPAController"
    })
      .when('/fee/statement',
    {
        templateUrl: '/views/fee/fee-statement.html',
        controller: "SPAController"
    })
      .when('/fee/balance',
    {
        templateUrl: '/views/fee/fee-balance-report.html',
        controller: "SPAController"
    })
      .when('/fee/accountants',
    {
        templateUrl: '/views/fee/fee-accountants.html',
        controller: "SPAController"
    })
     /// ##### Academics ### 
     .when('/academic/timetable',
    {
        templateUrl: '/views/academic/academic-class-timetable.html',
        controller: "SPAController"
        })
        .when('/academic/addtimetable',
            {
                templateUrl: '/views/academic/academic-add-timetable.html',
                controller: "SPAController"
            })
      .when('/academic/assignsubject',
    {
        templateUrl: '/views/academic/academic-assign-subject.html',
        controller: "SPAController"
    })
      .when('/academic/subjects',
    {
        templateUrl: '/views/academic/academic-subjects.html',
        controller: "SPAController"
    })
      .when('/academic/teachers',
    {
        templateUrl: '/views/academic/academic-teachers.html',
        controller: "SPAController"
    })
      .when('/academic/class',
    {
        templateUrl: '/views/academic/accadmic-class.html',
        controller: "classCrt"
    })
      .when('/academic/sections',
    {
        templateUrl: '/views/academic/academic-sections.html',
        controller: "classCrt"
    })
     /// ##### Settings ### 
     .when('/settings/general',
    {
        templateUrl: '/views/settings/setting-general.html',
        controller: "SPAController"
    })
      .when('/settings/session',
    {
        templateUrl: '/views/settings/setting-session.html',
        controller: "SPAController"
    })
      .when('/settings/sms',
    {
        templateUrl: '/views/settings/setting-sms.html',
        controller: "SPAController"
    })
      .when('/settings/paypal',
    {
        templateUrl: '/views/settings/setting-paypal.html',
        controller: "SPAController"
    })
      .when('/settings/backup',
    {
        templateUrl: '/views/settings/setting-backup.html',
        controller: "SPAController"
    })
      .when('/settings/language',
    {
        templateUrl: '/views/settings/setting-language.html',
        controller: "SPAController"
    })
      .when('/settings/user',
    {
        templateUrl: '/views/settings/setting-user.html',
        controller: "SPAController"
    })
      /// ##### Settings ### 
     .when('/examination/list',
    {
        templateUrl: '/views/examination/exam-list.html',
        controller: "SPAController"
    })
      .when('/examination/shedule',
    {
        templateUrl: '/views/examination/exam-shedule.html',
        controller: "SPAController"
    })
      .when('/examination/mark',
    {
        templateUrl: '/views/examination/examk-mark.html',
        controller: "SPAController"
    })
      .when('/examination/grade',
    {
        templateUrl: '/views/examination/exam-mark-grade.html',
        controller: "SPAController"
    })
    
});


// ===================================================
// Create other controllers for respective pages
// ===================================================

// default controller
app.controller("SPAController", function ($scope, $rootScope) {
    $scope.Title = "Welcome";
    $rootScope.loading = false;
});

// Home controller
app.controller("HomeController", function ($scope) {
    $scope.Title = "Single Page Application (SPA)";
});

// About controller
app.controller("AboutController", function ($scope) {
    $scope.Title = "About us";
});

// Contact controller
app.controller("ContactController", function ($scope) {
    $scope.Title = "Contact us";
});

