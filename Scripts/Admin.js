var adminApp = angular.module("adminApp", ['ngFileUpload']);
adminApp.controller("adminCtrl", function ($scope, $http, Upload) {

    //Function to add Course details
    $scope.AddCourse = function () {
        $scope.clsCourse = {};//Java script class
        $scope.clsCourse.CourseName = $scope.courseName; //Value should be from ui page (ng-model name) //CourseName must be same as class name which is paased into parameter in AddCourse Action method in c#
        $scope.clsCourse.Image = $scope.CourseImage;
        $scope.clsCourse.ShortDesc = $scope.shortDesc;

        Upload.upload({
            method: "POST",
            url: '/Course/AddCourseDetail',
            data: {
                course: $scope.clsCourse,
                postedFile: $scope.CourseImageFullDetail
            }
        }).then(function (response) {
            if (response.data !== null && response.data > 0) {
                alert("Course successfully added");
            }
            else {
                alert("Something went wrong. Please try after sometime.");
            }
        });
    };

    $scope.uploadCourseImage = function (file) {
        if (file !== null) {
            $scope.CourseImage = file.name;
            $scope.CourseImageFullDetail = file;
        }
    }

})