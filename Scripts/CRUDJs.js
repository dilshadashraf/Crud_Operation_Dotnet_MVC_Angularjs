var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {

    $scope.Login = function () {
        $scope.clsLogin = {};
        $scope.clsLogin.UserName = $scope.userName;
        $scope.clsLogin.Password = $scope.password;

        $http({
            method: "POST",
            url: "/Login/LoginCheck",
            data: $scope.clsLogin
        }).then(function (responseFromCSharCSharpController) {
            if (responseFromCSharCSharpController.data === "true") {
                alert("Login Successed");
                window.location.href = "/Home/Welcome";
            }
            else {
                alert("Login Failed");
            }
        })
    }






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
            }).then(function (backendresponse) {
                if (backendresponse.data !== null && backendresponse.data !== "" && backendresponse.data > 0) {
                    alert("User successfully inserted");
                    window.location.href = "/User/ViewUser";
                }
                else {
                    alert("Failed. Something went wrong. Please try aftr some time");
                    console.log(backendresponse.data);
                }
            })

        //console.log("Class Data:" + $scope.clsUser.UserName);

    }

    $scope.GetUsers = function () {
        $http({
            method: 'GET',
            url: '/User/ViewUserDetails'
        }).then(function (backendResponse) {
            console.log(backendResponse.data);// data => predefine (where we get the exact response from c# controller)

            $scope.UserList = backendResponse.data;// List data to bind in html page
        })
    }

    $scope.EditUser = function (userDetails) {
        sessionStorage.setItem("UsinglUserDetail", JSON.stringify(userDetails));// To convert data into string we use JSON.stringyfy(value)
        console.log(userDetails);
        window.location.href = "/User/AddUser";
    }

    // Call this method on Add Page to check session value is there or not at edit time
    $scope.GetSingleUserDetails = function () {
        var user = sessionStorage.getItem("UsinglUserDetail");
        user = JSON.parse(user);
        if (user !== null && user !== undefined) {
            // Bind data in all field one by one (On Add Page in ng-model )
            $scope.userName = user.UserName;
            $scope.isPasswordDisabled = true; //Disabled password field on edit time
            $scope.password = user.Password;
            $scope.email = user.Email;
            $scope.mobile = user.Mobile;
        }        
    }

    $scope.GetAllEmployee = function () {
        $http({
            method: "GET",
            url: "/User/GetAllEmployee"
        }).then(function (response) {
            $scope.EmployeeData = response.data;
        })
    };

    $scope.DeleteUser = function (user) {
        if (confirm("Are you sure want to delete?")) {
            $http({
                method: "POST",
                url: "/User/DeleteStudent",
                data: JSON.stringify(user)
            }).then(function (response) {
                alert(response.data);
                $scope.GetUsers();
            })
        }
    }
});