'use strict';

angular.module('myApp.public.home', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/home', {
    templateUrl: 'areas/public/homePage.html',
    controller: 'HomeController'
  });
}])

.controller('HomeController', [function() {

}]);