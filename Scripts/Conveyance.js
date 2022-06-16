var convApp = angular.module("convApp", []);
convApp.controller("convCtrl", function ($scope, $http) {

    $scope.uploadBill = function (file) {
        if (file !== null) {
            $scope.BillFullDetails = file;
            $scope.BillName = file.name;
        }
    }

    $scope.AddConveyance = function(){

    }
});