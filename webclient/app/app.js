'use strict';

// Declare app level module which depends on views, and components
angular.module('myApp', [
  'ngRoute',
  'myApp.public.home',
  'myApp.public.whoAmI',
  'myApp.secured',
]).
config(['$locationProvider', '$routeProvider', function($locationProvider, $routeProvider) {





  $routeProvider.otherwise({redirectTo: '/home'});
}]).

run(['$rootScope', '$window', function($rootScope, $window) {
  
  // Some OAuth config
  var tokenIssuerUri = 'http://';
  var clientId = ''; 
  var redirectUri = '';
  var requestScopes = '';

  $rootScope.login = function() {

  };

  $rootScope.logout = function() {

  }
}])
;
