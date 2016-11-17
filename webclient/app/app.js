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

}]).

run(['$rootScope', '$window', function($rootScope, $window) {
  
  // Some OAuth config
  var authorizationUri = 'http://identity.amazing.ctd/connect/authorize';
  var requestScopes = 'openid profile';
  var responseType = 'id_token';

  // Specific Client Details
  var clientId = 'myAppId1234567890'; 
  var loginRedirectUri = 'http://webapp.amazing.ctd:8000/#/auth/login/';

  $rootScope.login = function() {

    var url = authorizationUri

              + "?response_type="
              + encodeURIComponent(responseType)
              
              + "&client_id=" 
              + encodeURIComponent(clientId) 
              
              + "&redirect_uri=" 
              + encodeURIComponent(loginRedirectUri) 
              
              + "&scope=" 
              + encodeURIComponent(requestScopes)
              
              + "&nonce=" 
              + encodeURIComponent('RandomNonce')
              
              + "&state=" 
              + encodeURIComponent('RandomState')
              ; 

    $window.location.href = url;
  };
}])
;