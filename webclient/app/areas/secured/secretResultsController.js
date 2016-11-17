'use strict';

angular.module('myApp.secured', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/secrets', {
    templateUrl: 'areas/secured/secretResults.html',
    controller: 'SecretResultsController'
  });
}])

.controller('SecretResultsController', ['$http', '$scope', function($http, $scope) {

  $http.get('http://api.amazing.ctd/secrets').then(
    
    function success(response) {
      $scope.isError = false;
      $scope.errorDetail = null;

      $scope.list = response.data;
    }, 
    
    function error(response) {
      $scope.isError = true;
      $scope.errorDetail = response;
    }

  );
}])


;