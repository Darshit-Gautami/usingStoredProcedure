var app = angular.module("Homeapp", []);

app.controller("HomeController", function ($window,$scope, $http) {
    $scope.btntext = "Save";
    $scope.search = "";
    // Add record
    $scope.savedata = function () {
        $scope.btntext = "Please Wait..";
        $http({
            method: 'POST',
            url: '/Home/Add_record',
            data: $scope.register
        }).success(function (d) {
            $scope.btntext = "Save";
            $scope.register = null;
            alert(d);
        }).error(function () {
            alert('Failed');
        });
    };
    // Display all record
    $http.get("/Home/Get_data").then(function (d) {
        $scope.record = d.data;
    }, function (error) {
        alert('Failed');
    });
    // Display record by id
    $scope.loadrecord = function (id) {
        $http.get("/Home/Get_databyid?id="+id).then(function (d) {
            $scope.register = d.data[0];
        }, function (error) {
            alert('Failed');
        });
    };
    // Delete record 
    $scope.deleterecord = function (id) {
        $http.get("/Home/delete_record?id=" + id).then(function (d) {
            alert(d.data);
            $http.get("/Home/Get_data").then(function (d) {
                $scope.record = d.data;
            }, function (error) {
                alert('Failed');
            });
        }, function (error) {
            alert('Failed');
        });
    };
    // Update record
    $scope.updatedata = function () {
        $http({
            method: 'POST',
            url: '/Home/update_record',
            data: $scope.register
        }).success(function (d) {
            $scope.btntext = "Update";
            $scope.register = null;
            var landingUrl = "http://localhost:44334/Home/Show_datam";
            alert(landingUrl);
            $window.location.href = landingUrl;
            alert(d);
        }).error(function () {
            alert('Failed');
        });
    };

    $scope.searchData = function (search) {
        debugger
        $http.get("/Home/search_data?search=" + search).then(function (d) {
            $scope.record = d.data;
        }, function (error) {
            alert('Failed');
        });
    }
});