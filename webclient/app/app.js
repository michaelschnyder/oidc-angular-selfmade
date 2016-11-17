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
  var tokenIssuerUri = 'http://identity.amazing.ctd/connect/authorize';
  var responseType = 'id_token';
  var requestScopes = 'openid profile';

  // About Me
  var clientId = 'myAppId1234567890'; 
  var redirectUri = 'http://webapp.amazing.ctd:8000/#/callback/login';

  $rootScope.login = function() {

    var url = tokenIssuerUri

              + "?response_type="
              + encodeURIComponent(responseType)
              
              + "&client_id=" 
              + encodeURIComponent(clientId) 
              
              + "&redirect_uri=" 
              + encodeURIComponent(redirectUri) 
              
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
