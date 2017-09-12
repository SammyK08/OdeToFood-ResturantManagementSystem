//registrationModule.controller("ResturantViewController",
//    function($scope,bootstrappedData) {

//        scope.resturants = bootstrappedData.resturants;
//    });

angular.module('registrationModule')
    .controller('ResturantViewController',
    [
        '$scope',bootstrappedData,
        function ($scope, bootstrappedData) {
            $scope.resturants = bootstrappedData.resturants;
        }]);


//angular.module('registrationModule')
//    .controller('ResturantViewController',
//    [
//        '$scope', 
//        function ($scope) {
//            $scope.resturants = "Vespa";
//        }]);


