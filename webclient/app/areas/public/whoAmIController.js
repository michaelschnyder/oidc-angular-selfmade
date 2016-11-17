'use strict';

angular.module('myApp.public.whoAmI', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/whoami', {
    templateUrl: 'areas/public/whoAmIPage.html',
    controller: 'WhoAmIController'
  });
}])

.controller('WhoAmIController', ['$http', '$scope', function($http, $scope) {


  $http.get('http://api.amazing.ctd/whoami').then(
    
    function success(response) {
      $scope.isError = false;
      $scope.errorDetail = null;

      $scope.whoami = response.data;
    }, 
    
    function error(response) {
      $scope.isError = true;
      $scope.errorDetail = response;
    }

  );
}])