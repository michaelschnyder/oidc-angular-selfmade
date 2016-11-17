'use strict';

// Declare app level module which depends on views, and components
angular.module('myApp', [
  'ngRoute',
  'LocalStorageModule',
  'myApp.public.home',
  'myApp.public.whoAmI',
  'myApp.secured',
]).

config(['$routeProvider', '$httpProvider', function($routeProvider, $httpProvider) {

  // Default route
  $routeProvider.otherwise({redirectTo: '/home'});

}])
;
