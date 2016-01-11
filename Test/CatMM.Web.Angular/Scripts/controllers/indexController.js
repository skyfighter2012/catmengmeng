app
.controller('indexController', ['$scope', function ($scope) {
    $scope.submit = function (form) {
        console.log(form);
        console.log(form.$submitted);
    }

    $scope.reset = function () {
        $scope.user = {};
    }
}]);