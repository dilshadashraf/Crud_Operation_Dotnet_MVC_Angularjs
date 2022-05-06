var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {

    //$scope.userName = "Arman";
    //alert($scope.userName + "-" + $scope.password + "-" + $scope.email + "-" + $scope.mobile);
    //console.log($scope.userName + "-" + $scope.password + "-" + $scope.email + "-" + $scope.mobile)


    $scope.Register = function () {
        $scope.clsUser = {};//Class creation
        //C# Properties Name       UI Page ng-model name
        $scope.clsUser.UserName = $scope.userName;
        $scope.clsUser.Password = $scope.password;
        $scope.clsUser.Email = $scope.email;
        $scope.clsUser.Mobile = $scope.mobile;

        //$htttp.post("/User/AddUser")

        $http(
            {
                method: 'POST',
                url: '/User/AddUser',
                data: $scope.clsUser
            }).then(function (backedresponse) {
                alert("success");
            })

        //console.log("Class Data:" + $scope.clsUser.UserName);

    }

    $scope.GetUsers = function () {
        $http({
            method: 'GET',
            url: '/User/ViewUserDetails'
        }).then(function (backendResponse) {
            console.log(backendResponse.data);

            $scope.UserList = backendResponse.data;// List data to bind in html page
        })
    }


});